namespace BitArray64_CTS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        private readonly ulong number;

        private byte[] bitArray;

        public BitArray64(ulong value)
        {
            this.bitArray = ConvertToBitArray(value);
            this.number = value;
        }

        public int Length
        {
            get { return this.bitArray.Length; }
        }

        public ulong Number
        {
            get { return this.number; }
        }

        public byte this[int index]
        {
            get
            {
                return this.bitArray[index];
            }

            set
            {
                if (index < 0) throw new IndexOutOfRangeException("The index cannot be negative...".ToUpper());
                if (index >= this.bitArray.Length) throw new IndexOutOfRangeException("The index cannot be larger than the number of elements in the collection...".ToUpper());

                if (value != 0)
                {
                    if (value != 1)
                    {
                        throw new ArgumentException("Value can be only '0' or '1'...".ToUpper());
                    }
                }

                this.bitArray[index] = value;
            }
        }

        public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
        {
            // Guidelines for Overriding Operator '==' at https://msdn.microsoft.com/en-us/library/ms173147(v=vs.90).aspx

            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(arr1, arr2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)arr1 == null) || ((object)arr2 == null))
            {
                return false;
            }

            // Return true if the fields match:
            return arr1.Number == arr2.Number;
        }

        public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
        {
            return !(arr1 == arr2);
        }

        public IEnumerator<int> GetEnumerator()
        {
            // variant 1
            // for (int i = 0; i < this.bitArray.Length; i++)
            // {
            //     yield return this.bitArray[i];
            // }

            // variant 2
            return new BitArray64Enumerator(this.bitArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            var objAsBitArr64 = obj as BitArray64;
            if (objAsBitArr64 == null) return false;

            for (int i = 0; i < this.bitArray.Length; i++)
            {
                if (this.bitArray[i] != objAsBitArr64[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            int seed = 29;

            hash *= seed + this.Number.GetHashCode();
            hash *= seed + this.Length.GetHashCode();

            return hash;
        }

        private static byte[] ConvertToBitArray(ulong value)
        {
            StringBuilder binaryUlongRepr = new StringBuilder();
            byte[] binaryRepr = new byte[64];

            foreach (var b in BitConverter.GetBytes(value))
            {
                string convValue = Convert.ToString(b, 2);
                if (convValue.Length < 8)
                {
                    convValue = convValue.PadLeft(8, '0');
                }

                binaryUlongRepr.Append(convValue.Reverse().ToArray());
                // binaryUlongRepr.Append('-'); // for ease when debugging 
            }

            for (int i = 0; i < binaryUlongRepr.Length; i++)
            {
                binaryRepr[i] = byte.Parse(binaryUlongRepr[i].ToString());
            }

            return binaryRepr;
        }
    }
}