// See https://aka.ms/new-console-template for more information

var input_rules = LibraryTools.Tools.GetInput("trial.txt");
var input_updates = LibraryTools.Tools.GetInput("trial_part2.txt");

var rules = input_rules.Select(r=>r.Split("|").Select(int.Parse).ToArray()).ToList();
var updates = input_updates.Select(i => i.Split(",").Select(int.Parse).ToArray()).ToList();

int result;
foreach (var update in updates)
{
    foreach (var number in update)
    {
        foreach (var rule in rules)
        {
            var numberPos = Array.IndexOf(rule, number);
            if (numberPos != -1 && update.Contains(rule[Math.Abs(numberPos-1)]))
            {
                
            }
        }
    }
}