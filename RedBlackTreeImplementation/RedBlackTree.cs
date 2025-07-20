using System.ComponentModel.Design;
using System.Xml.Linq;

namespace RedBlackTreeImplementation
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public Node<T>? Root { get; private set; }


        private void FlipColor(Node<T> current)
        {
            current.IsBlack = !current.IsBlack;
            if (current.LeftChild != null) current.LeftChild.IsBlack = !current.LeftChild.IsBlack;
            if (current.RightChild != null) current.RightChild.IsBlack = !current.RightChild.IsBlack;
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
            Root.IsBlack = true;
        }

        private bool IsRed(Node<T>? node)
        {
            return node != null && !node.IsBlack;
        }
        private Node<T>? InsertRec(T value, Node<T>? current)
        {
            if (current == null)
            {
                current = new Node<T>(false);

                current.Value = value;
                return current;
            }

            if (current.Value.CompareTo(value) == 0) throw new Exception("duplicates");
            else if (current.Value.CompareTo(value) > 0)
            {
                current.LeftChild = InsertRec(value, current.LeftChild);
            }
            else
            {
                current.RightChild = InsertRec(value, current.RightChild);
            }

            if (IsRed(current.RightChild) && !IsRed(current.LeftChild))
            {
                current = RotateLeft(current);
            }
            if(IsRed(current.LeftChild) && IsRed(current.LeftChild.LeftChild))
            {
                current = RotateRight(current);
            }
            if (IsRed(current.LeftChild) && IsRed(current.RightChild))
            {
                FlipColor(current);
            }


            return current;
            
        }

        public Node<T>? RotateLeft(Node<T> current)
        {

            Node<T> temp = current.RightChild!;
            current.RightChild = temp.LeftChild;
            temp.LeftChild = current;

            temp.IsBlack = current.IsBlack;
            current.IsBlack = false;

            return temp;
        }
        private Node<T>? RotateRight(Node<T> current)
        {
            Node<T> temp = current.LeftChild!;
            current.LeftChild = temp.RightChild;
            temp.RightChild = current;

            temp.IsBlack = current.IsBlack;
            current.IsBlack = false;

            return temp;
        }

        public bool Remove(Node<T> node)
        {
            return true;
        }

        private void MoveRedLeft(Node<T> node)
        {
            if(IsRed(node.LeftChild) == false && IsRed(node.LeftChild.LeftChild) == false && IsRed(node.LeftChild.RightChild) == false)
            {
                FlipColor(node);
                if(IsRed(node.RightChild.LeftChild))
                {
                    node.RightChild = RotateRight(node.RightChild);
                    node = RotateLeft(node);
                    FlipColor(node);
                }
            }
        }

        private void MoveRedRight(Node<T> node)
        {
            if(IsRed(node.RightChild) == false && IsRed(node.RightChild.LeftChild) == false && IsRed(node.RightChild.RightChild) == false)
            {
                FlipColor(node);
                if(IsRed(node.LeftChild.LeftChild))
                {
                    node = RotateRight(node);
                    FlipColor(node);
                }
            }
        }


    }
}
