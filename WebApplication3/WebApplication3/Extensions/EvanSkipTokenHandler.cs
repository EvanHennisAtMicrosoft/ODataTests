using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.AspNetCore.OData.Formatter.Value;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData.Edm;

namespace WebApplication3.Extensions
{
    public class EvanSkipTokenHandler : DefaultSkipTokenHandler
    {

        public override Uri GenerateNextPageLink(Uri baseUri, int pageSize, object instance, ODataSerializerContext context)
        {
            //IEdmModel model = context.Model;
            //IEdmStructuredObject obj = instance as IEdmStructuredObject;
            //
            //var val = instance.GetType().GetProperty("Resources").GetValue("externalId");
            //
            //
            //return new Uri("https://evan.com");
            return base.GenerateNextPageLink(baseUri, pageSize, instance, context);
        }
    }
}
