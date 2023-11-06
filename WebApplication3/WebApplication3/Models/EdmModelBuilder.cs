using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace WebApplication3.Models
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Singleton<IdentityGovernance>("identityGovernance");
            return builder.GetEdmModel();
        }
    }
}
