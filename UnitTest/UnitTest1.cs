using RedBlackTreeImplementation;
namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertTest()
        {
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>();
            Random random = new Random();
            for(int i = 0; i < 5; i++)
            {
                
                redBlackTree.Insert(i);
            }

            ;
        }

        [Fact]
        public void RemoveTest()
        {
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>();
            for(int i = 0; i < 100; i++)
            {
                redBlackTree.Insert(i);
            }
            ;
            for(int i = 0; i < 100; i++)
            {
                redBlackTree.Remove(i);
            }
            ;
        }
    }
}