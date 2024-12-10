string trial = "trial.txt";

string smallTrial = "smallTrial.txt";

string input = "PuzzleInput08.txt";


var inputBoard = LibraryTools.Tools.GetInput(input);

var charBoard = inputBoard.Select(x => x.ToCharArray()).ToArray();

var boardDimensionLengths = (charBoard.GetLength(0), charBoard[0].Length);

List<(char,int,int)> antennae = new List<(char,int,int)>();
for (int i = 0; i < charBoard[0].Length; i++)
{
    for (int j = 0; j < charBoard.Length; j++)
    {
        if(charBoard[i][j] != '.') antennae.Add((charBoard[i][j], i, j));
    }
}
List<(int,int)> coordinates = new List<(int,int)>();

var coordinate =(0,0);

var multiplier = 1;

bool works = true;
foreach (var a in antennae)
{
    for (int i = 0; i < antennae.Count; i++)
    {
        works = true;
        if (a != antennae[i] && a.Item1 == antennae[i].Item1)
        {
            coordinates.Add((a.Item2,a.Item3));
            while (works)
            {
                coordinate = GetCoordinates((a.Item2, a.Item3),(antennae[i].Item2, antennae[i].Item3),multiplier);
                if (coordinate.Item1 >= 0 && coordinate.Item2 >= 0 && coordinate.Item1 < boardDimensionLengths.Item1 &&
                    coordinate.Item2 < boardDimensionLengths.Item2)
                {
                    coordinates.Add((coordinate.Item1, coordinate.Item2));
                    multiplier++;
                }
                else
                {
                    multiplier = 1;
                    works = false;
                }
            }
        }
    }
}
coordinates= coordinates.OrderBy(x => x.Item1).ThenBy(x=> x.Item2).ToList();
var result = coordinates.Distinct().Count();


Console.WriteLine($"Number of coordinates: {result}");

static (int, int) GetCoordinates((int, int) a, (int, int) b,int multiplier)
{
    return (a.Item1 - multiplier * (b.Item1 - a.Item1), a.Item2- multiplier * (b.Item2-a.Item2));
}