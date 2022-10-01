using System.Collections.Generic;
using SimpleUi.Interfaces;

namespace SimpleUi.Managers
{
	public class UiFilterManager
	{
		private readonly IUiFilter _filter;

		public UiFilterManager(IUiFilter filter)
		{
			_filter = filter;
		}

		public void SetFilter(List<int> objectsId)
		{
			_filter.SetFilter(objectsId);
		}

		public void DropFilter()
		{
			_filter.DropFilter();
		}
	}
}