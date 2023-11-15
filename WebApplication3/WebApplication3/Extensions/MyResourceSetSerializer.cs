using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData.Edm;
using Microsoft.OData;
using Microsoft.AspNetCore.OData.Query.Container;
using System.Collections;
using System.Linq;
using WebApplication3.Models;
using Microsoft.AspNetCore.OData.Formatter;

namespace WebApplication3.Extensions
{
    public class MyResourceSetSerializer : ODataResourceSetSerializer
    {
        public MyResourceSetSerializer(IODataSerializerProvider serializerProvider) : base(serializerProvider)
        {
        }

        //public override async Task WriteObjectInlineAsync(object graph, IEdmTypeReference expectedType, ODataWriter writer,
        //    ODataSerializerContext writeContext)
        //{
        //    int pageSize = writeContext.Request.HttpContext.RequestServices.GetRequiredService<IPageSizeProvider>().PageSize;
        //
        //    if (writeContext.ExpandedResource != null && writeContext.EdmProperty.Name == "Resources" &&
        //        graph is IEnumerable enumerable)
        //    {
        //        IList<object> objects = new List<object>();
        //        int count = 0;
        //        foreach (var item in enumerable)
        //        {
        //            objects.Add(item);
        //            count++;
        //            if (count >= pageSize)
        //            {
        //                break;
        //            }
        //        }
        //
        //        await base.WriteObjectInlineAsync(objects, expectedType, writer, writeContext).ConfigureAwait(false);
        //    }
        //    else
        //    {
        //        await base.WriteObjectInlineAsync(graph, expectedType, writer, writeContext).ConfigureAwait(false);
        //    }
        //}

        public override ODataResourceSet CreateResourceSet(IEnumerable resourceSetInstance, IEdmCollectionTypeReference resourceSetType,
            ODataSerializerContext writeContext)
        {
            ODataResourceSet set = base.CreateResourceSet(resourceSetInstance, resourceSetType, writeContext);

            if (writeContext.ExpandedResource != null && writeContext.EdmProperty.Name == "Resources")
            {
                

                //var itm = resourceSetInstance.GetEnumerator().Current;
                

                //set.NextPageLink = new Uri("http://any");
            }

            return set;
        }
    }

    public class EvanSerial : ODataResourceSerializer
    {
        public EvanSerial(IODataSerializerProvider serializerProvider) : base(serializerProvider)
        {
        }

        public override ODataResource CreateResource(SelectExpandNode selectExpandNode, ResourceContext resourceContext)
        {
            var resource = base.CreateResource(selectExpandNode, resourceContext);
            IEdmStructuredType stype = resourceContext.StructuredType as IEdmStructuredType;
            if (stype != null && stype.TypeKind == EdmTypeKind.Complex)
            {
                resource.TypeAnnotation = new ODataTypeAnnotation(resourceContext.StructuredType.FullTypeName());
            }
            return resource;
        }
    }
}
