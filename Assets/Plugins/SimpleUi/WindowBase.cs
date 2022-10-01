using System.Collections.Generic;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using Zenject;

namespace SimpleUi
{
	public abstract class WindowBase : Window
	{
		private readonly List<IUiController> _controllers = new List<IUiController>();

		[Inject] private DiContainer _container;

		[Inject]
		protected abstract void AddControllers();

		protected void AddController<TController>()
			where TController : IUiController
		{
			var controller = _container.Resolve<TController>();
			_controllers.Add(controller);
		}

		public override void SetState(UiWindowState state)
		{
			for (var i = 0; i < _controllers.Count; i++)
				_controllers[i].SetState(new UiControllerState(state.IsActive, state.InFocus, i));
			ProcessState();
		}

		public override void Back()
		{
			for (var i = 0; i < _controllers.Count; i++)
				_controllers[i].Back();
			ProcessState();
		}

		private void ProcessState()
		{
			for (var i = 0; i < _controllers.Count; i++)
				_controllers[i].ProcessStateOrder();
			for (var i = 0; i < _controllers.Count; i++)
				_controllers[i].ProcessState();
		}

		public override IUiElement[] GetUiElements()
		{
			var list = new List<IUiElement>();
			for (var i = 0; i < _controllers.Count; i++)
				list.AddRange(_controllers[i].GetUiElements());

			return list.ToArray();
		}
	}
}