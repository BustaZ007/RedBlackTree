using System.Collections.Generic;

namespace RedBlackTree
{
    public class RedBlackTree
    {
        private Node _root;

        private List<Node> _allNodes = new List<Node>();

        public RedBlackTree(int valueRoot)
        {
            _root = new Node(valueRoot);
            _allNodes.Add(_root);
        }

        public void InsertNode(int value){}

        public bool DeleteNode(int value)
        {
            return true;
            
        }
        
        public void LeftRotation(Node node){}
        
        public void RightRotation(Node node){}

        public Node GetRoot() => _root;

        public List<Node> GetAllNodes() => _allNodes;
    }
}