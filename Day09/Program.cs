using System.Security.AccessControl;

string trial = "trial.txt";
string input = "PuzzleInput09.txt";


var inputString = LibraryTools.Tools.GetInputString(trial);

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

var filesPartTwo = files.ToList();
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

//part2

List<int> outputList = new (); 
for (int i = filesPartTwo.Count-1; i > 0; i--)
{
    if (filesPartTwo[i].id != -1)
    {
        for (int j = 0; j < i; j++)
        {
            if (filesPartTwo[j].id == -1 && filesPartTwo[j].amount >= filesPartTwo[i].amount)
            {
                filesPartTwo[j]=(filesPartTwo[j].id,filesPartTwo[j].amount-filesPartTwo[i].amount);
                if (filesPartTwo[j].amount == 0)
                {
                    files.RemoveAt(j);
                    i--;
                }
                filesPartTwo.Insert(j,filesPartTwo[i]);
                j++;
                filesPartTwo.RemoveAt(i+1);
            }
        }
    }
}

foreach (var file in filesPartTwo)
{
    outputList.AddRange(Enumerable.Repeat(file.id, file.amount));
}
ulong resultPartTwo = 0;

for (int i = 0; i < outputList.Count; i++)
{
    if (outputList[i] != -1)  resultPartTwo += (ulong)outputList[i]*(ulong)i;
}

Console.WriteLine(resultPartTwo);