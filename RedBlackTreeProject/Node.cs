
using System;

namespace RedBlackTree
{
    public class Node 
    {
        private Color _color;
        private readonly int? _value;
        private Node _left;
        private Node _right;
        private Node _parent;

        public Node(int? value, Node parent = null)
        {
            _color = value == null ? Color.Black : Color.Red;
            _left = value == null ? null : new Node(null, this);
            _right = value == null ? null : new Node(null, this);
            _parent = parent;
            _value = value;
        }
        
        public Node GetLeft() => _left;

        public void SetLeft(Node left)
        {
            _left = left;
        }

        public Node GetRight() => _right;
        
        public void SetRight(Node right)
        {
            _right = right;
        }

        public Color GetColor() => _color;
        public void Repaint()
        {
            _color = _color == Color.Black ? Color.Red : Color.Black;
        }

        public void SetColor(Color color)
        {
            _color = color;
        }
        public Node GetParent() => _parent;

        public void SetParent(Node parent)
        {
            _parent = parent;
        }

        public bool IsNil() => _value == null;

        public int? GetValue() => _value;

        public void AddChild(int value)
        {
            if (value >= _value)
                _right = new Node(value, this);
            else
                _left = new Node(value, this);
        }

    }
}