using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string text = File.ReadAllText(@"C:\kobzar.txt");
        string newText = Regex.Replace(text.ToLower(), @"[^\w\s]", "");
        string[] words = newText.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))wordCount[word]++;
            else wordCount.Add(word, 1);
        }
        List<KeyValuePair<string, int>> sortedWords = wordCount.ToList();
        for (int i = 0; i < sortedWords.Count - 1; i++)
        {
            for (int j = i + 1; j < sortedWords.Count; j++)
            {
                if (sortedWords[i].Value < sortedWords[j].Value)
                {
                    var temp = sortedWords[i];
                    sortedWords[i] = sortedWords[j];
                    sortedWords[j] = temp;
                }
            }
        }
        Console.WriteLine("+----+------------+------------------+");
        Console.WriteLine("| №  | Word       | Count            |");
        Console.WriteLine("+----+------------+------------------+");
        for (int i = 0; i < 50 && i < sortedWords.Count; i++)
        {
            string wordNumber = (i + 1).ToString().PadRight(2);
            string word = sortedWords[i].Key.PadRight(10);
            string frequency = sortedWords[i].Value.ToString().PadRight(16);
            Console.WriteLine($"| {wordNumber} | {word} | {frequency} |");
        }
        Console.WriteLine("+----+------------+------------------+");
    }
}
