using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Capstone.HPTY.API.AppStarts
{
    public class SwaggerGroupOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var controllerActionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor == null) return;

            var groupAttribute = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute<SwaggerGroupAttribute>();

            if (groupAttribute != null)
            {
                // Set or replace the tag with the group name
                operation.Tags.Clear();
                operation.Tags.Add(new OpenApiTag { Name = groupAttribute.GroupName });
            }
            else
            {
                // For controllers without a group, ensure they have a tag based on controller name
                // This will make them appear below the grouped ones
                if (operation.Tags.Count == 0)
                {
                    var controllerName = controllerActionDescriptor.ControllerName;
                    operation.Tags.Add(new OpenApiTag { Name = controllerName });
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class SwaggerGroupAttribute : Attribute
    {
        public string GroupName { get; }
        public int Order { get; }

        public SwaggerGroupAttribute(string groupName, int order = 0)
        {
            GroupName = groupName;
            Order = order;
        }
    }

    public class SwaggerGroupTagsFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Create ordered tags list
            var orderedTags = new List<OpenApiTag>();

            // Add important group first
            var importantTag = new OpenApiTag { Name = "Auth" };
            orderedTags.Add(importantTag);

            // Add other tags that are already in the document
            foreach (var tag in swaggerDoc.Tags)
            {
                if (tag.Name != "Auth")
                {
                    orderedTags.Add(tag);
                }
            }

            // Replace tags with ordered list
            swaggerDoc.Tags = orderedTags;
        }
    }

}
