namespace SimpleUi.Interfaces
{
	public interface IUiPooledCollectionBase<TView> : IUiCollectionBase<TView> where TView : IUiView
	{
		void Despawn(TView view);
	}

	public interface IUiPooledCollection<TView> : IUiPooledCollectionBase<TView>, IUiCollection<TView>
		where TView : IUiView
	{
	}

	public interface IUiPooledCollection<TParam1, TView> : IUiPooledCollectionBase<TView>,
		IUiCollection<TParam1, TView>
		where TView : IUiView, IParametrizedView<TParam1>
	{
	}

	public interface IUiPooledCollection<TParam1, TParam2, TView> : IUiPooledCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2>
	{
	}

	public interface IUiPooledCollection<TParam1, TParam2, TParam3, TView> : IUiPooledCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3>
	{
	}

	public interface IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TView> : IUiPooledCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TParam4, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4>
	{
	}

	public interface IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView> :
		IUiPooledCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5>
	{
	}

	public interface IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
		TView> : IUiPooledCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
	{
	}

	public interface IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
		TView> : IUiPooledCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>
	{
	}
}