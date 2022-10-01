namespace SimpleUi.Interfaces
{
	public interface IUiElement
	{
		string Name { get; }
		int Id { get; }
		void Highlight();
		void Reset();
	}
}