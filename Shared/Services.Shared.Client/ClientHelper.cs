using System.Runtime.CompilerServices;

namespace Services.Shared.Client;

public class ClientHelper
{
    public static string GetMethodName([CallerMemberName] string name = null) => name;
    public static string GetClassName([CallerFilePath] string callerClass = null)
    {
        if (callerClass == null) return "";
      
        var parts = callerClass.Replace(".cs", string.Empty).Split("\\");
        return parts[^1];

    }

}