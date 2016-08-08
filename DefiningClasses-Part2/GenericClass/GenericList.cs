namespace GenericClass
{
    using System;
    using System.Text;
    using CustomAttributes;

    [Version(1, 0)]
    public class GenericList<T> where T : IComparable
    {
        // fields
        private T[] list;

        private int index;
        private int count;

        // constructors
        public GenericList(int capacity)
        {
            this.list = new T[capacity];
            this.index = 0;
            this.count = 0;
        }

        // properties
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        // indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.list[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.list[index] = value;
            }
        }

        // methods
        public void Add(T item)
        {
            // ensure capacity
            if (this.index == this.list.Length)
            {
                // enlarge the array double
                this.EnsureCapacity();
            }

            this.list[this.index] = item;
            this.index++;
            this.count++;
        }

        public void Insert(int index, T item)
        {
            if (index > this.count)
            {
                throw new IndexOutOfRangeException();
            }

            // ensure capacity
            if (this.index == this.list.Length)
            {
                // enlarge the array double
                this.EnsureCapacity();
            }

            Array.Copy(this.list, index, this.list, index + 1, this.count - index);
            this.list[index] = item;
            this.index++;
            this.count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            this.count--;
            Array.Copy(this.list, index + 1, this.list, index, this.count - index);
            this.list[this.count] = default(T);
            this.index--;
        }

        public void Clear()
        {
            if (this.count > 0)
            {
                Array.Clear(this.list, 0, this.count);
                this.index = 0;
                this.count = 0;
            }
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(this.list, element);
        }

        public override string ToString()
        {
            StringBuilder listAsStr = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                if (i == this.count - 1)
                {
                    listAsStr.Append(this.list[i].ToString());
                }
                else
                {
                    listAsStr.Append(this.list[i].ToString() + ",\r\n");
                }
            }

            return listAsStr.ToString();
        }

        public T Min()
        {
            T minElement = this.list[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.list[i].CompareTo(minElement) < 0)
                {
                    minElement = this.list[i];
                }
            }

            return minElement;
        }

        public T Max()
        {
            T maxElement = this.list[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.list[i].CompareTo(maxElement) > 0)
                {
                    maxElement = this.list[i];
                }
            }

            return maxElement;
        }

        private void EnsureCapacity()
        {
            T[] enlargedArr = new T[this.list.Length * 2];
            Array.Copy(this.list, 0, enlargedArr, 0, this.count);
            this.list = enlargedArr;
            enlargedArr = null;
        }
    }
}