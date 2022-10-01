using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace SimpleUi
{
	public class SimpleUiInstaller : MonoInstaller
	{
		[SerializeField] private EWindowLayer windowLayer;

		public override void InstallBindings()
		{
			Container.BindWindowsController<WindowsController>(windowLayer);
			Container.BindUiSignals(windowLayer);
		}
	}
}
