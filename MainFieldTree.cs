namespace ArtificialIntelligence
{
    internal class MainFieldTree
    {
        TreeNode root;
        int number;
        public TreeNode getRoot()
        {
            return root;
        }
        public void setRoot(TreeNode newRoot)
        {
            root = newRoot;
        }
        public void InsertNode(MainField data)
        {
            TreeNode newNode=new TreeNode(data);
            if (getRoot() == null)
            {
                setRoot(newNode);
            }
            else
            {
                TreeNode currentRoot = getRoot();
                TreeNode parentRoot;
                while (true)
                {
                    parentRoot = currentRoot;
                    if (data.name.CompareTo(currentRoot.data.name)<0)
                    {
                        currentRoot = currentRoot.leftChild;
                        if (currentRoot == null)
                        {
                            parentRoot.leftChild = newNode;
                            return;
                        }
                    }
                    else if(data.name.CompareTo(currentRoot.data.name) > 0)
                    {
                        currentRoot=currentRoot.rightChild;
                        if (currentRoot == null)
                        {
                            parentRoot.rightChild = newNode;
                            return;
                        }
                    }

                }
            }
        }
        public void InOrder(TreeNode root)
        {
            if(root == null)
            {
                return;
            }
            InOrder(root.leftChild);
            root.displayNode();
            InOrder(root.rightChild);
        }






        public MainFieldTree()
        {
            this.root = root;
            this.number = number;
        }
    }
    class TreeNode
    {
        public MainField data;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public TreeNode(MainField data)
        {
            this.data = data;
            leftChild = null;
            rightChild = null;
        }
        public void displayNode()
        {
            if (data != null)
            {
                Console.WriteLine("Main Field Name: "+data.name);
                data.subFieldTree.InOrder(data.subFieldTree.root);
                Console.WriteLine(Environment.NewLine);
            }
        }

    }
}
