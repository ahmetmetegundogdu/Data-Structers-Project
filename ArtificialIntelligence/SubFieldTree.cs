namespace ArtificialIntelligence
{
    internal class SubFieldTree
    {
        public SubFieldTreeNode root;
        int number;
        public void InsertNode(SubField data)
        {
            SubFieldTreeNode newNode=new SubFieldTreeNode(data);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                SubFieldTreeNode current = root;
                SubFieldTreeNode parent;
                while (true)
                {           
                    parent= current;
                    if (data.name.CompareTo(current.data.name)<0)
                    {
                        current = current.leftChild;
                        if (current ==null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }else if (data.name.CompareTo(current.data.name) > 0)
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        public void InOrder(SubFieldTreeNode root)
        {
            if(root == null)
            {
                return;
            }
            InOrder(root.leftChild);
            root.displayNode();
            InOrder(root.rightChild);
        }
        public SubFieldTree()
        {
            this.root = root;
            this.number = number;
        }

        public int GetDepth(SubFieldTreeNode node)
        {
            if (node == null) return 0; 
            int leftDepth = GetDepth(node.leftChild);
            int rightDepth = GetDepth(node.rightChild);
            return 1 + Math.Max(leftDepth, rightDepth);
        }



    }


    class SubFieldTreeNode
    {
        public SubField data;
        public SubFieldTreeNode leftChild;
        public SubFieldTreeNode rightChild;
        public SubFieldTreeNode(SubField data) {
            this.data = data;
            leftChild = null;
            rightChild = null;
        }
        public void displayNode()
        {
            if(data != null)
            {
                Console.WriteLine("  Sub Field Name: "+data.name+
                    "\n  Sub Field Definition: "+data.definition+
                    "\n  Sub Field Applications: "+data.applications+
                    "\n-----------------------------------");
            }   
        }

    }
}
