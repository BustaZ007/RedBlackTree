using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace RedBlackTree
{
    public class RedBlackTree
    {
        private Node _root;

        private List<Node> _allNodes = new List<Node>();

        public RedBlackTree(int valueRoot)
        {
            _root = new Node(valueRoot);
            _root.Repaint();
            _allNodes.Add(_root);
        }

        public bool InsertNode(int value)
        {
            if (_allNodes.Select(n => n.GetValue()).Contains(value))
                return false;
            Node currentNode = _root;
            while (!currentNode.IsNil())
            {
                if (value > currentNode.GetValue())
                {
                    currentNode = currentNode.GetRight();
                }
                else
                {
                    currentNode = currentNode.GetLeft();
                }
            }
            currentNode.GetParent().AddChild(value);
            Node newNode = currentNode.GetParent().GetLeft().GetValue() == value
                ? currentNode.GetParent().GetLeft()
                : currentNode.GetParent().GetRight();
            _allNodes.Add(newNode);
            InsertCase1(newNode);
            
            return true;
        }

        public bool DeleteNode(int value)
        {
            if (!_allNodes.Select(n => n.GetValue()).Contains(value))
                return false;
            Node deleteNode = FindNodeByValue(value);
            Node replaceNode;
            if (!deleteNode.GetLeft().IsNil() && !deleteNode.GetRight().IsNil())
            {
                replaceNode = deleteNode.GetLeft();
                
                while (!replaceNode.GetRight().IsNil())
                    replaceNode = replaceNode.GetRight();
                
                deleteNode.SetValue(replaceNode.GetValue());
                
                if (replaceNode.GetLeft().IsNil() && replaceNode.GetRight().IsNil())
                    DeleteWithoutChild(replaceNode);
                else
                    DeleteOneChild(replaceNode);
            }
            else if(deleteNode.GetLeft().IsNil() && deleteNode.GetRight().IsNil())
                DeleteWithoutChild(deleteNode);
            else
                DeleteOneChild(deleteNode);

            _allNodes.Remove(deleteNode);
            return true;
        }

        private Node FindNodeByValue(int value) => 
            _allNodes.Find(n => n.GetValue() == value);
        
        private void InsertCase1(Node node)
        {
            if(node.GetParent() == null)
                node.Repaint();
            else
                InsertCase2(node);
        }

        private void InsertCase2(Node node)
        {
            if (node.GetParent().GetColor() == Color.Black)
                return;
            InsertCase3(node);
        }

        private void InsertCase3(Node node)
        {
            Node uncle = GetUncle(node);
            if (uncle != null && uncle.GetColor() == Color.Red)
            {
                node.GetParent().Repaint();
                uncle.Repaint();
                Node g = GetGrandparent(node);
                g.Repaint();
                InsertCase1(g);
            }
            else
                InsertCase4(node);
        }

        private void InsertCase4(Node node)
        {
            Node g = GetGrandparent(node);
            if (node == node.GetParent().GetRight() && node.GetParent() == g.GetLeft())
            {
                LeftRotation(node.GetParent());
                node = node.GetLeft();
            }
            else if (node == node.GetParent().GetLeft() &&  node.GetParent() == g.GetRight())
            {
                RightRotation(node.GetParent());
                node = node.GetRight();
            }
            InsertCase5(node);
        }

        private void InsertCase5(Node node)
        {
            Node g = GetGrandparent(node);
            node.GetParent().Repaint();
            g.Repaint();
            if(node == node.GetParent().GetLeft() && node.GetParent() == g.GetLeft())
                RightRotation(g);
            else
                LeftRotation(g);
        }
        
        private Node GetGrandparent(Node node) =>
            node != null && node.GetParent() != null
                ? node.GetParent().GetParent()
                : null;

        private Node GetUncle(Node node)
        {
            Node g = GetGrandparent(node);
            if (g == null)
                return null;
            return node.GetParent() == g.GetLeft()
                ? g.GetRight()
                : g.GetLeft();
        }

        private Node GetBrother(Node node) =>
            node == node.GetParent().GetLeft()
                ? node.GetParent().GetRight()
                : node.GetParent().GetLeft();

        private void ReplaceNode(Node node, Node child)
        {
            child.SetParent(node.GetParent());
            if(node == node.GetParent().GetLeft())
                node.GetParent().SetLeft(child);
            else
                node.GetParent().SetRight(child);
        }

        private void DeleteOneChild(Node node)
        {
            Node child = node.GetRight().IsNil() ? node.GetLeft() : node.GetRight();
            ReplaceNode(node, child);
            if (node.GetColor() == Color.Black)
                if (child.GetColor() == Color.Red)
                    child.Repaint();
                else
                    DeleteCase1(child);
        }

        private void DeleteWithoutChild(Node node)
        {
            Node p = node.GetParent();
            if(p.GetLeft() == node)
                p.SetLeft(new Node(null, p));
            else
                p.SetRight(new Node(null, p));
        }

        private void DeleteCase1(Node node)
        {
            if (node.GetParent() == null)
                DeleteCase2(node);
        }
        
        private void DeleteCase2(Node node)
        {
            Node s = GetBrother(node);

            if (s.GetColor() == Color.Red)
            {
                node.GetParent().Repaint();
                s.Repaint();
                if(node == node.GetParent().GetLeft())
                    LeftRotation(node.GetParent());
                else
                    RightRotation(node.GetParent());
            }
            DeleteCase3(node);
        }
        
        private void DeleteCase3(Node node)
        {
            Node s = GetBrother(node);

            if (node.GetParent().GetColor() == Color.Black && s.GetColor() == Color.Black &&
                s.GetLeft().GetColor() == Color.Black && s.GetRight().GetColor() == Color.Black)
            {
                s.Repaint();
                DeleteCase1(node.GetParent());
            }
            else
                DeleteCase4(node);
        }
        
        private void DeleteCase4(Node node)
        {
            Node s = GetBrother(node);

            if (node.GetParent().GetColor() == Color.Red && s.GetColor() == Color.Black &&
                s.GetLeft().GetColor() == Color.Black && s.GetRight().GetColor() == Color.Black)
            {
                s.Repaint();
                node.GetParent().Repaint();
            }
            else
                DeleteCase5(node);
        }
        
        private void DeleteCase5(Node node)
        {
            Node s = GetBrother(node);

            if (s.GetColor() == Color.Black)
            {
                if (node == node.GetParent().GetLeft() && s.GetRight().GetColor() == Color.Black &&
                    s.GetLeft().GetColor() == Color.Red)
                {
                    s.Repaint();
                    s.GetLeft().Repaint();
                    RightRotation(s);
                }
                else if (node == node.GetParent().GetRight() && s.GetLeft().GetColor() == Color.Black &&
                         s.GetRight().GetColor() == Color.Red)
                {
                    s.Repaint();
                    s.GetRight().Repaint();
                    LeftRotation(s);
                }
            }
            DeleteCase6(node);
        }
        
        private void DeleteCase6(Node node)
        {
            Node s = GetBrother(node);
            
            s.SetColor(node.GetParent().GetColor());
            node.GetParent().SetColor(Color.Black);
            if (node == node.GetParent().GetLeft())
            {
                s.GetRight().SetColor(Color.Black);
                LeftRotation(node.GetParent());
            }
            else
            {
                s.GetLeft().SetColor(Color.Black);
                RightRotation(node.GetParent());
            }
        }
        public void LeftRotation(Node node)
        {
            Node pivot = node.GetRight();
            pivot.SetParent(node.GetParent());
            if (node.GetParent() != null)
                if(node.GetParent().GetLeft() == node)
                    node.GetParent().SetLeft(pivot);
                else
                    node.GetParent().SetRight(pivot);
            
            node.SetRight(pivot.GetLeft());
            if(pivot.GetLeft() != null)
                pivot.GetLeft().SetParent(node);
            
            node.SetParent(pivot);
            pivot.SetLeft(node);
        }

        public void RightRotation(Node node)
        {
            Node pivot = node.GetLeft();
            pivot.SetParent(node.GetParent());
            if (node.GetParent() != null)
                if(node.GetParent().GetLeft() == node)
                    node.GetParent().SetLeft(pivot);
                else
                    node.GetParent().SetRight(pivot);
            
            node.SetLeft(pivot.GetRight());
            if(pivot.GetRight() != null)
                pivot.GetRight().SetParent(node);
            
            node.SetParent(pivot);
            pivot.SetRight(node);
        }

        public Node GetRoot() => _root;

        public List<Node> GetAllNodes() => _allNodes;
    }
}