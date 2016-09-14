namespace RattrapDev.DDD.Core
{
	public interface IEntity<TIdentifier>
	{
		TIdentifier Identifier { get; }
	}
}

