namespace RedBlackTreeImplementation
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public Node<T>? Root { get; private set; }


        private void FlipColor(Node<T> current)
        {
            current.IsBlack = !current.IsBlack;
            current.LeftChild.IsBlack = !current.IsBlack;
            current.RightChild.IsBlack = !current.IsBlack;
            Root.IsBlack = true;
        }

        public void Insert(T value)
        {
            if(Root == null)
            {
                Root = new Node<T>(true);
                Root.Value = value;
                return;
            }
            Root = InsertRec(value, Root);
        }

        private Node<T>? InsertRec(T value, Node<T>? current)
        {
            if (current == null)
            {
                current = new Node<T>(false);
                current.Value = value;
                return current;
            }

            if (current.LeftChild != null && current.RightChild != null)
            {
                if (current.LeftChild.IsBlack == false && current.RightChild.IsBlack == false)
                {
                    FlipColor(current);
                }
            }

            if (current.Value.CompareTo(value) > 0)
            {
                current.LeftChild = InsertRec(value, current.LeftChild);
            }
            else
            {
                current.RightChild = InsertRec(value, current.RightChild);
            }

            if (current.RightChild != null && current.RightChild.IsBlack == false)
            {
                current = RotateLeft(current);
            }

            if (current.LeftChild != null && current.LeftChild.IsBlack == false && current.LeftChild.LeftChild != null && current.LeftChild.LeftChild.IsBlack == false)
            {
                current = RotateRight(current);
            }
            return current;
            
        }

        public Node<T>? RotateLeft(Node<T> current)
        {
            
            Node<T> tempRoot = current.RightChild;
            Node<T> tmpRootLeftChild = tempRoot.LeftChild;
            tempRoot.LeftChild = current;
            if(tempRoot.LeftChild != null)
            {
                current.RightChild = tmpRootLeftChild;
            }
            Root.IsBlack = true;
            return tempRoot;
        }
        private Node<T>? RotateRight(Node<T> current)
        {
            Node<T> tempRoot = current.LeftChild;
            Node<T> tmpRootRightChild = tempRoot.RightChild;
            tempRoot.RightChild = current;
            if(tempRoot.RightChild != null)
            {
                current.LeftChild = tmpRootRightChild;
            }
            Root.IsBlack = true;
            return tempRoot;
        }

        
    }
}
