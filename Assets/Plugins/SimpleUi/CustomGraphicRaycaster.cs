using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimpleUi
{
	public class CustomGraphicRaycaster : GraphicRaycaster, IUiFilter
	{
		private readonly List<int> _filter = new List<int>();

		public bool BlockAll { get; set; }

		public void SetFilter(IEnumerable<int> objectsId) => _filter.AddRange(objectsId);

		public void SetFilter(params int[] objectsId) => _filter.AddRange(objectsId);

		public void DropFilter()
		{
			_filter.Clear();
		}

		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			base.Raycast(eventData, resultAppendList);

			if (BlockAll)
			{
				resultAppendList.Clear();
				return;
			}

			if (_filter.Count == 0)
				return;

			resultAppendList.RemoveAll(f => !_filter.Contains(f.gameObject.GetInstanceID()));
		}
	}
}