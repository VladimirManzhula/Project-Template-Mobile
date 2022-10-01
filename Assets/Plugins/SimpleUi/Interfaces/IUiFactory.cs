namespace SimpleUi.Interfaces
{
	public interface IUiFactory
	{
	}

	public interface IUiFactory<TView> : IUiFactory
	{
		TView Create();
	}

	public interface IUiFactory<TParam1, TView> : IUiFactory
		where TView : IParametrizedView<TParam1>
	{
		TView Create(TParam1 param1);
	}

	public interface IUiFactory<TParam1, TParam2, TView> : IUiFactory
		where TView : IParametrizedView<TParam1, TParam2>
	{
		TView Create(TParam1 param1, TParam2 param2);
	}

	public interface IUiFactory<TParam1, TParam2, TParam3, TView> : IUiFactory
		where TView : IParametrizedView<TParam1, TParam2, TParam3>
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3);
	}

	public interface IUiFactory<TParam1, TParam2, TParam3, TParam4, TView> : IUiFactory
		where TView : IParametrizedView<TParam1, TParam2, TParam3, TParam4>
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
	}

	public interface IUiFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TView> : IUiFactory
		where TView : IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5>
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
	}

	public interface IUiFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> : IUiFactory
		where TView : IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);
	}

	public interface IUiFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView> : IUiFactory
		where TView : IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6,
			TParam7 param7);
	}
}