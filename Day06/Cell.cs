namespace Day06;
public enum FieldType
{
    Empty,
    Obstacle,
    Guard
};
public static class  EnumDirection
{
    public static readonly (int A, int B ) North = (-1,0);
    public static readonly (int A, int B ) East = (0,1);
    public static readonly (int A, int B ) South = (1,0);
    public static readonly (int A, int B ) West = (0,-1);
    
};

public class Cell
{
    
    public bool Visited{get;set;}
    public FieldType Type{get;set;}
    public (int,int) Direction{get;set;} 
    
    public List<(int,int)> LastDirections{get;set;}  = new List<(int,int)>();


    public Cell(){}
    public Cell(char field)
    {
        LastDirections = new List<(int,int)>();
        Visited = false;
        switch (field)
        
        {
         case '#':
         {
             Type = FieldType.Obstacle;
             break;
         } 
         case '.':
         {
             Type = FieldType.Empty;
             break;
         }
         case '^':
         {
             Type = FieldType.Guard;
             Direction = EnumDirection.North;
             LastDirections.Add(Direction);
             Visited = true;
             break;
         }case '<':
         {
             Type = FieldType.Guard;
             Direction = EnumDirection.West;
             LastDirections.Add(Direction);
             Visited = true;
             break;
         }case '>':
         {
             Type = FieldType.Guard;
             Direction = EnumDirection.East;
             LastDirections.Add(Direction);
             Visited = true;
             break;
         }case 'v':
         {
             Type = FieldType.Guard;
             Direction = EnumDirection.South;
             LastDirections.Add(Direction);
             Visited = true;
             break;
         }
         default: throw new ArgumentException();
        }
    }

    public void TurnRight()
    {
        if (this.Direction==EnumDirection.East) Direction = EnumDirection.South;
        else if (this.Direction==EnumDirection.South) Direction = EnumDirection.West;
        else if (this.Direction==EnumDirection.West) Direction = EnumDirection.North;
        else if (this.Direction == EnumDirection.North) Direction = EnumDirection.East;
    }

    
}