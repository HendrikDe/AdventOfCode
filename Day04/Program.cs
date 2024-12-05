using System.Linq;



var input = LibraryTools.Tools.GetInput("PuzzleInput04.txt");
int counter = 0;

for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        if (input[i][j] == 'X')
        {
            foreach (var (k,l) in FindLetter(input, i, j,'M'))
            {
                var (aRow, aColumn) = FindLetterInDirection(input, k, l, k - i, l - j, 'A');
                if ( (aRow,aColumn) != (-1, -1))
                {
                    if (FindLetterInDirection(input, aRow, aColumn, aRow - k, aColumn - l, 'S')!=(-1, -1)) counter++;
                }
            }
        }
    }
}
Console.WriteLine(counter);

counter = 0;
for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        if (input[i][j] == 'A')
        {
            var mPos = FindLettersInXShape(input, i, j, 'M');
            if (mPos.Count() == 2)
            {
                if((mPos[0].Item1.Equals(mPos[1].Item1) || mPos[0].Item2.Equals(mPos[1].Item2))  && FindLettersInXShape(input,i,j,'S').Count() == 2) counter++; 
            }
        }
    }
}

Console.WriteLine(counter);

static List<(int,int)> FindLettersInXShape(string[] input, int rowIndex, int columnIndex,char letter)
{
    List<(int,int)> result = new List<(int,int)>();
    for (int i = rowIndex - 1; i <= rowIndex + 1; i+=2)
    {
        for (int j = columnIndex - 1; j <= columnIndex + 1; j+=2)
        {
            if(i == rowIndex && j == columnIndex) continue;
            if(j < 0 || j >= input.Length||i < 0 || i >= input[j].Length) continue;
            if (input[i][j] == letter)
            {
                result.Add((i, j));
            }
        }
    }
    return result;
    
}

static List<(int,int)> FindLetter(string[] input, int rowIndex, int columnIndex,char letter)
{
    List<(int,int)> result = new List<(int,int)>();
    for (int i = rowIndex - 1; i <= rowIndex + 1; i++)
    {
        for (int j = columnIndex - 1; j <= columnIndex + 1; j++)
        {
            if(i == rowIndex && j == columnIndex) continue;
            if(j < 0 || j >= input.Length||i < 0 || i >= input[j].Length) continue;
            if (input[i][j] == letter)
            {
                result.Add((i, j));
            }
        }
    }
    return result;
}
static (int,int) FindLetterInDirection(string[] input, int rowIndex, int columnIndex,int rowDirection, int columnDirection
,char letter)
{
    (int,int) result = new();
    if((rowIndex+rowDirection) < 0 || (rowIndex+rowDirection)>= input.Length||(columnIndex + columnDirection) < 0 || (columnIndex + columnDirection) >= input[(rowIndex+rowDirection)].Length) return (-1,-1);
    if (input[rowIndex + rowDirection][columnIndex+columnDirection] == letter)
    {
        result = (rowIndex + rowDirection, columnIndex + columnDirection);
    }
    else result = (-1,-1);
    return result;
}