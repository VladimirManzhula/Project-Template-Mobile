using SimpleUi.Models;

namespace SimpleUi.Interfaces
{
	public interface IUiController
	{
		bool IsActive { get; }
		bool InFocus { get; }

		void SetState(UiControllerState state);
		void ProcessStateOrder();
		void ProcessState();
		void Back();
		IUiElement[] GetUiElements();
	}
}