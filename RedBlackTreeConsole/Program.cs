using RedBlackTreeImplementation;
namespace RedBlackTreeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comparer<int> comparer = Comparer<int>.Default;
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>(comparer);
            redBlackTree.Add(10);
            redBlackTree.Add(20);
            redBlackTree.Add(30);
            redBlackTree.Add(15);
            redBlackTree.Add(25);
            redBlackTree.Add(5);
            redBlackTree.Remove(25);
            redBlackTree.Remove(15);
            redBlackTree.Remove(10);
            ;

            redBlackTree.Add(86);
            redBlackTree.Add(99);
            redBlackTree.Add(37);
            redBlackTree.Add(342);
            redBlackTree.Add(242);
            ;


            redBlackTree.Remove(20);
            redBlackTree.Remove(99);
            ;
            redBlackTree.Ceiling(5);
        }
   
    }
}
