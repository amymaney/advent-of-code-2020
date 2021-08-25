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
            Console.WriteLine(HowManyInside(false));
        }

        record BagInfo (List<(int Count, string Colour)> Bags, int? Count);

        static int HowManyInside(bool useMyMap)
        {
            int bagCount = 0;

            string text = useMyMap ? @"sample2.txt" : "input.txt";

            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            string myBag = "shiny gold";

            List<string> list = new List<string>();

            Dictionary<string, BagInfo> bags = new Dictionary<string, BagInfo>();

            for(int i = 0; i < lengg; i++)
            {
                string[] colourAndContent = lines[i].Split(" bags contain ");
                string bagColour = colourAndContent[0];
                string[] containedBags = colourAndContent[1].Contains("no other bags")
                    ? new string [0]
                    :  colourAndContent[1].Split(", ");
                BagInfo currentBag = new BagInfo(containedBags.Select(t =>
                {
                    // t will look like this: 
                    // 2 muted yellow bags.
                    int firstSpaceIndex = t.IndexOf(' ');
                    string countText = t.Substring(0, firstSpaceIndex);
                    int count = int.Parse(countText);
                    int bagIndex = t.IndexOf(" bag");
                    string colour = t.Substring(firstSpaceIndex+1, bagIndex-(firstSpaceIndex+1));

                    return (count, colour);
                }).ToList(), null);

                bags.Add(bagColour, currentBag);

            }

            int GetBagCount(string bagColour)
            {
                BagInfo info = bags[bagColour];

                if(info.Count.HasValue)
                {
                    return info.Count.Value;
                }
                
                int count;

                count = info.Bags.Sum(childBagType => GetBagCount(childBagType.Colour)*childBagType.Count)+1;

                bags[bagColour] = info with{Count = count};
                
                return count;
            }

            System.Console.WriteLine(GetBagCount(myBag)-1);
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