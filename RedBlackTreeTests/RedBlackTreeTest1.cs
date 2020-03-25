using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBlackTree;
using Color = RedBlackTree.Color;

namespace RedBlackTreeTests
{
    [TestClass]
    public class RedBlackTreeTest
    {

        [TestMethod]
        public void CheckLenghtListOfNodesAfterInsert()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.InsertNode(8);
            tree.InsertNode(17);
            Assert.AreEqual(3, tree.GetAllNodes().Count);
        }
        [TestMethod]
        public void CheckRedNodesAfterInsert()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.InsertNode(8);
            tree.InsertNode(17);
            tree.InsertNode(1);
            tree.InsertNode(11);
            tree.InsertNode(15);
            tree.InsertNode(25);
            foreach (var node in tree.GetAllNodes())
            {
                var res = true;
                if (node.GetColor() == Color.Red)
                {
                    res = node.GetLeft().IsNil() && node.GetRight().IsNil() ||
                          node.GetRight().GetColor() == Color.Black && node.GetLeft().GetColor() == Color.Black;
                }
                Assert.AreEqual(true, res, "Red parent can have only black child");
            }
        }
        
        [TestMethod]
        public void CheckLenghtListOfNodesAfterDelete()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.InsertNode(8);
            tree.InsertNode(17);
            tree.DeleteNode(8);
            Assert.AreEqual(2, tree.GetAllNodes().Count);
        }
        
        [TestMethod]
        public void CheckRedNodesAfterDelete()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.InsertNode(8);
            tree.InsertNode(17);
            tree.DeleteNode(8);
            tree.InsertNode(1);
            tree.InsertNode(11);
            tree.DeleteNode(17);
            tree.InsertNode(15);
            tree.InsertNode(25);
            tree.DeleteNode(1);
            foreach (var node in tree.GetAllNodes())
            {
                var res = true;
                if (node.GetColor() == Color.Red)
                {
                    res = node.GetLeft().IsNil() && node.GetRight().IsNil() ||
                          node.GetRight().GetColor() == Color.Black && node.GetLeft().GetColor() == Color.Black;
                }
                Assert.AreEqual(true, res, "Red parent can have only black child");
            }
        }
        
        [TestMethod]
        public void CheckForNodeExistence()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.InsertNode(8);
            tree.InsertNode(17);
            Assert.AreEqual(false, tree.DeleteNode(5));
            Assert.AreEqual(true, tree.DeleteNode(8));
        }
    }
}