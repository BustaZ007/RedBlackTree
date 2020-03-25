namespace RedBlackTree
{
    public abstract class ANode
    {
        private Node _parent;

        private Color _color;
        protected ANode(Node parent)
        {
            _parent = parent;
        }

        public abstract bool IsNil();

        public abstract Color GetColor();

        public abstract Node GetParent();
    }
}