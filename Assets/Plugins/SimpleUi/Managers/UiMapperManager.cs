using System;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace SimpleUi.Managers
{
	public class UiMapperManager : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly EWindowLayer _windowLayer;
		private readonly CompositeDisposable _disposables = new CompositeDisposable();

		private WindowData _windowData;
		public WindowData WindowData => _windowData;

		public UiMapperManager(SignalBus signalBus, EWindowLayer windowLayer)
		{
			_signalBus = signalBus;
			_windowLayer = windowLayer;
		}

		public void Initialize()
		{
			_signalBus.GetStreamId<SignalActiveWindow>(_windowLayer).Subscribe(f => OnWindowChange(f.Window))
				.AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void OnWindowChange(IWindow window)
		{
			if (window == null)
				return;
			_windowData = new WindowData(window.Name, window.GetUiElements());
		}

		public void Highlight(string pathToElement)
		{
			var element = FindElement(pathToElement);
			element.Highlight();
		}

		public void Reset(string pathToElement)
		{
			var element = FindElement(pathToElement);
			element.Reset();
		}

		public int GetElementId(string pathToElement)
		{
			var element = FindElement(pathToElement);
			return element.Id;
		}

		private IUiElement FindElement(string pathToElement)
		{
			var path = new Path(pathToElement);
			return WindowData.Name != path.Window ? null : WindowData.GetElement(path.Element);
		}
	}
}