using System.ComponentModel;
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
        public void CheckForNodeExistenceWhenInserting()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.InsertNode(8);
            tree.InsertNode(17);
            Assert.AreEqual(true, tree.InsertNode(5));
            Assert.AreEqual(false, tree.InsertNode(8));
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
        public void CheckForNodeExistenceWhenDeleting()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.InsertNode(8);
            tree.InsertNode(17);
            Assert.AreEqual(false, tree.DeleteNode(5));
            Assert.AreEqual(true, tree.DeleteNode(8));
        }

        [TestMethod]
        public void DeleteOneNodeRoot()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.DeleteNode(12);
            Assert.AreEqual(false, tree.DeleteNode(11));
            Assert.AreEqual(true, tree.InsertNode(14));
            Assert.AreEqual(1, tree.GetAllNodes().Count);
            Assert.AreEqual(tree.FindNodeByValue(14), tree.GetRoot());
        }

        [TestMethod]
        public void InsertAfterDeleteRoot()
        {
            RedBlackTree.RedBlackTree tree = new RedBlackTree.RedBlackTree(12);
            tree.InsertNode(8);
            tree.InsertNode(17);
            tree.InsertNode(1);
            tree.DeleteNode(12);
            tree.InsertNode(11);
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
            Assert.AreEqual(8, tree.GetRoot().GetValue());
        }
    }
}