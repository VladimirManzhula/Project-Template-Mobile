namespace SimpleUi.Interfaces
{
	public interface IUiResizableListCollectionBase<TView> : IUiListCollectionBase<TView> where TView : IUiView
	{
		void Resize(int size);
	}
}