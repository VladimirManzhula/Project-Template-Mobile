using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public class UiResizableListCollection<TView> : UiCollectionBase<TView>, IUiResizableListCollectionBase<TView>
		where TView : MonoBehaviour, IUiView
	{
		private readonly List<TView> _views = new List<TView>();

		private TView InternalCreate()
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			OnCreated(view);
			return view;
		}

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

		public void Resize(int size)
		{
			if (size == _views.Count)
				return;

			if (size > _views.Count)
			{
				while (_views.Count < size)
					InternalCreate();
			}
			else
			{
				while (_views.Count > size)
					RemoveAt(0);
			}
		}

		public override IEnumerator<TView> GetEnumerator() => _views.GetEnumerator();
	}
}