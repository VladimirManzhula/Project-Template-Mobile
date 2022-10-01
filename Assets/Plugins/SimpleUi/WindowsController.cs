using System;
using System.Collections.Generic;
using System.Linq;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace SimpleUi
{
	public class WindowsController : IWindowsController, IInitializable, IDisposable
	{
		private readonly DiContainer _container;
		private readonly SignalBus _signalBus;
		private readonly List<IWindow> _windows;
		private readonly WindowState _windowState;
		private readonly EWindowLayer _windowLayer;
		private readonly Stack<IWindow> _windowsStack = new Stack<IWindow>();
		private readonly CompositeDisposable _disposables = new CompositeDisposable();

		private IWindow _window;

		public Stack<IWindow> Windows => _windowsStack;

		public WindowsController(
			DiContainer container,
			SignalBus signalBus,
			[Inject(Source = InjectSources.Local)] List<IWindow> windows,
			[Inject(Source = InjectSources.Local)] WindowState windowState,
			EWindowLayer windowLayer
		)
		{
			_container = container;
			_signalBus = signalBus;
			_windows = windows;
			_windowState = windowState;
			_windowLayer = windowLayer;
		}

		public void Initialize()
		{
			_signalBus.GetStreamId<SignalOpenWindow>(_windowLayer).Subscribe(OnOpen).AddTo(_disposables);
			_signalBus.GetStreamId<SignalBackWindow>(_windowLayer).Subscribe(_ => OnBack()).AddTo(_disposables);
			_signalBus.GetStreamId<SignalOpenRootWindow>(_windowLayer).Subscribe(OnOpenRootWindow).AddTo(_disposables);
		}

		public void Dispose() => _disposables.Dispose();

		private void OnOpen(SignalOpenWindow signal)
		{
			IWindow window;
			if (signal.Type != null)
				window = _container.Resolve(signal.Type) as IWindow;
			else
				window = _windows.Find(f => f.Name == signal.Name);
			Open(window);
		}

		private void Open(IWindow window)
		{
			var isNextWindowPopUp = window is IPopUp;
			var currentWindow = _windowsStack.Count > 0 ? _windowsStack.Peek() : null;
			if (currentWindow != null)
			{
				var isCurrentWindowPopUp = currentWindow is IPopUp;
				var isCurrentWindowNoneHidden = currentWindow is INoneHidden;
				if (isCurrentWindowPopUp)
				{
					if (!isNextWindowPopUp)
					{
						var openedWindows = GetPreviouslyOpenedWindows();
						var popupsOpened = GetPopupsOpened(openedWindows);
						var last = openedWindows.Last();
						last.SetState(UiWindowState.NotActiveNotFocus);

						foreach (var openedPopup in popupsOpened)
						{
							openedPopup.SetState(UiWindowState.NotActiveNotFocus);
						}
					}
					else
						currentWindow.SetState(isCurrentWindowNoneHidden
							? UiWindowState.IsActiveNotFocus
							: UiWindowState.NotActiveNotFocus);
				}
				else if (isNextWindowPopUp)
					_window?.SetState(UiWindowState.IsActiveNotFocus);
				else
					_window?.SetState(isCurrentWindowNoneHidden
						? UiWindowState.IsActiveNotFocus
						: UiWindowState.NotActiveNotFocus);
			}

			_windowsStack.Push(window);
			_windowState.CurrentWindowName = window.Name;
			window.SetState(UiWindowState.IsActiveAndFocus);
			_signalBus.FireId(_windowLayer, new SignalShowWindow(window));
			ActiveAndFocus(window, isNextWindowPopUp);
		}

		private void OnBack()
		{
			if (_windowsStack.Count == 0)
				return;

			var currentWindow = _windowsStack.Pop();
			currentWindow.Back();
			_signalBus.FireId(_windowLayer, new SignalCloseWindow(currentWindow));
			OpenPreviousWindows();
		}

		private void OpenPreviousWindows()
		{
			if (_windowsStack.Count == 0)
				return;

			var openedWindows = GetPreviouslyOpenedWindows();
			var popupsOpened = GetPopupsOpened(openedWindows);
			var firstWindow = GetFirstWindow();
			var isFirstPopUp = false;

			var isNoPopups = popupsOpened.Count == 0;
			var isOtherWindow = firstWindow != _window;
			if (isOtherWindow || isNoPopups)
			{
				firstWindow = openedWindows.Last();
				firstWindow.Back();
				_window = firstWindow;
			}

			if (!isNoPopups)
			{
				var window = popupsOpened.Last();
				window.Back();
				firstWindow = window;
				isFirstPopUp = true;

				if (isOtherWindow)
				{
					var nonHiddenPopUps = popupsOpened.Take(popupsOpened.Count - 1);
					foreach (var nonHiddenPopUp in nonHiddenPopUps)
						nonHiddenPopUp.Back();
				}
			}

			_windowState.CurrentWindowName = firstWindow.Name;
			ActiveAndFocus(firstWindow, isFirstPopUp);
		}

		private void ActiveAndFocus(IWindow window, bool isPopUp)
		{
			if (!isPopUp)
				_window = window;

			_signalBus.FireId(_windowLayer, new SignalActiveWindow(window));
			_signalBus.FireId(_windowLayer, new SignalFocusWindow(window));
		}

		private List<IWindow> GetPreviouslyOpenedWindows()
		{
			var windows = new List<IWindow>();

			var hasWindow = false;
			foreach (var window in _windowsStack)
			{
				var isPopUp = window is IPopUp;
				if (isPopUp)
				{
					if (hasWindow)
						break;

					windows.Add(window);
					continue;
				}

				if (hasWindow)
					break;
				windows.Add(window);
				hasWindow = true;
			}

			return windows;
		}

		private Stack<IWindow> GetPopupsOpened(List<IWindow> windows)
		{
			var stack = new Stack<IWindow>();

			var hasPopup = false;
			for (var i = 0; i < windows.Count; i++)
			{
				var window = windows[i];
				var isPopUp = window is IPopUp;
				if (!isPopUp)
					break;

				if (hasPopup && !(window is INoneHidden))
					continue;

				stack.Push(window);
				hasPopup = true;
			}

			return stack;
		}

		private IWindow GetFirstWindow()
		{
			foreach (var element in _windowsStack)
			{
				if (element is IPopUp)
					continue;
				return element;
			}

			return null;
		}

		private void OnOpenRootWindow(SignalOpenRootWindow obj)
		{
			while (_windowsStack.Count > 1)
			{
				OnBack();
			}
		}

		public void Reset()
		{
			while (_windowsStack.Count > 0)
			{
				OnBack();
			}

			_window = null;
		}
	}
}