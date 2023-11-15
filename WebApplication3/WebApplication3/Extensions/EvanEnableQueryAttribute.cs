using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData.UriParser;
using System.Text;
using System.Xml.Linq;
using WebApplication3.Models;

namespace WebApplication3.Extensions
{
    public class EvanEnableQueryAttribute : EnableQueryAttribute
    {
        public override object ApplyQuery(object entity, ODataQueryOptions queryOptions)
        {
            // These don't match
            var a = queryOptions.SelectExpand;
            var b = queryOptions.Request.ODataFeature().SelectExpandClause;
            var c = queryOptions.Request.ODataFeature();
            
            if (a == null && b != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?$expand=");
                foreach (var itm in b.SelectedItems)
                {
                    if (itm is ExpandedNavigationSelectItem exp)
                    {
                        var name = exp.NavigationSource.Name;
                        sb.Append(name).Append(",");
                    }
                }
                var str = sb.ToString().TrimEnd(',');
            
            
                QueryString qs = new QueryString(str);
                queryOptions.Request.QueryString = qs;
            
                var _odata = queryOptions.Request.ODataFeature();
                ODataQueryContext queryContext = new ODataQueryContext(_odata.Model, entity.GetType()/*typeof(EscalationFinding)*/, _odata.Path);
                var _options = new ODataQueryOptions/*<EscalationFinding>*/(queryContext, queryOptions.Request);
            
                return base.ApplyQuery(entity, _options);
            }

            var ret = base.ApplyQuery(entity, queryOptions);
            return ret;
        }
    }
}
