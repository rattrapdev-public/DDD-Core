namespace RattrapDev.DDD.Block.Identifier
{
	/// <summary>
	/// Base string <see cref="IdentifierBase{string}"></see> implementation. /> 
	/// </summary>
	public abstract class StringIdentifierBase : IdentifierBase<string>
	{
		protected StringIdentifierBase(string id)
			: base(id)
		{
		}
	}
}

