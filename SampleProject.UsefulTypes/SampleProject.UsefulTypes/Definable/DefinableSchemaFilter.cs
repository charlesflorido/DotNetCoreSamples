using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SampleProject.UsefulTypes
{
    public class DefinableSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if(context.Type.IsGenericType && context.Type.GetGenericTypeDefinition() == typeof(Definable<>))
            {
                var argumentType = context.Type.GetGenericArguments().First();
                var argumentSchema = context.SchemaGenerator.GenerateSchema(argumentType, context.SchemaRepository);
                var schemaName = $"Definable<{argumentType.FullName}>";

                context.SchemaRepository.AddDefinition(schemaName, argumentSchema);
                context.SchemaRepository.Schemas.TryAdd(argumentType.Name, argumentSchema);
                schema.Type = argumentSchema.Type;
                schema.Reference = new OpenApiReference { Id = schemaName, Type = ReferenceType.Schema };
            }
        }
    }
}

