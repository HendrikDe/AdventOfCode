// See https://aka.ms/new-console-template for more information

string trial = "trial.txt";
string trial2 = "trial_part2.txt";
string input = "InputDay05.txt";
string input2 = "InputDay05_part2.txt";

var inputRules = LibraryTools.Tools.GetInput(input);
var inputUpdates = LibraryTools.Tools.GetInput(input2);

var rules = inputRules.Select(r=>r.Split("|").Select(int.Parse).ToArray()).ToList();
var updates = inputUpdates.Select(i => i.Split(",").Select(int.Parse).ToArray()).ToList();

int result=0;
bool ruleViolated = false;
/*foreach (var update in updates)
{
    foreach (var number in update)
    {
        foreach (var rule in rules)
        {
            var numberPos = Array.IndexOf(rule, number);
            if (numberPos != -1 && update.Contains(rule[Math.Abs(numberPos-1)]))
            {
                if (numberPos == 0)
                {
                    if(Array.IndexOf(update, number) > Array.IndexOf(update,rule[Math.Abs(numberPos-1)]))
                    {
                        ruleViolated = true;
                    }
                }
                else
                {
                    if(Array.IndexOf(update, number) < Array.IndexOf(update,rule[Math.Abs(numberPos-1)]))
                    {
                        ruleViolated = true;
                    }
                }
                
                    
            }
        }

        if (ruleViolated)
        {
            break;
        }
    }

    if (ruleViolated)
    {
        ruleViolated = false;
        continue;
    }
    
    result += update[(update.Length-1)/2];
}

Console.WriteLine(result);*/

foreach (var update in updates)
{
    foreach (var number in update)
    {
        foreach (var rule in rules)
        {
            var numberPos = Array.IndexOf(rule, number);
            if (numberPos != -1 && update.Contains(rule[Math.Abs(numberPos-1)]))
            {
                if (numberPos == 0)
                {
                    if(Array.IndexOf(update, number) > Array.IndexOf(update,rule[Math.Abs(numberPos-1)]))
                    {
                        ruleViolated = true;
                    }
                }
                else
                {
                    if(Array.IndexOf(update, number) < Array.IndexOf(update,rule[Math.Abs(numberPos-1)]))
                    {
                        ruleViolated = true;
                    }
                }
                
                    
            }
        }

        if (ruleViolated)
        {
            break;
        }
    }

    if (ruleViolated)
    {
        ruleViolated = false;
        int[] newUpdate = GetSortedUpdate(RelevantRules(rules, update),new List<int>());
        result += newUpdate[(newUpdate.Length-1)/2];
    }
}

Console.WriteLine(result);

static List<int[]> RelevantRules(List<int[]> rules, int[] update)
{
    var result = new List<int[]>();
    foreach (var number in update)
    {
        foreach (var rule in rules)
        {
            var numberPos = Array.IndexOf(rule, number);
            if (numberPos != -1 && update.Contains(rule[Math.Abs(numberPos - 1)]))
            {

                result.Add(rule);

            }
        }
    }

    return result.Distinct().ToList();

}

static int GetMostLeftNumber(List<int[]> list)
{
    int result = list.First().First();
    int index = 0;
    while(index < list.Count)
    {
        if (list[index][1] == result)
        {
            result = list[index][0];
            index = 0;
        }
        index++;
    }
    return result;
    
}

static int[] GetSortedUpdate(List<int[]> rules, List<int> result)
{
    var leftNumber = GetMostLeftNumber(rules);
    result.Add(leftNumber);
    rules = rules.Where(r => r[0] != leftNumber).ToList();
    if (rules.Count > 1)
    {
        result = GetSortedUpdate(rules, result).ToList();
    }

    if (rules.Count == 1)
    {
        result.Add(rules[0][0]);
        result.Add(rules[0][1]);
        
    }
    return result.ToArray();
   
}