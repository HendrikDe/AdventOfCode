// See https://aka.ms/new-console-template for more information

using Day06;

string trial = "trial.txt";

string input = "PuzzleInput06.txt";


var inputBoard = LibraryTools.Tools.GetInput(input);

var board = inputBoard.Select(x => x.Select(y=>new Cell(y)).ToArray()).ToList(); 
board = RunBoard(board);
var counter = 0;
var countRun = 1.0;
for (int i = 0; i < board.Count; i++)
{
    for (int j = 0; j < board[i].Length; j++)
    {
        if (board[i][j].Visited && board[i][j].Type != FieldType.Guard)
        {
            var copyBoard = inputBoard.Select(x => x.Select(y=>new Cell(y)).ToArray()).ToList(); 
            copyBoard[i][j].Type = FieldType.Obstacle;
            if(RunBoard(copyBoard)==null) counter++;
            Console.Clear();
            for (var k = 0; k <= countRun / 4977 * 100; k++) Console.Write("|");
            for (var l = 0; l <= (4977 - countRun) / 4977 * 100; l++) Console.Write(".");
            Console.WriteLine();
            Console.WriteLine(counter + "/" + countRun);
            countRun++;
        }
    }
}

Console.WriteLine(counter);

List<Cell[]> RunBoard(List<Cell[]> cellsList)
{
    {
        do
        {
            try
            {
                var position = (from row in Enumerable.Range(0, cellsList.Count)
                    from col in Enumerable.Range(0, cellsList[row].Length)
                    where cellsList[row][col].Type == FieldType.Guard
                    select (row, col)).First();
                cellsList = GuardStep(cellsList, position);
                if (cellsList == null)
                {
                    return null;
                }
            }
            catch (InvalidOperationException)
            {
                
                break;
            }
        } while (true);

        return cellsList;
    }

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
            if (board[nextPosition.Item1][nextPosition.Item2].LastDirections.Contains(guard.Direction))
            {
                return null;
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
}