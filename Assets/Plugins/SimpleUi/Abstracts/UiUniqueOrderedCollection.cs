using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public class UiUniqueOrderedCollectionBase<TKey, TView> : UiCollectionBase<TView>,
		IUiUniqueCollectionBase<TKey, TView>
		where TView : MonoBehaviour, IUiView, IUniqueView<TKey>
	{
		private readonly OrderedDictionary _views = new OrderedDictionary();

		protected override void OnCreated(TView view)
		{
			base.OnCreated(view);
			_views.Add(view.Key, view);
		}

		public override void Clear()
		{
			foreach (var item in _views.Values)
				((TView) item).Destroy();
			_views.Clear();
		}

		public override int Count => _views.Count;

		public TView this[TKey key] => (TView) _views[key];

		public void Remove(TKey key)
		{
			var view = (TView) _views[key];
			view.Destroy();
			_views.Remove(key);
		}

		public bool Contains(TKey key) => _views.Contains(key);

		public override IEnumerator<TView> GetEnumerator() => _views.Values.Cast<TView>().GetEnumerator();
	}

	public class UiUniqueOrderedCollection<TKey, TView>
		: UiUniqueOrderedCollectionBase<TKey, TView>,
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

	public class UiUniqueOrderedCollection<TKey, TParam1, TView>
		: UiUniqueOrderedCollectionBase<TKey, TView>,
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

	public class UiUniqueOrderedCollection<TKey, TParam1, TParam2, TView>
		: UiUniqueOrderedCollectionBase<TKey, TView>,
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

	public class UiUniqueOrderedCollection<TKey, TParam1, TParam2, TParam3, TView>
		: UiUniqueOrderedCollectionBase<TKey, TView>,
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

	public class UiUniqueOrderedCollection<TKey, TParam1, TParam2, TParam3, TParam4, TView>
		: UiUniqueOrderedCollectionBase<TKey, TView>,
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

	public class UiUniqueOrderedCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		: UiUniqueOrderedCollectionBase<TKey, TView>,
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

	public class UiUniqueOrderedCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		: UiUniqueOrderedCollectionBase<TKey, TView>,
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