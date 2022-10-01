using System.Collections.Generic;

namespace SimpleUi.Interfaces
{
	public interface IUiFilter
	{
		bool BlockAll { get; set; }

		void SetFilter(IEnumerable<int> objectsId);
		void SetFilter(params int[] objectsId);
		void DropFilter();
	}
}