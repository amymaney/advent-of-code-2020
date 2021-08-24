using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace src
{
    class Program
    {
        static void Main()
        {
            // PART 1
            Console.WriteLine(HowManyBags(false));

            // PART 2
            //Console.WriteLine(HowManyInside(true));
        }

        static int HowManyInside(bool useMyMap)
        {
            int bagCount = 0;

            string text = useMyMap ? @"sample2.txt" : "input.txt";

            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            string myBag = "shiny gold bags contain";
            string currentLine;
            string[] BagsSplit;

            List<int> noOfBag = new List<int>();
            
            List<string> Bag = new List<string>();

            List<string> list = new List<string>();
            List<string> ListOfCorrectBags = new List<string>();

            for(int i = 0; i < lengg; i++)
            {
                currentLine = lines[i];
                list.Add(currentLine);

                if(currentLine.StartsWith(myBag))
                {
                    BagsSplit = currentLine.Split(new[] {" contain ", " "}, StringSplitOptions.RemoveEmptyEntries);
                    noOfBag.Add(Int32.Parse(BagsSplit[3]));
                    Bag.Add(BagsSplit[4] + " " + BagsSplit[5]);
                    
                    Array.Clear(BagsSplit, 0, BagsSplit.Length);
                }
            }



            return bagCount;
        }

        static int HowManyBags(bool useMyMap)
        {

            // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file, holds in lines
            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            string myBag = "shiny gold";
            string none = "no other bags";
            string currentLine;
            List<string> BagsWithDirectlyMyBag = new List<string>();

            List<string> list = new List<string>();

            
            List<string> ListOfCorrectBags = new List<string>();
            List<string> ListOfCorrectBags2 = new List<string>();

            List<string> ListOfBagsSentences = new List<string>();
            List<string> distinctListOfBags = new List<string>();

            string[] BagsSplit;

            for(int i =0; i<lengg; i++)
            {
                currentLine = lines[i];
                list.Add(currentLine);
                // removes bags that contain no other bags
                if(currentLine.Contains(none))
                {
                    list.Remove(currentLine);
                }
                
            }

            for(int i = 0; i<list.Count; i++)
            {
                currentLine = list[i];

                if(currentLine.Contains(myBag))
                {
                    BagsSplit = currentLine.Split(new[] {" bags"}, StringSplitOptions.RemoveEmptyEntries);
                    ListOfCorrectBags.Add(BagsSplit[0]);
                    ListOfCorrectBags = ListOfCorrectBags.Distinct().ToList();
                    Array.Clear(BagsSplit, 0, BagsSplit.Length);

                }
            }

            
            for(int a =0; a<100; a++)
            {
                int correctBagCount = ListOfCorrectBags.Count();
            for(int i = 0; i<list.Count; i++)
            {
                currentLine = list[i];

                for(int x=0; x<correctBagCount; x++)
                {
                    string correctBag = ListOfCorrectBags[x];

                    if(currentLine.Contains(correctBag))
                    {
                        
                        BagsSplit = currentLine.Split(new[] {" bags"}, StringSplitOptions.RemoveEmptyEntries);
                        ListOfCorrectBags.Add(BagsSplit[0]);
                        ListOfCorrectBags = ListOfCorrectBags.Distinct().ToList();
                        Array.Clear(BagsSplit, 0, BagsSplit.Length);
                        
                    }
                }
            }
            a++;
            correctBagCount = ListOfCorrectBags.Count();
            }

            for(int b = 0; b<ListOfCorrectBags.Count; b++)
            {
                currentLine=ListOfCorrectBags[b];
                if(currentLine.StartsWith(myBag))
                {
                    ListOfCorrectBags.Remove(currentLine);
                }
            }

            int bagsCount = ListOfCorrectBags.Count();

            return bagsCount;
        }

    }
}