namespace BitArray64_CTS
{
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64Enumerator : IEnumerator<int>
    {
        private byte[] bitArray;

        private int index = -1;

        public BitArray64Enumerator(byte[] someBitArray)
        {
            this.bitArray = someBitArray;
        }

        public int Current
        {
            get { return this.bitArray[this.index]; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public bool MoveNext()
        {
            if (this.index >= this.bitArray.Length - 1)
            {
                return false;
            }

            this.index++;
            return true;
        }

        public void Reset()
        {
            this.index = -1;
        }

        public void Dispose()
        {
        }
    }
}
