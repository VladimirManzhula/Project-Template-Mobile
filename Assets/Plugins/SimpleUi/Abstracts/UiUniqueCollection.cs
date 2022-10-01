using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public abstract class UiUniqueCollectionBase<TKey, TView> : UiCollectionBase<TView>,
		IUiUniqueCollectionBase<TKey, TView>
		where TView : MonoBehaviour, IUiView, IUniqueView<TKey>
	{
		private readonly Dictionary<TKey, TView> _views = new Dictionary<TKey, TView>();

		protected override void OnCreated(TView view)
		{
			base.OnCreated(view);
			_views.Add(view.Key, view);
		}

		public override void Clear()
		{
			foreach (var item in _views.Values)
				item.Destroy();
			_views.Clear();
		}

		public override int Count => _views.Count;

		public TView this[TKey key] => _views[key];

		public void Remove(TKey key)
		{
			var view = _views[key];
			view.Destroy();
			_views.Remove(key);
		}

		public bool Contains(TKey key) => _views.ContainsKey(key);

		public override IEnumerator<TView> GetEnumerator() => _views.Values.GetEnumerator();
	}

	public class UiUniqueCollection<TKey, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TKey>, IUniqueView<TKey>
	{
		public TView Create(TKey key)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(key);
			OnCreated(view);
			return view;
		}
	}

	public class UiUniqueCollection<TKey, TParam1, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TView>
		where TView : MonoBehaviour, IUiView, IUniqueView<TKey>, IParametrizedView<TKey, TParam1>
	{
		public TView Create(TKey key, TParam1 param1)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(key, param1);
			OnCreated(view);
			return view;
		}
	}

	public class UiUniqueCollection<TKey, TParam1, TParam2, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TKey, TParam1, TParam2>, IUniqueView<TKey>
	{
		public TView Create(TKey key, TParam1 param1, TParam2 param2)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(key, param1, param2);
			OnCreated(view);
			return view;
		}
	}

	public class UiUniqueCollection<TKey, TParam1, TParam2, TParam3, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TKey, TParam1, TParam2, TParam3>, IUniqueView<TKey>
	{
		public TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(key, param1, param2, param3);
			OnCreated(view);
			return view;
		}
	}

	public class UiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TKey, TParam1, TParam2, TParam3, TParam4>,
		IUniqueView<TKey>
	{
		public TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(key, param1, param2, param3, param4);
			OnCreated(view);
			return view;
		}
	}

	public class UiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : MonoBehaviour, IUiView, IUniqueView<TKey>,
		IParametrizedView<TKey, TParam1, TParam2, TParam3, TParam4, TParam5>
	{
		public TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(key, param1, param2, param3, param4, param5);
			OnCreated(view);
			return view;
		}
	}

	public class UiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : MonoBehaviour, IUiView, IUniqueView<TKey>,
		IParametrizedView<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
	{
		public TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(key, param1, param2, param3, param4, param5, param6);
			OnCreated(view);
			return view;
		}
	}
}