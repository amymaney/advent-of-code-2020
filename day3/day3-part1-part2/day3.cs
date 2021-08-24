using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;

namespace src
{
    class Program
    {

        static void Main()
        {
            // checks my code against the examples from advent of code website (example map)
            // makes sure my code is all still correct
            Debug.Assert(CountTheTrees(1,1,false) == 2);
            Debug.Assert(CountTheTrees(3,1,false) == 7);
            Debug.Assert(CountTheTrees(5,1,false) == 3);
            Debug.Assert(CountTheTrees(7,1,false) == 4);
            Debug.Assert(CountTheTrees(1,2,false) == 2);

            // multiplies my answers for each - PART 2
            // BigInteger because my answer is so huge
            BigInteger answer = CountTheTrees(1,1,true)
            * CountTheTrees(3,1,true)
            * CountTheTrees(5,1,true)
            * CountTheTrees(7,1,true)
            * CountTheTrees(1,2,true);

            Console.WriteLine(answer);

            
        }
        
        // function that counts the trees
        static BigInteger CountTheTrees(int hStep, int vStep, bool useMyMap)
        {
            // so can easily swap between the example and real maps
            string text = useMyMap ? @"map.txt" : "examplemap.txt";
            
            // reads the file
            string[] lines = File.ReadAllLines(text);  

            int numberOfChars = lines[0].Length;

            // counts number of trees
            int tree = 0;

            // gets length of map
            int lengg = lines.Length;

            int hPos = hStep;

            // not starting at initial line cus we not checking anything on it
            // initial line depends on vStep
            for(int vPos=vStep; vPos<lengg; vPos+= vStep)
            {
                // so that we are working on just one line at a time
                var line = lines[vPos];

                // if tree is encountered, add 1 to number of trees
                if(line[hPos] == '#')
                {
                    tree++;
                }
                
                // tells computer how many lines to go down 
                hPos = hPos + hStep;
                
                // for when you reach right edge of map
                // makes sure you go back to left edge of map (as map just repeats horizontally)
                if(hPos >= numberOfChars)
                {
                    hPos = hPos - numberOfChars;
                }
            }
            return tree;
        }
    }

}


