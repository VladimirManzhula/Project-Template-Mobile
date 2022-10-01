namespace SimpleUi.Interfaces
{
	public interface IUiUniqueCollectionBase<TKey, TView> : IUiCollectionBase<TView>
		where TView : IUiView, IUniqueView<TKey>
	{
		TView this[TKey key] { get; }

		void Remove(TKey key);

		bool Contains(TKey key);
	}

	public interface IUiUniqueCollection<TKey, TView> : IUiUniqueCollectionBase<TKey, TView>,
		IUiCollection<TKey, TView>
		where TView : IParametrizedView<TKey>, IUiView, IUniqueView<TKey>
	{
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TView> : IUiUniqueCollectionBase<TKey, TView>,
			IUiCollection<TKey, TParam1, TView>
		where TView : IParametrizedView<TKey, TParam1>, IUiView, IUniqueView<TKey>
	{
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TView> : IUiUniqueCollectionBase<TKey, TView>,
			IUiCollection<TKey, TParam1, TParam2, TView>
		where TView : IParametrizedView<TKey, TParam1, TParam2>, IUiView, IUniqueView<TKey>
	{
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TView> : IUiUniqueCollectionBase<TKey, TView>,
			IUiCollection<TKey, TParam1, TParam2, TParam3, TView>
		where TView : IParametrizedView<TKey, TParam1, TParam2, TParam3>, IUiView, IUniqueView<TKey>
	{
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TView> : IUiUniqueCollectionBase<TKey, TView>,
			IUiCollection<TKey, TParam1, TParam2, TParam3, TParam4, TView>
		where TView : IParametrizedView<TKey, TParam1, TParam2, TParam3, TParam4>, IUiView, IUniqueView<TKey>
	{
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView> : IUiUniqueCollectionBase<TKey,
				TView>,
			IUiCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : IParametrizedView<TKey, TParam1, TParam2, TParam3, TParam4, TParam5>, IUiView, IUniqueView<TKey>
	{
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
			TView> : IUiUniqueCollectionBase<TKey, TView>,
			IUiCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : IParametrizedView<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>, IUiView,
		IUniqueView<TKey>
	{
	}
}