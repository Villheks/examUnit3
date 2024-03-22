
using System.Text.Json;

class AwayWeGo
{
    static async Task Main(string[] args)
    {
         if (args.Contains("-t"))
        {
            TestFetchJsonDataFromFile();
            TestDeserializeTreeFromFile();
        }
        else
        {
            Console.WriteLine("Empty...For the moment :P");
        }
    }
    
    static void TestFetchJsonDataFromFile()
    {
        string filePath = "nodes.json";
        string expectedJson = File.ReadAllText(filePath);
        FakeHttpClient fakeHttpClient = new FakeHttpClient(expectedJson);
        string actualJson = fakeHttpClient.GetStringAsync(null).Result; 
        
        if (actualJson == expectedJson)
        {
            Console.WriteLine("FetchJsonDataFromFile:🟢Passed");
        }
        else
        {
            Console.WriteLine("FetchJsonDataFromFile:🔴Failed");
        }
    }

    static void TestDeserializeTreeFromFile()
    {
        string jsonData = File.ReadAllText("nodes.json"); 
        TreeNode root = DeserializeTree(jsonData);
        if (root != null)
        {
            Console.WriteLine("DeserializeTreeFromFile:🟢Passed");
        }
        else
        {
            Console.WriteLine("DeserializeTreeFromFile:🔴Failed");
        }
    }

    
    static async Task<string> FetchJsonData(string url)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            return await httpClient.GetStringAsync(url);
        }
    }

    static TreeNode DeserializeTree(string jsonData)
    {
        return null;
    }

    static TreeNode BuildTree(JsonElement element)
    {
        return null;
    }
    static TreeNode ParseTreeNode(string json)
    {
        return null;
    }

    static TreeNode ParseTreeNode(JsonElement element)
    {
        return null;
    }

    static int CalculateSum(TreeNode node)
    {
        return 0;
    }

    static int FindDeepestLevel(TreeNode node)
    {
        return 0;
    }

    static int CountNodes(TreeNode node)
    {
        return 0;
    }
}
class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
}
class FakeHttpClient
{
    private string expectedResponse;

    public FakeHttpClient(string expectedResponse)
    {
        this.expectedResponse = expectedResponse;
    }

    public Task<string> GetStringAsync(string url)
    {
        return Task.FromResult(expectedResponse);
    }
}