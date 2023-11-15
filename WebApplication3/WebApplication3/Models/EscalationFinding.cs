using Microsoft.OData.ModelBuilder;
using System.Runtime.Serialization;

namespace WebApplication3.Models
{
    public class EscalationFinding : Finding
    {
        public string Id { get; set; }

        //[AutoExpand]
        public List<AuthorizationSystemTypeAction> Actions { get; set; }

        //[AutoExpand]
        public List<AuthorizationSystem> Resources { get; set; }
    }


    public class  CustomList : List<AuthorizationSystem>
    {
        public string CustomUrl { get; set; }
    }

    public class CustomAuthorizationSystem : AuthorizationSystem
    {
        [IgnoreDataMember]
        public string Url { get; set; }
    }
}
