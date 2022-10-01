using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public abstract class UiListCollectionBase<TView> : UiCollectionBase<TView>, IUiListCollectionBase<TView>
		where TView : MonoBehaviour, IUiView
	{
		private readonly List<TView> _views = new List<TView>();

		protected override void OnCreated(TView view)
		{
			base.OnCreated(view);
			_views.Add(view);
		}

		public override void Clear()
		{
			foreach (var item in _views)
				item.Destroy();
			_views.Clear();
		}

		public override int Count => _views.Count;

		public TView this[int index] => _views[index];

		public void Remove(TView view)
		{
			var indexOf = _views.IndexOf(view);
			RemoveAt(indexOf);
		}

		public void RemoveAt(int index)
		{
			var view = _views[index];
			view.Destroy();
			_views.RemoveAt(index);
		}

		public override IEnumerator<TView> GetEnumerator() => _views.GetEnumerator();
	}

	public class UiListCollection<TView> : UiListCollectionBase<TView>, IUiListCollection<TView>
		where TView : MonoBehaviour, IUiView
	{
		public TView Create()
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			OnCreated(view);
			return view;
		}
	}

	public class UiListCollection<TParam1, TView> : UiListCollectionBase<TView>,
		IUiListCollection<TParam1, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1>
	{
		public TView Create(TParam1 param1)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1);
			OnCreated(view);
			return view;
		}
	}

	public class UiListCollection<TParam1, TParam2, TView> : UiListCollectionBase<TView>,
		IUiListCollection<TParam1, TParam2, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2>
	{
		public TView Create(TParam1 param1, TParam2 param2)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2);
			OnCreated(view);
			return view;
		}
	}

	public class UiListCollection<TParam1, TParam2, TParam3, TView> : UiListCollectionBase<TView>,
		IUiListCollection<TParam1, TParam2, TParam3, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2, TParam3>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3);
			OnCreated(view);
			return view;
		}
	}

	public class UiListCollection<TParam1, TParam2, TParam3, TParam4, TView> : UiListCollectionBase<TView>,
		IUiListCollection<TParam1, TParam2, TParam3, TParam4, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4);
			OnCreated(view);
			return view;
		}
	}

	public class UiListCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView> :
		UiListCollectionBase<TView>,
		IUiListCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5);
			OnCreated(view);
			return view;
		}
	}

	public class UiListCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> :
		UiListCollectionBase<TView>,
		IUiListCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5, param6);
			OnCreated(view);
			return view;
		}
	}

	public class UiListCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView> :
		UiListCollectionBase<TView>,
		IUiListCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView>
		where TView : MonoBehaviour, IUiView,
		IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6,
			TParam7 param7)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5, param6, param7);
			OnCreated(view);
			return view;
		}
	}
}