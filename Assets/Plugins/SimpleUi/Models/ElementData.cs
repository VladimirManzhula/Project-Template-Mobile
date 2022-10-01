using SimpleUi.Interfaces;

namespace SimpleUi.Models
{
	public class ElementData
	{
		public readonly string Name;
		public readonly IUiElement Element;

		public ElementData(IUiElement element)
		{
			Name = element.Name;
			Element = element;
		}
	}
}