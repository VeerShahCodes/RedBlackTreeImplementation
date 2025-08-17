using RedBlackTreeImplementation;
namespace RedBlackTreeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>();
            redBlackTree.Insert(10);
            redBlackTree.Insert(20);
            redBlackTree.Insert(30);
            redBlackTree.Insert(15);
            redBlackTree.Insert(25);
            redBlackTree.Insert(5);
            redBlackTree.Remove(25);
            redBlackTree.Remove(15);
            redBlackTree.Remove(10);
            ;

            redBlackTree.Insert(86);
            redBlackTree.Insert(99);
            redBlackTree.Insert(37);
            redBlackTree.Insert(342);
            redBlackTree.Insert(242);
            ;


            redBlackTree.Remove(20);
            redBlackTree.Remove(99);
            ;

        }
    }
}
