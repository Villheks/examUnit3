using System.Text.Json;
class FlattenThoseNumbers
{
    static async Task Main(string[] args)
    {
        if (args.Contains("-t"))
        {
            TestFlattenArrays();
        }
        else
        {
           string url = "https://crismo-turquoisejaguar.web.val.run/arrayI"; 
            string json = await GetJsonFromWebsite(url);
            using (JsonDocument document = JsonDocument.Parse(json))
            {
                JsonElement root = document.RootElement;
                List<int> flattened = new List<int>();
                FlattenArrays(root, flattened);
                Console.WriteLine("Flattened array:");
                foreach (int num in flattened)
                {
                    Console.Write(num + ", ");
                }
            }
        }
    }
    static async Task<string> GetJsonFromWebsite(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"Failed to fetch data from {url}. Status code: {response.StatusCode}");
            }
        }
    }


    static void FlattenArrays(JsonElement element, List<int> result)
    {
        if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement child in element.EnumerateArray())
            {
                FlattenArrays(child, result);
            }
        }
        else
        {
            result.Add(element.GetInt32());
        }
    }
    static void TestFlattenArrays()
    {
        string json = "[[1, 2, [3, 4]], [5, [6, 7]]]";
        List<int> expectedResult = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        using (JsonDocument document = JsonDocument.Parse(json))
        {
            JsonElement root = document.RootElement;
            List<int> result = new List<int>();
            FlattenArrays(root, result);
            bool testPassed = AreListsEqual(result, expectedResult);
            Console.WriteLine("Test FlattenArrays: " + (testPassed ? "🟢Passed" : "🔴Failed"));
        }
    }
    static bool AreListsEqual(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }

        return true;
    }
}
