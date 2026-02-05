using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence
{
    internal class DefinitionWordsTree
    {
        DWTreeNode root;
        int number;
        public DWTreeNode getRoot()
        {
            return root;
        }
        public void setRoot(DWTreeNode newRoot)
        {
            root = newRoot;
        }
        public void InsertNode(DefinitionWords data)
        {
            DWTreeNode newNode = new DWTreeNode(data);
            if (getRoot() == null)
            {
                setRoot(newNode);
            }
            else
            {
                DWTreeNode currentRoot = getRoot();
                DWTreeNode parentRoot;
                while (true)
                {
                    parentRoot = currentRoot;
                    if (data.value.CompareTo(currentRoot.data.value) > 0)
                    {
                        currentRoot = currentRoot.leftChild;
                        if (currentRoot == null)
                        {
                            parentRoot.leftChild = newNode;
                            return;
                        }
                    }
                    else if (data.value.CompareTo(currentRoot.data.value) < 0)
                    {
                        currentRoot = currentRoot.rightChild;
                        if (currentRoot == null)
                        {
                            parentRoot.rightChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        currentRoot.data.counter++;
                        return;
                    }

                }
            }
        }

        

        public void InOrder(DWTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            InOrder(root.leftChild);
            root.displayNode();
            InOrder(root.rightChild);
        }






        public DefinitionWordsTree()
        {
            this.root = root;
            this.number = number;
            
        }
    }
    class DWTreeNode
    {
        public DefinitionWords data;
        public DWTreeNode leftChild;
        public DWTreeNode rightChild;
        public DWTreeNode(DefinitionWords data)
        {
            this.data = data;
            leftChild = null;
            rightChild = null;
        }
        public void displayNode()
        {
            if (data != null)
            {
                Console.WriteLine($"Word: {data.value} \n Counter: {data.counter}");
            }
        }

    }
    class DefinitionWords
    {
        public string value;
        public int counter=1;
        public DefinitionWords(string value)
        {
            this.value = value;
        } 
    }
}
