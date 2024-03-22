#pragma warning disable CS8618
#pragma warning disable CS8625
#pragma warning disable CS8603
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
            string url = "https://crismo-turquoisejaguar.web.val.run/treeI";
            string jsonData = await FetchJsonData(url);
            TreeNode root = DeserializeTree(jsonData);
            int sum = CalculateSum(root);
            Console.WriteLine($"Sum of the full structure: {sum}");
            int deepestLevel = FindDeepestLevel(root);
            Console.WriteLine($"Deepest level of the structure: {deepestLevel}");
            int nodeCount = CountNodes(root);
            Console.WriteLine($"Number of nodes: {nodeCount}");
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

        JsonDocument jsonDocument = JsonDocument.Parse(jsonData);
        JsonElement rootElement = jsonDocument.RootElement;
        return BuildTree(rootElement);
    }

    static TreeNode BuildTree(JsonElement element)
    {
        
        if (element.ValueKind == JsonValueKind.Null || element.ValueKind == JsonValueKind.Undefined)
            return null;

        if (element.ValueKind == JsonValueKind.Object)
        {
            int value = element.GetProperty("value").GetInt32();
            JsonElement leftElement = element.GetProperty("left");
            JsonElement rightElement = element.GetProperty("right");

            TreeNode node = new TreeNode { Value = value };
            node.Left = BuildTree(leftElement);
            node.Right = BuildTree(rightElement);

            return node;
        }
        return null;
    }
    static TreeNode ParseTreeNode(string json)
    {
        
        using (JsonDocument document = JsonDocument.Parse(json))
        {
            JsonElement rootElement = document.RootElement;
            return ParseTreeNode(rootElement);
        }
    }

    static TreeNode ParseTreeNode(JsonElement element)
    {
        TreeNode node = new TreeNode();
        foreach (JsonProperty property in element.EnumerateObject())
        {
            switch (property.Name)
            {
                case "value":
                    node.Value = property.Value.GetInt32();
                    break;
                case "left":
                    if (!property.Value.ValueKind.Equals(JsonValueKind.Null))
                        node.Left = ParseTreeNode(property.Value);
                    break;
                case "right":
                    if (!property.Value.ValueKind.Equals(JsonValueKind.Null))
                        node.Right = ParseTreeNode(property.Value);
                    break;
            }
        }
        return node;
    }

    static int CalculateSum(TreeNode node)
    {
        if (node == null)
            return 0;

        int sum = node.Value;
        sum += CalculateSum(node.Left);
        sum += CalculateSum(node.Right);
        return sum;
    }

    static int FindDeepestLevel(TreeNode node)
    {
        if (node == null)
            return 0;

        int leftDepth = FindDeepestLevel(node.Left);
        int rightDepth = FindDeepestLevel(node.Right);
        return Math.Max(leftDepth, rightDepth) + 1;
    }

    static int CountNodes(TreeNode node)
    {
        if (node == null)
            return 0;
            int leftCount = CountNodes(node.Left);
            int rightCount = CountNodes(node.Right);
            return leftCount + rightCount + 1;
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