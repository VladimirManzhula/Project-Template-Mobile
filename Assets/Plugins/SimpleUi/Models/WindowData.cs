using System.Collections.Generic;
using SimpleUi.Interfaces;

namespace SimpleUi.Models
{
	public class WindowData
	{
		public readonly string Name;
		private readonly Dictionary<string, ElementData> _elements = new Dictionary<string, ElementData>();

		public WindowData(string name, IUiElement[] elements)
		{
			Name = name;
			foreach (var element in elements)
				_elements.Add(element.Name, new ElementData(element));
		}

		public IUiElement GetElement(string name)
		{
			return _elements[name].Element;
		}
	}
}