using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryClass;

namespace BinatyTree
{
    public class Point<T> where T:IComparable
    {
        public T? Data { get; set; }
        public Point<T>? Left { get; set; }
        public Point<T>? Right { get; set; }
        public Point()
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
        }
        public Point(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
        public override string ToString()
        {
            if (Data == null)
                return "";
            else
                return Data.ToString();
        }
        public int CompareTo(Point<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}