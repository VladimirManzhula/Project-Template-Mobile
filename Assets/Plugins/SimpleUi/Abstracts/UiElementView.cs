using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public abstract class UiElementView : MonoBehaviour, IUiElement
	{
		public abstract string Name { get; }
		public int Id => gameObject.GetInstanceID();
		public abstract void Highlight();
		public abstract void Reset();
	}
}