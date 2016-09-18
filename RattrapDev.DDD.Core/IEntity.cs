namespace RattrapDev.DDD.Core
{
	/// <summary>
	/// Base contract for DDD Entities.
	/// </summary>
	public interface IEntity<TIdentifier>
	{
		TIdentifier Identifier { get; }
	}
}

