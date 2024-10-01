using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace WebApplication2
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost("test")]
        public async Task<IActionResult> PostTest([FromBody] XmlPlaceholder? xmlPlaceholder = null)
        {
            return Ok();
        }
    }

    public class XmlPlaceholder : IEndpointParameterMetadataProvider
    {
        public static void PopulateMetadata(ParameterInfo parameter, EndpointBuilder builder)
        {
            builder.Metadata.Add(new AcceptsMetadata(["application/xml", "text/xml"], typeof(XmlPlaceholder)));
        }
    }
}
