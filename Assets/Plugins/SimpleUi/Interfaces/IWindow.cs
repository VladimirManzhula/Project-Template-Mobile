using SimpleUi.Models;

namespace SimpleUi.Interfaces
{
	public interface IWindow
	{
		string Name { get; }
		void SetState(UiWindowState state);
		void Back();
		IUiElement[] GetUiElements();
	}
}