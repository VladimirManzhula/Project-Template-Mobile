using System;

namespace SimpleUi.Signals
{
	public readonly struct SignalOpenWindow
	{
		public readonly Type Type;
		public readonly string Name;

		public SignalOpenWindow(Type type)
		{
			Type = type;
			Name = null;
		}

		public SignalOpenWindow(string name)
		{
			Type = null;
			Name = name;
		}
	}
}