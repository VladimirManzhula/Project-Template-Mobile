using System.Collections.Generic;

namespace SimpleUi.Interfaces
{
	public interface IUiCollectionBase<TView> : IEnumerable<TView>
		where TView : IUiView
	{
		int Count { get; }
		
		void Clear();
	}

	public interface IUiCollection<TView> : IUiCollectionBase<TView>, IUiFactory<TView>
		where TView : IUiView
	{
	}

	public interface IUiCollection<TParam1, TView> : IUiCollectionBase<TView>,
		IUiFactory<TParam1, TView>
		where TView : IUiView, IParametrizedView<TParam1>
	{
	}

	public interface IUiCollection<TParam1, TParam2, TView> : IUiCollectionBase<TView>,
		IUiFactory<TParam1, TParam2, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2>
	{
	}

	public interface IUiCollection<TParam1, TParam2, TParam3, TView> : IUiCollectionBase<TView>,
		IUiFactory<TParam1, TParam2, TParam3, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3>
	{
	}

	public interface IUiCollection<TParam1, TParam2, TParam3, TParam4, TView> : IUiCollectionBase<TView>,
		IUiFactory<TParam1, TParam2, TParam3, TParam4, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4>
	{
	}

	public interface IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView> : IUiCollectionBase<TView>,
		IUiFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5>
	{
	}

	public interface IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
		TView> : IUiCollectionBase<TView>,
		IUiFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
	{
	}

	public interface IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
		TView> : IUiCollectionBase<TView>,
		IUiFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView>
		where TView : IUiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>
	{
	}
}