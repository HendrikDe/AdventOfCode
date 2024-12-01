using System.Linq;

var path = Directory.GetCurrentDirectory();
path = Path.GetFullPath(Path.Combine(path,@"..\..\..\", "Puzzle_Input_1.txt")); 
Console.WriteLine(path);
var lines = File.ReadAllLines(path);
var ids = lines.Select(l=>l.Split("  ")).ToList();
var idLeft = ids.Select(l => Int32.Parse(l[0])).ToList();
idLeft.Sort();
var idRight = ids.Select(l => Int32.Parse(l[1])).ToList();
idRight.Sort();
var result= new List<int>();
for (int i = 0; i < idLeft.Count; i++)
{
    var foo = Math.Abs(idRight[i]-idLeft[i]);
    result.Add(foo);
}

foreach (var i in result)
{
    Console.WriteLine(i);
}

var finalResult = result.Sum();
Console.WriteLine(finalResult);
int simScore =0;

foreach (int id in idLeft)
{
    for (int i = 0; i < idRight.Count; i++)
    {
        if (idRight[i] == id)
        {
            simScore += id;
        }
    }
}
Console.WriteLine(simScore);
