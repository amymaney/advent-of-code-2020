using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace src
{
    class Program
    {
        static void Main()
        {
            // PART 1
            Console.WriteLine(HowManyQuestionsYes1(false));

            // PART 2
            Console.WriteLine(HowManyQuestionsYes2(false));
        }

        static int HowManyQuestionsYes2(bool useMyMap)
        {
             // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file, holds in lines
            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            List<string> currentGroup = new List<string>();
            
            List<int> listOfYes = new List<int>();
            List<char> firstLine = new List<char>();

            int numberOfYes=0;

            for(int i=0; i<lengg; i++)
            {

                string joinedGroup = " ";
                string joinedFirstLine;

                do
                {
                    currentGroup.Add(lines[i]);
                    i++;
                }
                while(i<lengg && lines[i].Length != 0);
                
                for(int y = 0; y<currentGroup[0].Length; y++)
                {
                    firstLine.Add(currentGroup[0][y]);
                }

                joinedFirstLine = string.Join("", firstLine);
                if(currentGroup.Count != 1){
                    currentGroup.RemoveAt(0);
                }
                

                joinedGroup = string.Join("", currentGroup);

                var duplicateItems = joinedGroup.GroupBy(x => x).Where(x => x.Count() >= currentGroup.Count).Select(x => x.Key);

                string joinedDuplicate = string.Join("", duplicateItems);
                
                var intersect = joinedFirstLine.Intersect(joinedDuplicate);

                numberOfYes = intersect.Count();
                
                listOfYes.Add(numberOfYes);
                
                currentGroup.Clear();
                firstLine.Clear();
                    

            }

            var yes = listOfYes.Sum();

            return yes;

            
        }
    

        static int HowManyQuestionsYes1(bool useMyMap)
        {

            // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file, holds in lines
            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            List<string> currentGroup = new List<string>();
            List<int> listOfYes = new List<int>();

            for(int i=0; i<lengg; i++)
            {

                string joinedGroup = " ";

                // takes the current group into one list
                do
                {
                    currentGroup.Add(lines[i]);
                    i++;
                }
                while(i<lengg && lines[i].Length != 0);

                // puts the list holding current group into a single string
                joinedGroup = string.Join("", currentGroup);

                // need to go through each group and check how many letters (minus duplicates)
                
                string duplicatesRemoved = string.Empty;

                List<char> found = new List<char>();
                foreach(char c in joinedGroup)
                {
                if(found.Contains(c))
                    continue;

                duplicatesRemoved+=c.ToString();
                found.Add(c);
                }

                int numberOfYes = duplicatesRemoved.Length;

                listOfYes.Add(numberOfYes);
                
                currentGroup.Clear();

            }

           var yes = listOfYes.Sum();

            return yes;

        }
    }
}
