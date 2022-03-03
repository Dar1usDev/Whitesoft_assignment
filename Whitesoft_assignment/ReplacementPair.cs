namespace Whitesoft_assignment
{
    /// <summary>
    /// Structure for replacement.json
    /// </summary>
    internal class ReplacementPair
    {
        private string Key
        {
            get;
        }
        private string Value
        {
            get;
        }

        ReplacementPair(string key, string value)
        {
            Key = key; 
            Value = value;
        }
    }
}
