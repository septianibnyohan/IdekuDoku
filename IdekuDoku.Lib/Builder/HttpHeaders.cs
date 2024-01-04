using System.Collections;

namespace IdekuDoku.Lib.Builder;

public class HttpHeaders : IEnumerable<KeyValuePair<string, string>>
{
    private readonly Dictionary<string, string> headers = new Dictionary<string, string>();

    public void Add(string key, string value)
    {
        headers[key] = value; // Use key to replace existing values
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return headers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}