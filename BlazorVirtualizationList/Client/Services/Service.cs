using BlazorVirtualizationList.Shared;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorVirtualizationList.Client.Services;
public class Service
{
    private HttpClient http;
    public Service(HttpClient http)
    {
        this.http= http;
    }

    public async Task<GCodeLine[]> GetItems(ItemsProviderRequest request) 
        => await http.GetFromJsonAsync<GCodeLine[]>("/get-text/" + request.StartIndex + "/" + 100);

}
