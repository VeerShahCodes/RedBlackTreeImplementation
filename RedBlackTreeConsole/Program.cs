using RedBlackTreeImplementation;
namespace RedBlackTreeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>();
            for(int i = 0; i < 100; i++)
            {
                
                redBlackTree.Insert(i);
            }
            

        }
    }
}
