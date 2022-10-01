using System;
using Zenject;

namespace SimpleUi.Signals
{
	public static class SignalExtensions
	{
		public static void OpenWindow<TWindow>(this SignalBus signalBus, EWindowLayer windowLayer = EWindowLayer.Local)
			where TWindow : Window
			=> signalBus.FireId(windowLayer, new SignalOpenWindow(typeof(TWindow)));

		public static void OpenWindow(this SignalBus signalBus, Type type,
			EWindowLayer windowLayer = EWindowLayer.Local)
			=> signalBus.FireId(windowLayer, new SignalOpenWindow(type));

		public static void OpenWindow(this SignalBus signalBus, string name,
			EWindowLayer windowLayer = EWindowLayer.Local)
			=> signalBus.FireId(windowLayer, new SignalOpenWindow(name));

		public static void BackWindow(this SignalBus signalBus, EWindowLayer windowLayer = EWindowLayer.Local)
			=> signalBus.FireId<SignalBackWindow>(windowLayer);
	}
}