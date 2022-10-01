using SimpleUi.Interfaces;

namespace SimpleUi.Signals
{
	public readonly struct SignalShowWindow
	{
		public readonly IWindow Window;

		public SignalShowWindow(IWindow window)
		{
			Window = window;
		}
	}
}