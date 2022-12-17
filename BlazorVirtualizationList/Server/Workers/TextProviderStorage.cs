using BlazorVirtualizationList.Shared;
using File = System.IO.File;

namespace BlazorVirtualizationList.Server.Workers;

public class TextProviderStorage
{
    private List<GCodeLine> list = new();
    public TextProviderStorage() => ReadFile();


    private async void ReadFile()
    {
        int counter = 0;
        var f = await File.ReadAllLinesAsync("FileSystemResources/LongProgram.nc");
        if (f is not null)
        {
            foreach (var line in f)
            {
                list.Add(new GCodeLine() { LineNumber = counter++, CodeLine = line });
            }
        }
    }

    public List<GCodeLine> GetList(int skip, int count)=> list.Skip(skip).Take(count).ToList();

}