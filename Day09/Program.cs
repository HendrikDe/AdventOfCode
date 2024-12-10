using System.Security.AccessControl;

string trial = "trial.txt";
string input = "PuzzleInput09.txt";


var inputString = LibraryTools.Tools.GetInputString(input);

List<(int id,int amount)> files = new List<(int,int)>();
var counter = 0;
for (int i = 0; i < inputString.Length; i++)
{
    if (i % 2 == 0)
    {
        files.Add((counter, Int32.Parse(inputString[i].ToString()) ));
        counter++;
    }
    else files.Add((-1, Int32.Parse(inputString[i].ToString())));
}
List<int> output = new ();
for (int i = 0; i < files.Count; i++)
{
    
    if (files[i].id != -1)
    {
        
        output.AddRange(Enumerable.Repeat(files[i].id, files[i].amount));
    }
    else
    {
        for (int j = files[i].amount; j > 0; j--)
        {
            while (files[^1].amount == 0 || files[^1].id == -1)
            {
                files.RemoveAt(files.Count - 1);
            }

            if (i == files.Count)
            {
                break;
            }
            output.Add(files.Last().Item1);
            files[^1]=(files[^1].Item1,files[^1].Item2-1);
        }
    }
}
ulong result = 0;

for (int i = 0; i < output.Count; i++)
{
    result += (ulong)output[i]*(ulong)i;
}

Console.WriteLine(result);