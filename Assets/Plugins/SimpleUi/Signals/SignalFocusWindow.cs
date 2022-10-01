using SimpleUi.Interfaces;

namespace SimpleUi.Signals
{
	public readonly struct SignalFocusWindow
	{
		public readonly IWindow Window;

		public SignalFocusWindow(IWindow window)
		{
			Window = window;
		}
	}
}