using Microsoft.OData.ModelBuilder;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebApplication3.Models
{
    public class IdentityGovernance
    {
        [Contained]
        public PermissionsAnalytics PermissionsAnalytics { get; set; }
    }

    public class PermissionsAnalytics
    {
        public int Id { get; set; }

        [Contained]
        public IList<Finding> Findings { get; set; }
    }

    public class Finding
    {
        public string Id { get; set; }
    }

    public class ExternallyFinding : Finding
    {
        [Contained]
        public AccountsWithAccess AccountsWithAccess { get; set; }
    }

    public abstract class AccountsWithAccess
    {
    }

    public class EnumeratedAccountsWithAccess : AccountsWithAccess
    {
        [AutoExpand]
        [Contained]
        public IList<AuthorizationSystem> Accounts { get; set; }
    }

    public class AuthorizationSystem
    {
        public string AuthorizationSystemId { get; set; }
        public string AuthorizationSystemName { get; set; }
        public string AuthorizationSystemType { get; set; }
    }

    public class AwsAuthorizationSystem : AuthorizationSystem
    {
        public string AwsTitle { get; set; }
    }
    public class AuthorizationSystemTypeAction
    {
        [NotSortable]
        [NotFilterable]
        public string Id { get; set; }

        public short AuthorizationSystemTypeDb { get; set; }
    }
}
