


string trial = "trial.txt";

string input = "PuzzleInput07.txt";


var inputNumbers = LibraryTools.Tools.GetInput(input);

var dic = inputNumbers
        .Select(line => line.Split(':')) // Split each line into key and value parts
        .ToDictionary(
            parts => ulong.Parse(parts[0].Trim()), // Key: Parse the first part as int
            parts => parts[1]
                .Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries) // Split values by space
                .Select(ulong.Parse) // Convert each value to int
                .ToList() // Convert to List<int>
        );

ulong result = 0;
foreach (KeyValuePair<ulong,List<ulong>> kvp in dic)
{
    if(AddOrMultiplyIsPosssible(kvp.Key, kvp.Value)) result += kvp.Key;
}
Console.WriteLine(result);

int size = 4;

var foo = Combinations(size);

foreach( var a in foo)
{
    foreach (var b in a)
    {
        Console.Write(b);
    }
    Console.WriteLine();

}

static bool AddOrMultiplyIsPosssible(ulong key, List<ulong> numbers)
{
    ulong result = numbers[0];

    int n = numbers.Count - 1; // Size of the array
    bool[] array = new bool[n];

    // Total combinations: 2^n
    int totalCombinations = 1 << n; // 2^n = 1 << n (bitwise shift)

    // Iterate through all combinations
    for (int i = 0; i < totalCombinations; i++)
    {
        // Fill the array based on the bits of the current number
        for (int j = 0; j < n; j++)
        {
            // Check if the j-th bit is set in i
            array[j] = (i & (1 << j)) != 0;

            for (int k = 0; k < numbers.Count - 1; k++)
            {
                result = AddOrMultiply(result, numbers[k + 1], array[k]);
            }

            if (result == key) return true;
            result=numbers[0];
        }


    }

    return false;
}

static List<bool[]> Combinations(int size)
{

    List<bool[]> result = new List<bool[]>();
    bool[] array = new bool[size];

    // Total combinations: 2^n
    int totalCombinations = 1 << size; // 2^n = 1 << n (bitwise shift)

    // Iterate through all combinations
    for (int i = 0; i < totalCombinations; i++)
    {
        // Fill the array based on the bits of the current number
        for (int j = 0; j < size; j++)
        {
            // Check if the j-th bit is set in i
            array[j] = (i & (1 << j)) != 0;
            var temp = array;
            result.Add(temp);

            
        }
    }
    return result;
}


static ulong AddOrMultiply(ulong a, ulong b, bool multiply)
{
    if (multiply) return a * b;
    else return a + b;
}

static ulong AddOrMultiplyList(List<ulong> ulongList, bool[] boolArray)
{
    var result = ulongList[0];

    for (int i = 1; i < ulongList.Count; i++)
    {
        result = AddOrMultiply(result, ulongList[i], boolArray[i-1]);
    }
    return result;
}