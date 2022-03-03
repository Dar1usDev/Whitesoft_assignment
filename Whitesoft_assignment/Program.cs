using System.Text.Json;
using Whitesoft_assignment;

HttpClient client = new();
Stream response;
List<ReplacementPair>? replacementPairs = new();
List<string>? data = new();

try
{
    response = await client.GetStreamAsync("https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/replacement.json");
    replacementPairs = JsonSerializer.Deserialize<List<ReplacementPair>>(response);

    response = await client.GetStreamAsync("https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/data.json");
    data = JsonSerializer.Deserialize<List<string>>(response);
}
catch (HttpRequestException e)
{
    Console.WriteLine(e.Message);
}

HashSet<string> toDelete = new HashSet<string>();

for (int j = 0; j < data.Count; j++)
{
    for (int i = replacementPairs.Count - 1; i >= 0; i--)
        if (data[j].Contains(replacementPairs[i].Key))
        {
            if (replacementPairs[i].Value == null)
                toDelete.Add(replacementPairs[i].Key);
            else
                data[j] = data[j].Replace(replacementPairs[i].Key, replacementPairs[i].Value);
            break;
        }
}

for (int i = 0; i < toDelete.Count; i++)
    while (data.Contains(toDelete.ElementAt(i)))
        data.Remove(toDelete.ElementAt(i));

string resultPath = Environment.CurrentDirectory;
resultPath = resultPath.Remove(resultPath.IndexOf("\\bin"));
Console.WriteLine(resultPath);

using (FileStream fs = new($"{resultPath}\\result.json", FileMode.Create))
{
    var options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    await JsonSerializer.SerializeAsync<List<string>>(fs, data, options);
}