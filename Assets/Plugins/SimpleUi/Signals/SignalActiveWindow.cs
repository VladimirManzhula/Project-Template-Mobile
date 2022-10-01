using SimpleUi.Interfaces;

namespace SimpleUi.Signals
{
	public readonly struct SignalActiveWindow
	{
		public readonly IWindow Window;

		public SignalActiveWindow(IWindow window)
		{
			Window = window;
		}
	}
}