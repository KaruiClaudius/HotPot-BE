using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Capstone.HPTY.API.AppStarts
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();
                schema.Type = "string";
                schema.Description += "\n\nPossible values:\n";

                Enum.GetNames(context.Type)
                    .ToList()
                    .ForEach(name => schema.Description += $"\n- {name}");
            }
        }
    }
}
