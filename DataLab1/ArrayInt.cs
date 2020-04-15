using System;
using System.Collections.Generic;
using System.Text;

namespace DataLab1
{
    public class ArrayInt
    {
        public int Size { get; set; }
        private int[] myArray;
        public int[] MyArray { get { return myArray; } }
        
        public ArrayInt() { }
        public ArrayInt(int size)
        {
            myArray = new int[size];
        }
        //public void ArrayInt(int size)
        //{
        //    if (size == 0)
        //    {
        //        int[] myArray = new int[10];
        //    }
        //    else
        //    {
        //        int[] myArray = new int[size];
        //    }
            
            
                
        //}
        //returns the element at index
        public int GetAt(int index)
        {
            try
            {
                return myArray[index];
            }
            catch
            {
                throw new System.ArgumentException("GetAt: Out of Range");
            }
            
        }
        //sets the value at a vertain index
        public void SetAt(int index, int value)
        {
            try
            {
                myArray.SetValue(value, index);
            }
            catch
            {
                throw new System.ArgumentException("SetAt: Out of Range");
            }
        }
        //return the size
        public int GetSize()
        {
            return myArray.Length - 1;
        }
        //resize the array
        public void SetSize(int size)
        {
            Array.Resize(ref myArray, size);
        }
        //add val at next empty or 2X array and add
        public void Append(int value)
        {
            int empty = FindAt();
            if(empty==-1)
            {
                SetSize(GetSize()*2);
                empty = FindAt();
                myArray[empty] = value;
            }
            else
            {
                myArray[empty] = value;
            }
        }
        //0 indicates array element is empty
        public int FindAt()
        {
            int j = 0;
            foreach(int i in myArray)
            {
               
                if (i == 0)
                    return j;
                j++;

            }
            return -1;
        }
        //inserts value at location and shift all values. if full 2X
        public void InsertAt(int index, int value)
        {
            try
            {
                int empty = FindAt();
                if (empty == -1)
                {
                    int[] arrayEnd = new int[(myArray.Length) - index];
                    //myArray.CopyTo(arrayEnd, index);
                    Array.Copy(myArray,index,arrayEnd,0,arrayEnd.Length);
                    myArray[index] = value;
                    SetSize((myArray.Length) * 2);
                    arrayEnd.CopyTo(myArray, index + 1);
                }
                else
                {

                    int[] arrayEnd = new int[(myArray.Length-1)-index];
                    Array.Copy(myArray, index, arrayEnd, 0, arrayEnd.Length);
                    myArray[index] = value;
                    arrayEnd.CopyTo(myArray, index + 1);


                }
            }
            catch
            {
                throw new System.ArgumentException("InsertAt:Out of Range");
            }

        }
        //remove at index and shift all elements down
        public int RemoveAt(int index)
        {
            try
            {
                int val = GetAt(index);
                //copy everything starting from index
                int[] arrayEnd = new int[(myArray.Length - 1) - index];

                //myArray.CopyTo(arrayEnd, index+1);
                //arrayEnd.CopyTo(myArray, index);
                Array.Copy(myArray, index+1, arrayEnd, 0, arrayEnd.Length);               
                Array.Copy(arrayEnd, 0, myArray, index,arrayEnd.Length);

                myArray[myArray.Length - 1] = 0;

                return val;
            }
            catch
            {
                throw new System.ArgumentException("RemoveAt:Out of Range");
            }

        }
    }
}
