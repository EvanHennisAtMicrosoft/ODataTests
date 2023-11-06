using Microsoft.OData.ModelBuilder;

namespace WebApplication3.Models
{
    public class EscalationFinding : Finding
    {
        public string Id { get; set; }

        [AutoExpand]
        public List<AuthorizationSystemTypeAction> Actions { get; set; }

        [AutoExpand]
        public List<AuthorizationSystem> Resources { get; set; }
    }
}
