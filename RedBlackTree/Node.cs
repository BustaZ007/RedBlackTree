
using System;

namespace RedBlackTree
{
    public class Node
    {
        private Color _color;
        private readonly int _value;
        private Node _left;
        private Node _right;
        private bool _isNil;
        private Node _parent;

        public Node(int value, Node parent = null, Color color = Color.Black, Node left = null, Node right = null, bool isNil = true)
        {
            _color = color;
            _left = left;
            _right = right;
            _isNil = isNil;
            _parent = parent;
            _value = value;
        }

        public Node GetLeft() => _left;

        public Node GetRight() => _right;

        public Color GetColor() => _color;

        public bool IsNil() => _isNil;

        public void AddChild(int value)
        {
            if (value >= _value)
            {
                _right = new Node(value,this, _color == Color.Black ? Color.Red : Color.Black);
            }
            else
            {
                _left = new Node(value,this, _color == Color.Black ? Color.Red : Color.Black);
            }
            _isNil = false;
        }

        public void Repaint()
        {
            _color = _color == Color.Black ? Color.Red : Color.Black;
        }
    }
}