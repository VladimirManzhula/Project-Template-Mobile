using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public abstract class UiPooledCollectionBase<TView> : UiCollectionBase<TView>, IUiPooledCollectionBase<TView>
		where TView : MonoBehaviour, IUiView
	{
		private readonly List<TView> _pool = new List<TView>();
		private readonly List<TView> _views = new List<TView>();

		protected TView GetFromPool()
		{
			if (_pool.Count == 0)
				return null;
			var view = _pool[0];
			_pool.RemoveAt(0);
			return view;
		}

		protected override void OnCreated(TView view)
		{
			base.OnCreated(view);
			_views.Add(view);
		}

		public override void Clear()
		{
			while (_views.Count > 0)
			{
				Despawn(_views[0]);
			}
		}

		public override int Count => _views.Count;

		public void Despawn(TView view)
		{
			_views.Remove(view);
			view.Hide();
			OnDespawn(view);
			_pool.Add(view);
		}

		protected virtual void OnDespawn(TView view)
		{
		}

		public override IEnumerator<TView> GetEnumerator() => _views.GetEnumerator();
	}

	public abstract class UiPooledCollection<TView> : UiPooledCollectionBase<TView>, IUiPooledCollection<TView>
		where TView : MonoBehaviour, IUiView
	{
		public TView Create()
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TView> : UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1>
	{
		public TView Create(TParam1 param1)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TView> : UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2>
	{
		public TView Create(TParam1 param1, TParam2 param2)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TView> : UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2, TParam3>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TParam4, TView> : UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView> :
		UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> :
		UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : MonoBehaviour, IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5, param6);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView> :
		UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView>
		where TView : MonoBehaviour, IUiView,
		IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6,
			TParam7 param7)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5, param6, param7);
			OnCreated(view);
			return view;
		}
	}
}