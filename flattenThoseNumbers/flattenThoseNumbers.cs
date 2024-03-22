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
            Console.WriteLine("Nothing here...yet :P");
        }
    }
    static void FlattenArrays(JsonElement element, List<int> result)
    {
        
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
