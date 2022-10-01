using System;

namespace SimpleUi.Models
{
	public struct Path
	{
		public readonly string Window;
		public readonly string Element;

		public Path(string path)
		{
			var data = path.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
			if (data.Length != 2)
				throw new Exception("[Path] Path to element not correct: " + path);
			Window = data[0];
			Element = data[1];
		}
	}
}