using BlazorVirtualizationList.Server.Workers;

public static class EndpointAPI
{
    private const string CodeLinesEndpoint = "/get-text/{skip}/{count}";

    public static IEndpointRouteBuilder AddTextProviderApiEndpoints(this IEndpointRouteBuilder app)
    {
        _ = app.MapGet(CodeLinesEndpoint, GetCodeLinesApi);
        return app;
    }

    public static IResult GetCodeLinesApi(int skip, int count, TextProviderStorage textProvider)
    {
        var actualState = textProvider.GetList(skip, count).ToArray();
        return Results.Ok(actualState);
    }

}




