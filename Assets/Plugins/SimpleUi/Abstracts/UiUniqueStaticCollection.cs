using System.Collections;
using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public class UiUniqueStaticCollection<TKey, TView> : MonoBehaviour,
		IUiUniqueStaticCollection<TKey, TView>
		where TView : MonoBehaviour, IUiView, IUniqueView<TKey>
	{
		[SerializeField] private List<TView> views;

		private readonly Dictionary<TKey, TView> _views = new Dictionary<TKey, TView>();

		private void Awake()
		{
			foreach (var view in views)
				_views.Add(view.Key, view);
		}

		public void Clear()
		{
			foreach (var item in _views.Values)
				item.Destroy();
			_views.Clear();
			views.Clear();
		}

		public int Count => _views.Count;

		public TView this[TKey key] => _views[key];

		public void Remove(TKey key)
		{
			var view = _views[key];
			view.Destroy();
			_views.Remove(key);
			views.Remove(view);
		}

		public bool Contains(TKey key) => _views.ContainsKey(key);

		public IEnumerator<TView> GetEnumerator() => _views.Values.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}