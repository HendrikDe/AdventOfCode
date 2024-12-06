// See https://aka.ms/new-console-template for more information

using Day06;

string trial = "trial.txt";

string input = "PuzzleInput06.txt";


var inputBoard = LibraryTools.Tools.GetInput(input);

var board = inputBoard.Select(x => x.Select(y=>new Cell(y)).ToArray()).ToList(); 
do
{
    try
    {
        var position = (from row in Enumerable.Range(0, board.Count)
            from col in Enumerable.Range(0, board[row].Length)
            where board[row][col].Type == FieldType.Guard
            select (row, col)).First();
       board = GuardStep(board, position);
    }
   catch (InvalidOperationException)
    {
        var result = board.SelectMany(c=>c).ToList().Where(c => c.Visited == true).Count();
        Console.WriteLine(result);
        break;
    }
} while (true);
   
static List<Cell[]> GuardStep(List<Cell[]> board, (int row, int col) position)
{
    //var guard = board.FirstOrDefault(b=>b.FirstOrDefault(c=>c.)
    
    var resultBoard = board;
    var guard = board[position.row][position.col];
    var nextPosition = (position.row + guard.Direction.Item1, position.col + guard.Direction.Item2);
    if ( nextPosition.Item1 >= 0 && nextPosition.Item1 < board.Count && nextPosition.Item2 >= 0 && nextPosition.Item2 < board[nextPosition.Item1].Length)
    {
        while (board[nextPosition.Item1][nextPosition.Item2].Type ==
            FieldType.Obstacle)
        {
            guard.TurnRight();
            nextPosition = (position.row + guard.Direction.Item1, position.col + guard.Direction.Item2);
        }

        var cellGuard = new Cell();
        cellGuard.Type = guard.Type;
        cellGuard.Direction = guard.Direction;
        cellGuard.Visited = guard.Visited;
        cellGuard.LastDirections.Add(guard.Direction);
        resultBoard[nextPosition.Item1][nextPosition.Item2] = cellGuard;
    }
    resultBoard[position.row][position.col].Type = FieldType.Empty;
    return resultBoard;
}