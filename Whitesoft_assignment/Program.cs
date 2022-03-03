using System.Net;
using System.Text.Json;
using Whitesoft_assignment;

string dataFileURL = "https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/data.json";
Stream dataStream = WebRequest.Create(dataFileURL).GetResponse().GetResponseStream();
StreamReader dataReader = new StreamReader(dataStream);

string replacementFileURL = "https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/replacement.json";
Stream replacementStream = WebRequest.Create(replacementFileURL).GetResponse().GetResponseStream();
StreamReader replacementReader = new StreamReader(replacementStream);

List<KeyValuePair<string, string>>? replacementPairs = JsonSerializer.Deserialize<List<KeyValuePair<string, string>>?>(replacementStream);

replacementPairs.ForEach(p => Console.WriteLine($"{p.Key} + {p.Value}"));




