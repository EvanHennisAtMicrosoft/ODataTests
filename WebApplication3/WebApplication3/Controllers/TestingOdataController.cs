using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using System.Xml.Linq;
using WebApplication3.Extensions;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TestingOdataController : ODataController
    {
        [EvanEnableQuery(PageSize = 2)]
        [HttpGet("odata/IdentityGovernance/PermissionsAnalytics/Findings/{key}/WebApplication3.Models.EscalationFinding")]
        public IActionResult GetEscalation(ODataQueryOptions<EscalationFinding> opts)
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

            var _odata = Request.ODataFeature();
            ODataQueryContext queryContext = new ODataQueryContext(_odata.Model, typeof(EscalationFinding), _odata.Path);
            var queryOptions = new ODataQueryOptions<EscalationFinding>(queryContext, Request);

            // **********
            // Adding this change will allow me to expand these 2 navigation
            // properties BUT it won't allow the skip token/paging to work.
            // **********
            _odata.SelectExpandClause = BuildCustomExpand(opts,$"actions,resources");

            // *******
            // To get a working copy:
            //  Commented out the above line
            //  Add back [AutoExpand] to the 2 navigation properties
            // *******


            return Ok(ret);
        }

        private SelectExpandClause BuildCustomExpand(ODataQueryOptions queryOptions, string expandProperty)
        {
            // NOTE: For some reason, I needed to `.ToLower()` on the expandProperty that had
            // a capital letter (Accounts and Resources) to get it to work.
            // From what I can tell, if the targetEdmType is null it doesn't check.
            // Changing
            //  TargetEdmType: queryOptions.Context.NavigationSource.EntityType() <-- this is null
            //      to
            //  TargetEdmType: queryOptions.Context.ElementType
            // caused the MappingServiceTests to fail.

            var expandOptions = new SelectExpandQueryOption(null, expandProperty, queryOptions.Context,
                new ODataQueryOptionParser(
                    model: queryOptions.Context.Model,
                    targetEdmType: queryOptions.Context.ElementType,// queryOptions.Context.NavigationSource.EntityType(),
                    targetNavigationSource: queryOptions.Context.NavigationSource,
                    queryOptions: new Dictionary<string, string> { { "$expand", expandProperty } },
                    container: queryOptions.Context.RequestContainer
                    )
                );


            return expandOptions.SelectExpandClause;
        }
    }
}
