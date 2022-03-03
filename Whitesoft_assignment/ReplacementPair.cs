using System.Text.Json.Serialization;

namespace Whitesoft_assignment
{
    /// <summary>
    /// Structure for replacement.json
    /// </summary>
    internal class ReplacementPair
    {
        [JsonPropertyName("replacement")]
        public string Key
        {
            get;
        }

        [JsonPropertyName("source")]
        public string Value
        {
            get;
        }

        public ReplacementPair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString() => $"{Key} {Value ?? "null"}";
    }
}