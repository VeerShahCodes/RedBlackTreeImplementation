using RedBlackTreeImplementation;
namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void RotateTest()
        {
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>();
            Node<int> root = new Node<int>(true, 3);
            root.LeftChild = new Node<int>(false, 2);
            root.RightChild = new Node<int>(false, 4);
            root = redBlackTree.RotateLeft(root);
            
            
        }
    }
}