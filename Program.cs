using ArtificialIntelligence;
using System.Text.Json.Nodes;

internal class Program
{
    static MainFieldTree tree = new MainFieldTree();
    static void readJSON()
    {
        MainFieldTree mainFieldTree = new MainFieldTree();
        string jsonText = File.ReadAllText("AI_Subfields.json");
        JsonArray root = JsonNode.Parse(jsonText).AsArray();
        foreach (JsonNode mainField in root)
        {

            string mainFieldName = mainField["name"].ToString();
            JsonArray subfields = mainField["subfields"].AsArray();
            SubFieldTree subFieldTree = new SubFieldTree();
            foreach (JsonNode subfield in subfields)
            {
                string subfieldName = subfield["name"].ToString();
                string subfieldDefinition = subfield["definition"].ToString();
                string subfieldApplications = subfield["applications"].ToString();
                SubField subField = new SubField(subfieldName, subfieldDefinition, subfieldApplications);
                subFieldTree.InsertNode(subField);
            }
            MainField mainFieldObject = new MainField(mainFieldName, subFieldTree);
            mainFieldTree.InsertNode(mainFieldObject);
        }
        tree = mainFieldTree;
    }
    static DefinitionWordsTree wordsTree = new DefinitionWordsTree();
    static void generateWordTree(SubFieldTreeNode root)
    {
        if (root == null)
        {
            return;
        }
        char[] splitChars = { ' ', '.', ',', ';', ':', '!', '?', '-', '\u2013', '(', ')', '[', ']' };

        string[] arr = root.data.definition.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in arr)
        {
            DefinitionWords word = new DefinitionWords(s.Trim(splitChars).ToLower());
            wordsTree.InsertNode(word);
        }

        generateWordTree(root.leftChild);
        generateWordTree(root.rightChild);
    }
    private static void Main(string[] args)
    {
        readJSON();

        tree.InOrder(tree.getRoot());
        int maxDepth = -1;
        int CountNodes(SubFieldTreeNode node)
        {
            if (node == null) return 0;
            return 1 + CountNodes(node.leftChild) + CountNodes(node.rightChild);
        }

        int maxNodeCount = 0;
        List<SubFieldTree> deepestTreeList = new List<SubFieldTree>();

        void InOrderForWordsAndNodeCount(TreeNode root)
        {
            if (root == null) return;

            InOrderForWordsAndNodeCount(root.leftChild);

            int nodeCount = CountNodes(root.data.subFieldTree.root);

            if (nodeCount > maxNodeCount)
            {
                maxNodeCount = nodeCount;
                deepestTreeList.Clear();
                deepestTreeList.Add(root.data.subFieldTree);
            }
            else if (nodeCount == maxNodeCount)
            {
                if (!deepestTreeList.Contains(root.data.subFieldTree))
                    deepestTreeList.Add(root.data.subFieldTree);
            }

            if (root.data.subFieldTree.root != null)
                generateWordTree(root.data.subFieldTree.root);

            InOrderForWordsAndNodeCount(root.rightChild);
        }

        void InOrderForDepthTree(SubFieldTreeNode root)
        {
            if (root == null) return;

            InOrderForDepthTree(root.leftChild);
            Console.WriteLine(root.data.name);
            InOrderForDepthTree(root.rightChild);
        }

        InOrderForWordsAndNodeCount(tree.getRoot());

        Console.WriteLine("THE DEEPEST SUBFIELDTREES ");
        foreach (SubFieldTree sfTree in deepestTreeList)
        {
            Console.WriteLine("-Main Field:" + sfTree.root.data.name + "-Count:" + maxNodeCount + " -");
            InOrderForDepthTree(sfTree.root);
            Console.WriteLine("");
        }

        Console.WriteLine("\n--WORDS TREE--");
        wordsTree.InOrder(wordsTree.getRoot());
    }
}