using AspNet.Identity.MongoDB;

namespace Lost
{
    public class EnsureAuthIndexes
	{
		public static void Exist()
		{
			var context = ApplicationIdentityContext.Create();
			IndexChecks.EnsureUniqueIndexOnUserName(context.Users);
			IndexChecks.EnsureUniqueIndexOnRoleName(context.Roles);
		}
	}
}