using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryClass;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinatyTree
{
    public class MyTree<T> where T : IInit, IComparable, new()
    {
        public Point<T>? root = null;
        int count = 0;
        public int Count => count;

        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        public void ShowTree()
        {
            Show(root);
        }

        public Point<T>? MakeTree(int length, Point<T>? point)
        {
            T data = new T();
            data.RandomInit();
            Point<T> newItem = new Point<T>(data);
            if (length == 0)
            {
                return null;
            }
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }

        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5);
            }
        }

        public double CalculateAverageDate()
        {
            (long totalDate, int count) = CalculateTotalDateAndCount(root);
            return count == 0 ? 0 : (double)totalDate / count;
        }

        private (long, int) CalculateTotalDateAndCount(Point<T>? point)
        {
            if (point == null)
                return (0, 0);

            (long leftTotal, int leftCount) = CalculateTotalDateAndCount(point.Left);
            (long rightTotal, int rightCount) = CalculateTotalDateAndCount(point.Right);

            long currentDate = (point.Data as BankCard).Date;

            long totalDate = leftTotal + rightTotal + currentDate;
            int totalCount = leftCount + rightCount + 1;

            return (totalDate, totalCount);
        }

        public void AddPoint(T data) 
        {
            Point<T>? point = root;
            Point<T>? current = null;
            bool isExist = false;
            while (point != null && !isExist) 
            {
                current = point;
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else 
                {
                    if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else 
                    {
                        point = point.Right;
                    }
                }
            }
            if (isExist) 
            {
                return;
            }
            Point<T> newPoint = new Point<T>(data);
            if (current.Data.CompareTo(data) < 0)
                current.Left = newPoint;
            else
                current.Right = newPoint;
            count++;
        }

        void TransformToArray(Point<T>? point, T[] array, ref int current) 
        {
            if (point != null) 
            {
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right, array, ref current);
            }
        }

        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);
            root = new Point<T>(array[0]);
            count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }

        public void DeleteTree()
        {
            DeleteNode(root);
            root = null;
            count = 0;
        }

        public void DeleteNode(Point<T>? point)
        {
            if (point != null)
            {
                DeleteNode(point.Left);
                DeleteNode(point.Right);
                point.Left = null;
                point.Right = null;
            }
        }

        public bool Contains(T data)
        {
            return ContainsNode(root, data);
        }

        private bool ContainsNode(Point<T>? node, T data)
        {
            if (node == null)
                return false;

            if (node.Data.Equals(data))
                return true;

            if (node.Data.CompareTo(data) < 0)
                return ContainsNode(node.Left, data);
            else
                return ContainsNode(node.Right, data);
        }

        public MyTree<T> Clone()
        {
            MyTree<T> clone = new MyTree<T>(count);
            clone.root = CloneSubtree(root);
            return clone;
        }

        private Point<T> CloneSubtree(Point<T> point)
        {
            if (point == null) return null;
            Point<T> newPoint = new Point<T>(point.Data);
            newPoint.Left = CloneSubtree(point.Left);
            newPoint.Right = CloneSubtree(point.Right);
            return newPoint;
        }  
    }
}