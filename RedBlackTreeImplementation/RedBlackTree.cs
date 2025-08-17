using SortedSet;
using System.Collections;
using System.Windows.Markup;

namespace RedBlackTreeImplementation
{
    public class RedBlackTree<T> : ISortedSet<T> where T : IComparable<T>
    {
        public Node<T>? Root { get; private set; }

        private int count = 0;
        public int Count => count;

        IComparer<T> ISortedSet<T>.Comparer => comparer;

        private IComparer<T> comparer;

        public RedBlackTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        private void FlipColor(Node<T> current)
        {
            current.IsBlack = !current.IsBlack;
            if (current.LeftChild != null) current.LeftChild.IsBlack = !current.LeftChild.IsBlack;
            if (current.RightChild != null) current.RightChild.IsBlack = !current.RightChild.IsBlack;
        }

        public void Clear()
        {
            Root = null;
        }

        public bool Add(T value)
        {
            if(Root == null)
            {
                Root = new Node<T>(true);
                Root.Value = value;
                count++;
                return true;
            }
            Root = InsertRec(value, Root);
            Root.IsBlack = true;
            return true;
            count++;

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

            if (comparer.Compare(current.Value, value) == 0) throw new Exception("duplicates");
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

        public Node<T> RotateLeft(Node<T> current)
        {

            Node<T> temp = current.RightChild!;
            current.RightChild = temp.LeftChild;
            temp.LeftChild = current;

            temp.IsBlack = current.IsBlack;
            current.IsBlack = false;

            return temp;
        }
        private Node<T> RotateRight(Node<T> current)
        {
            Node<T> temp = current.LeftChild!;
            current.LeftChild = temp.RightChild;
            temp.RightChild = current;

            temp.IsBlack = current.IsBlack;
            current.IsBlack = false;

            return temp;
        }

        private bool success = false;
        public bool Remove(T value)
        {
            
            Root = RemoveRec(value, Root);
            return success;
        }
        private Node<T> RemoveRec(T value, Node<T> node)
        {
            success = false;

            if(value.CompareTo(node.Value) < 0)
            {
                if(!IsRed(node.LeftChild) && !IsRed(node.LeftChild.LeftChild))
                {
                    node = MoveRedLeft(node);
                }
                node.LeftChild =  RemoveRec(value, node.LeftChild);
            }
            else
            {
                if(IsRed(node.LeftChild))
                {
                    node = RotateRight(node);
                }
                if(!IsRed(node.RightChild) && node.RightChild != null && !IsRed(node.RightChild.RightChild))
                {
                    node = MoveRedRight(node);
                }


                if(node.LeftChild == null && node.RightChild == null)
                {
                    //Node<T> nodeTemp = node;
                    node = null;
                    success = true;
                    count--;
                    return node;
                    //return nodeTemp;
                }
                else
                {
                    if(node.Value.Equals(value))
                    {

                        Node<T> repNode = FindReplacementNode(node.RightChild);
                        node.Value = repNode.Value;
                        node.RightChild = DeleteReplacementNode(node.RightChild);
                        count--;
                        success = true;


                    }
                    else
                    {
                        node.RightChild =  RemoveRec(value, node.RightChild);
                    }


                }
            }
            if(node != null)
            {
                node = Fixup(node);
            }
            
            return node;
        }

        private Node<T> FindReplacementNode(Node<T> current)
        {
            if(current == null)
            {
                return null;
            }
            if(current.LeftChild == null)
            {
                return current;
            }
            //current = MoveRedLeft(current);
            return FindReplacementNode(current.LeftChild);
        }
        private Node<T> DeleteReplacementNode(Node<T> current)
        {
            if (current.LeftChild == null)
                return null;

            if (!IsRed(current.LeftChild) && !IsRed(current.LeftChild.LeftChild))
            {
                current = MoveRedLeft(current);
            }

            current.LeftChild = DeleteReplacementNode(current.LeftChild);
            return Fixup(current);
        }
        private Node<T> MoveRedLeft(Node<T> node)
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
            return node;
        }

        private Node<T> MoveRedRight(Node<T> node)
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
            return node;
        }

        private Node<T> Fixup(Node<T> current)
        {
            if (IsRed(current.RightChild) && !IsRed(current.LeftChild))
            {
                current = RotateLeft(current);
            }
            if (IsRed(current.LeftChild) && IsRed(current.LeftChild.LeftChild))
            {
                current = RotateRight(current);
            }

            if(IsRed(current.LeftChild) && IsRed(current.RightChild) && !IsRed(current))
            {
                FlipColor(current);
            }

            if(!IsRed(current.LeftChild) && current.LeftChild != null && IsRed(current.LeftChild.RightChild) && !IsRed(current.LeftChild.LeftChild))
            {
                current.LeftChild = RotateLeft(current.LeftChild);
                current = RotateRight(current);
            } 
            return current;
        }

        public Node<T>? Search(T value)
        {
            return SearchRec(value, Root);
        }

        private Node<T>? SearchRec(T value, Node<T>? current)
        {
            if (current == null) return null;
            int comparison = current.Value.CompareTo(value);
            if (comparison == 0)
            {
                return current;
            }
            else if (comparison > 0)
            {
                return SearchRec(value, current.LeftChild);
            }
            else
            {
                return SearchRec(value, current.RightChild);
            }
        }

        public bool Contains(T value)
        {
            if (SearchRec(value, Root) != null) return true;
            return false;
        }

        public T Min()
        {
            Node<T> current = Root;
            while(current.LeftChild != null)
            {
                current = current.LeftChild;
            }
            return current.Value;
        }

        public T Max()
        {
            Node<T> current = Root;
            while(current.RightChild != null)
            {
                current = current.RightChild;
            }
            return current.Value;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach(T item in collection)
            {
                Add(item);
            }
        }

        public List<T> InOrderTraversal()
        {
            List<T> list = new List<T>();
            InOrderTraversal(Root, list);
            return list;
        }
        private void InOrderTraversal(Node<T> current, List<T> list)
        {
            if (current == null) return;
            InOrderTraversal(current.LeftChild,  list);
            list.Add(current.Value);
            InOrderTraversal(current.RightChild, list);
        }


        public T Ceiling(T value)
        {
            List<T> values = InOrderTraversal();
            if (values.Contains(value)) return value;
            else
            {
                foreach(var item in values)
                {
                    if (item.CompareTo(value) > 0) return item;
                }
            }
            return default;


        }

        public T Floor(T value)
        {
            List<T> values = InOrderTraversal();
            if (values.Contains(value)) return value;
            else
            {
                for(int i = values.Count - 1; i > - 1; i--)
                {
                    if (values[i].CompareTo(value) < 0) return values[i];
                }
            }
            return default;
        }

        ISortedSet<T> ISortedSet<T>.Union(ISortedSet<T> other)
        {
            throw new NotImplementedException();
        }

        ISortedSet<T> ISortedSet<T>.Intersection(ISortedSet<T> other)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
