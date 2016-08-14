namespace RattrapDev.DDD.Core.Identifier
{
	public abstract class StringIdentifierBase : IdentifierBase<string>
	{
		protected StringIdentifierBase(string id)
			: base(id)
		{
		}
	}
}

