namespace RattrapDev.DDD.Core
{
	public interface IEntity<T>
	{
		T Identifier { get; }
	}
}

