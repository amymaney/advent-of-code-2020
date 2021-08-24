using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace day2
{
    class Program
    {
        static void Main()
        {
        
            string[] data = System.IO.File.ReadAllLines(@"passwords.txt");
            
            List<string[]> policies = new List<string[]>();
            
            for(int x=0; x < data.Length; x++)
            {

                policies.Add(data[x].Split(new[] {' ', ':', '-'}, StringSplitOptions.RemoveEmptyEntries));

            } 

            int valid=0;
            // count will hold the number of valid passwords

            // now I have a list of arrays (each element in list is an array with 4 elements)
            // next, work through each element in list, checking the password rules against the password
            // 1st array element is min no times letter allowed
            // 2nd array element is max no times letter allowed
            // 3rd array element is the letter
            // 4th array element is the password


            // PART 1

            /*
            
            for(int i=0; i < data.Length; i++)
            {
                // freq will store no of times the letter appears in password
                
                var freq = Regex.Matches(policy[i][3], policy[i][2]).Count;
                
                // turn policy[i][0] and policy[i][1] into integers
                List<int> num1 = new List<int>();
                List<int> num2 = new List<int>();
                for(int x=0; x < data.Length; x++)
                {
                    num1.Add(Int32.Parse(policies[x][0])); //min
                    num2.Add(Int32.Parse(policies[x][1])); //max
                    
                }
                
                if((num1[i] <= freq)&&(num2[i] >= freq))
                {
                    valid = valid +1;
                }
            }
            Console.WriteLine(valid);
            
            */

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // PART 2

            List<int> pos1 = new List<int>();
            List<int> pos2 = new List<int>();

            // turns the string into integers

            for(int k=0; k < data.Length; k++)
            {

                pos1.Add(Int32.Parse(policies[k][0])); 
                pos2.Add(Int32.Parse(policies[k][1])); 
                
            }

            for(int x=0; x < data.Length; x++)
            {

                // variables to hold different things

                // policy holds a specific line in policies
                var policy = policies[x];

                // cpos1 is the 1st position we're looking at in the password in that line etc.
                int cpos1 = pos1[x]-1;
                int cpos2 = pos2[x]-1;

                // expectedc is the letter we are given for that line
                char expectedc = policy[2][0];

                // password is the password in that line
                string password = policy[3];

                // c1 and c2 are the actual letters in those positions in the password
                char c1 = password[cpos1];
                char c2 = password[cpos2];

                // adds 1 to valid if only one of the actual letters matches the expected letter
                if((c1 == expectedc)^(c2 == expectedc))
                {
                    valid = valid+1;
                }
            }

            // prints out the answer
            Console.WriteLine(valid);

        }
    }
}