using System.Collections;
using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;
using Zenject;

namespace SimpleUi.Abstracts
{
	public abstract class UiCollectionBase<TView> : MonoBehaviour, IUiCollectionBase<TView>
		where TView : MonoBehaviour, IUiView
	{
		[SerializeField] protected TView prefab;
		[SerializeField] protected Transform collectionRoot;

		[Inject] protected DiContainer Container;

		protected virtual void OnCreated(TView view)
		{
			view.SetParent(collectionRoot);
			view.Show();
		}

		public abstract void Clear();

		public abstract int Count { get; }

		public abstract IEnumerator<TView> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}