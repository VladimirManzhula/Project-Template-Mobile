using System.Collections.Generic;

namespace SimpleUi.Interfaces
{
	public interface IWindowsController
	{
		Stack<IWindow> Windows { get; }

		void Reset();
	}
}