using System.Linq;
using System.Text;
// PuzzleInput02.txt
var records = LibraryTools.Tools.GetInput("PuzzleInput02.txt");
var recordsList = records.Select(r=>r.Split(" ").Select(s=>Int32.Parse(s)).ToList()).ToList();

int result = 0;
bool works = false;

foreach (List<int> record in recordsList)
{
    for (int j = 0; j < record.Count; j++)
    {
        var recordGutted = record.Where((value,r) => r != j).ToList();
        
        if (LibraryTools.Tools.IsDescOrAsc(recordGutted))
        {
            for (int i = 1; i < recordGutted.Count; i++)
            {
                if (Math.Abs(recordGutted[i] - recordGutted[i - 1]) > 3 || Math.Abs(recordGutted[i] - recordGutted[i - 1]) == 0)
                {
                    break; 
                }
                if (i == recordGutted.Count - 1) works = true;
            }
        }

        if (works)
        {
            result++;
            works = false;
            break;
        }
    }
   
    
}
Console.WriteLine(result);