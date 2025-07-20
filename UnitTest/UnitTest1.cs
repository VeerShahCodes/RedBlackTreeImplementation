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
                
                redBlackTree.Insert(random.Next(5));
            }

            ;
        }
    }
}