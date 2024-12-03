// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var input = LibraryTools.Tools.GetInputString("PuzzleInput03.txt");

string pattern = "mul\\(([0-9]{1,3}),([0-9]{1,3})\\)|do(n't)?\\(\\)";


var regex = new Regex(pattern);

var matches = regex.Matches(input);

int result = 0;
bool ItDoes = true;
foreach (Match match in matches)
{
    if (match.Value == "do()")
    {
        ItDoes = true;
        continue;
    }
    if (match.Value == "don't()")
    {
        ItDoes = false;
        continue;
    }
    if(ItDoes)
    {
        var foo = Int32.Parse(match.Groups[1].Value) * Int32.Parse(match.Groups[2].Value);
        result += foo;
    }
}
Console.WriteLine(result);