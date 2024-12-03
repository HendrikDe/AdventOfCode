namespace LibraryTools;

public class Tools
{
    public static String[] GetInput(string filename)
    {
        var path = Directory.GetCurrentDirectory();
        path = Path.GetFullPath(Path.Combine(path,@"..\..\..\", filename)); 
        
        var lines = File.ReadAllLines(path);
        return lines;
    }
    public static String GetInputString(string filename)
    {
        var path = Directory.GetCurrentDirectory();
        path = Path.GetFullPath(Path.Combine(path,@"..\..\..\", filename));

        var lines = File.ReadAllText(path);
        return lines;
    }

    public static Boolean IsDescOrAsc(List<int> list )
    {
        return (list.SequenceEqual(list.OrderByDescending(l => l).ToList())   || list.SequenceEqual(list.OrderBy(l => l).ToList()));
    } 
}