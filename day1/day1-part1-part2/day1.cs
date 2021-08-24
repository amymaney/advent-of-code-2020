using System;
using System.Collections.Generic;

namespace day1
{
    class Program
    {
        static void Main()
        {
            // reads text file with the numbers
            string[] data = System.IO.File.ReadAllLines(@"list-of-no.txt");

            // array which will store all the numners
            List<int> array = new List<int>();
            
            // converts numbers into integers and stores them in array
            for(int x=0; x < data.Length; x++)
            {
                array.Add(Convert.ToInt32(data[x]));
            }
            
            // will store the two numbers that add to 2020
            List<int> nums = new List<int>();

            // adds together and checks which two numbers add to 2020
            for(int x=0; x < data.Length; x++)
            {
                for(int y=1; y < data.Length; y++)
                {
                    if(array[x] + array[y] == 2020)
                    {
                        nums.Add(array[x]);
                        nums.Add(array[y]);
                        
                    }
                }
            }

            // multiplies the two numbers
            int answer = nums[0]*nums[1];

            // prints the answer
            Console.WriteLine(answer);

        }
    }
}

