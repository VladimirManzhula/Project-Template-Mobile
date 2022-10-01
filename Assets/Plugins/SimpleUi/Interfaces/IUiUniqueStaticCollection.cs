namespace SimpleUi.Interfaces
{
	public interface IUiUniqueStaticCollection<TKey, TView> : IUiUniqueCollectionBase<TKey, TView>
		where TView : IUniqueView<TKey>, IUiView
	{
	}
}