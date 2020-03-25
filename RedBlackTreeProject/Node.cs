
using System;

namespace RedBlackTree
{
    public class Node : ANode
    {
        private Color _color;
        private readonly int _value;
        private ANode _left;
        private ANode _right;
        private Node _parent;

        public Node(int value, Node parent = null) : base(parent)
        {
            _color = Color.Red;
            _left = new Nil(this);
            _right = new Nil(this);
            _parent = parent;
            _value = value;
        }

        public ANode GetLeft() => _left;

        public ANode GetRight() => _right;

        public override Color GetColor() => _color;
        public override Node GetParent() => _parent;

        public override bool IsNil() => false;

        public void AddChild(int value)
        {
            if (value >= _value)
            {
                _right = new Node(value,this);
            }
            else
            {
                _left = new Node(value,this);
            }
        }

        public void Repaint()
        {
            _color = _color == Color.Black ? Color.Red : Color.Black;
        }
    }
}