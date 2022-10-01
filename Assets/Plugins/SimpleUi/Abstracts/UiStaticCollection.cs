using System.Collections;
using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public class UiStaticCollection<TView> : MonoBehaviour, IUiStaticCollection<TView>
		where TView : MonoBehaviour, IUiView
	{
		[SerializeField] protected List<TView> Views;

		public IEnumerator<TView> GetEnumerator() => Views.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public int Count => Views.Count;

		public void Clear() => Views.Clear();

		public TView this[int index] => Views[index];
		
		public void Remove(TView view)
		{
			var indexOf = Views.IndexOf(view);
			RemoveAt(indexOf);
		}

		public void RemoveAt(int index)
		{
			var view = Views[index];
			view.Destroy();
			Views.RemoveAt(index);
		}
	}
}