namespace RedBlackTree
{
    public class Nil : ANode
    {
        private readonly Node _parent;

        private readonly Color _color;
        
        public Nil(Node parent) : base(parent)
        {
            _parent = parent;
            _color = Color.Black;
        }

        public override Node GetParent() => _parent;
        
        
        public override bool IsNil() => true;
        public override Color GetColor() => _color;
    }
}