namespace SimpleUi.Interfaces
{
	public interface IParametrizedView
	{
	}

	public interface IParametrizedView<TParam1> : IParametrizedView
	{
		void Parametrize(TParam1 id);
	}

	public interface IParametrizedView<TParam1, TParam2> : IParametrizedView
	{
		void Parametrize(TParam1 param1, TParam2 param2);
	}

	public interface IParametrizedView<TParam1, TParam2, TParam3> : IParametrizedView
	{
		void Parametrize(TParam1 param1, TParam2 param2, TParam3 param3);
	}

	public interface IParametrizedView<TParam1, TParam2, TParam3, TParam4> : IParametrizedView
	{
		void Parametrize(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
	}

	public interface IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5> : IParametrizedView
	{
		void Parametrize(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
	}

	public interface IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> : IParametrizedView
	{
		void Parametrize(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6);
	}

	public interface IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> : IParametrizedView
	{
		void Parametrize(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6,
			TParam7 param7);
	}
}