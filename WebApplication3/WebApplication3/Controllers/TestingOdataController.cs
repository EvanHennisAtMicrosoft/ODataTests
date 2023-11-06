using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TestingOdataController : ODataController
    {
        [EnableQuery]
        [HttpGet("odata/IdentityGovernance/PermissionsAnalytics/Findings/{key}/WebApplication3.Models.EscalationFinding")]
        public IActionResult GetEscalation()
        {
            EscalationFinding ret = new EscalationFinding()
            {
                Id = "SomeId",
                Actions = new List<AuthorizationSystemTypeAction>()
                {
                    new AuthorizationSystemTypeAction()
                    {
                        Id = "123",
                        AuthorizationSystemTypeDb = 0
                    }
                },
                Resources = new List<AuthorizationSystem>()
                {
                    new AuthorizationSystem()
                    {
                        AuthorizationSystemId = "Id-1",
                        AuthorizationSystemName = "Name-1",
                        AuthorizationSystemType = "Aws"
                    },
                    new AuthorizationSystem()
                    {
                        AuthorizationSystemId = "Id-2",
                        AuthorizationSystemName = "Name-2",
                        AuthorizationSystemType = "Aws"
                    },
                    new AuthorizationSystem()
                    {
                        AuthorizationSystemId = "Id-3",
                        AuthorizationSystemName = "Name-3",
                        AuthorizationSystemType = "Aws"
                    },
                    new AuthorizationSystem()
                    {
                        AuthorizationSystemId = "Id-4",
                        AuthorizationSystemName = "Name-4",
                        AuthorizationSystemType = "Aws"
                    },
                    new AuthorizationSystem()
                    {
                        AuthorizationSystemId = "Id-5",
                        AuthorizationSystemName = "Name-5",
                        AuthorizationSystemType = "Aws"
                    },
                }
            };
            return Ok(ret);
        }
    }
}
