using SimpleUi.Interfaces;

namespace SimpleUi.Signals
{
	public readonly struct SignalCloseWindow
	{
		public readonly IWindow Window;

		public SignalCloseWindow(IWindow window)
		{
			Window = window;
		}
	}
}