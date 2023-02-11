namespace Profit.Core.Swagger;

public sealed class AddHeaderOperationFilter : IOperationFilter
{
    private readonly string _headerName;
    private readonly string _description;
    private readonly bool _required;

    public AddHeaderOperationFilter(string headerName, string description, bool required)
    {
        _headerName = headerName;
        _description = description;
        _required = required;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
        {
            operation.Parameters = new List<OpenApiParameter>();
        }

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = _headerName,
            In = ParameterLocation.Header,
            Description = _description,
            Required = _required
        });
    }
}
