using SimpleUi.Interfaces;
using SimpleUi.Managers;
using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace SimpleUi
{
	public static class UiBindExtensions
	{
		public static void BindUiView<T, TU>(this DiContainer container, Object viewPrefab, Transform parent)
			where TU : IUiView
			where T : IUiController
		{
			container.BindInterfacesAndSelfTo<T>().AsSingle();
			container.BindInterfacesAndSelfTo<TU>()
				.FromComponentInNewPrefab(viewPrefab)
				.UnderTransform(parent).AsSingle()
				.OnInstantiated((context, o) => ((MonoBehaviour) o).gameObject.SetActive(false));
		}

		public static void BindUiSignals(this DiContainer container, EWindowLayer windowLayer)
		{
			container.DeclareSignal<SignalOpenWindow>().WithId(windowLayer);
			container.DeclareSignal<SignalOpenRootWindow>().WithId(windowLayer);
			container.DeclareSignal<SignalBackWindow>().WithId(windowLayer);
			container.DeclareSignal<SignalShowWindow>().WithId(windowLayer).OptionalSubscriber();
			container.DeclareSignal<SignalActiveWindow>().WithId(windowLayer).OptionalSubscriber();
			container.DeclareSignal<SignalFocusWindow>().WithId(windowLayer).OptionalSubscriber();
			container.DeclareSignal<SignalCloseWindow>().WithId(windowLayer).OptionalSubscriber();
		}

		public static void BindWindowsController<T>(this DiContainer container, EWindowLayer windowLayer)
			where T : IWindowsController, IInitializable
		{
			container.BindInitializableExecutionOrder<T>(-1000);
			container.BindInterfacesTo<T>().AsSingle().WithArguments(windowLayer).NonLazy();
			var windowState = new WindowState();
			container.BindInterfacesTo<WindowState>().FromInstance(windowState).AsSingle();
			container.Bind<WindowState>().FromInstance(windowState).WhenInjectedInto<T>();
			//container.BindInterfacesAndSelfTo<UiMapperManager>().AsSingle().WithArguments(windowLayer).NonLazy();
		}
	}
}