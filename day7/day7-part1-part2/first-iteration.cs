/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace src
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(HowManyBags(false));
        }

        static int HowManyBags(bool useMyMap)
        {
            int bagsCount = 0;

            // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file, holds in lines
            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            string shinyGold = "shiny gold";

            string currentLine;

            List<string> firstBags = new List<string>();
            List<string> secondBags = new List<string>();
            List<string> thirdBags = new List<string>();
            List<string> fourthBags = new List<string>();
            List<string> fifthBags = new List<string>();
            List<string> sixthBags = new List<string>();
            List<string> seventhBags = new List<string>();
            List<string> eigthBags = new List<string>();

            string[] firstBagsSplit;
            string[] secondBagsSplit;
            string[] thirdBagsSplit;
            string[] fourthBagsSplit;
            string[] fifthBagsSplit;
            string[] sixthBagsSplit;
            string[] seventhBagsSplit;

            List<string> firstBagsList = new List<string>();
            List<string> secondBagsList = new List<string>();
            List<string> thirdBagsList = new List<string>();
            List<string> fourthBagsList = new List<string>();
            List<string> fifthBagsList = new List<string>();
            List<string> sixthBagsList = new List<string>();

            for(int i = 0; i<lengg; i++)
            {
                currentLine = lines[i];

                // check if currentLine contains "shiny gold" directly
                if(currentLine.Contains(shinyGold))
                {
                    firstBags.Add(currentLine);
                }

            }

            // need to remove instance where 'shiny gold bag contains'
            // because we want to carry it in atleast 1 other bag
            for(int x =0; x<firstBags.Count; x++)
                {
                    currentLine = firstBags[x];

                    if(currentLine.StartsWith(shinyGold))
                    {
                        firstBags.Remove(currentLine);
                    }
                }

            // check for secondary bags

            for(int x =0; x<firstBags.Count; x++)
            {
                firstBagsSplit = firstBags[x].Split(new string[] {" bags"}, StringSplitOptions.RemoveEmptyEntries);
                firstBagsList.Add(firstBagsSplit[0]);
            }



            for(int x =0; x<firstBagsList.Count; x++)
            {
                for(int i =0; i<lengg; i++)
                {
                    currentLine=lines[i];

                    if(currentLine.Contains(firstBagsList[x]))
                {
                    secondBags.Add(currentLine);
                }
                }
            }

            // remove duplicates
            List<string> distinctSecondBags = secondBags.Distinct().ToList();
           
           for(int i=0; i<secondBagsList.Count; i++)
           {
                for(int x =0; x<secondBags.Count; x++)
                        {
                            currentLine = secondBags[x];

                            if(currentLine.StartsWith(shinyGold))
                            {
                                secondBags.Remove(currentLine);
                            }

                            if(currentLine.StartsWith(secondBagsList[i]))
                            {
                                secondBags.Remove(currentLine);
                            }

                        }
            }

            for(int x =0; x<secondBags.Count; x++)
            {
                secondBagsSplit = secondBags[x].Split(new string[] {" bags"}, StringSplitOptions.RemoveEmptyEntries);
                secondBagsList.Add(secondBagsSplit[0]);
            }

            for(int x =0; x<secondBagsList.Count; x++)
            {
                for(int i =0; i<lengg; i++)
                {
                    currentLine=lines[i];

                    if(currentLine.Contains(secondBagsList[x]))
                {
                    thirdBags.Add(currentLine);
                }
                }
            }

            // remove duplicates
            List<string> distinctThirdBags = thirdBags.Distinct().ToList();




            for(int i=0; i<thirdBagsList.Count; i++)
           {
                for(int x =0; x<thirdBags.Count; x++)
                        {
                            currentLine = thirdBags[x];

                            if(currentLine.StartsWith(shinyGold))
                            {
                                thirdBags.Remove(currentLine);
                            }

                            if(currentLine.StartsWith(thirdBagsList[i]))
                            {
                                thirdBags.Remove(currentLine);
                            }

                        }
            }

            for(int x =0; x<thirdBags.Count; x++)
            {
                thirdBagsSplit = thirdBags[x].Split(new string[] {" bags"}, StringSplitOptions.RemoveEmptyEntries);
                thirdBagsList.Add(thirdBagsSplit[0]);
            }

            for(int x =0; x<thirdBagsList.Count; x++)
            {
                for(int i =0; i<lengg; i++)
                {
                    currentLine=lines[i];

                    if(currentLine.Contains(thirdBagsList[x]))
                {
                    fourthBags.Add(currentLine);
                }
                }
            }

            // remove duplicates
            List<string> distinctFourthBags = fourthBags.Distinct().ToList();

           



           

            for(int i=0; i<fourthBagsList.Count; i++)
           {
                for(int x =0; x<fourthBags.Count; x++)
                        {
                            currentLine = fourthBags[x];

                            if(currentLine.StartsWith(shinyGold))
                            {
                                fourthBags.Remove(currentLine);
                            }

                            if(currentLine.StartsWith(fourthBagsList[i]))
                            {
                                fourthBags.Remove(currentLine);
                            }

                        }
            }

            for(int x =0; x<fourthBags.Count; x++)
            {
                fourthBagsSplit = fourthBags[x].Split(new string[] {" bags"}, StringSplitOptions.RemoveEmptyEntries);
                fourthBagsList.Add(fourthBagsSplit[0]);
            }

            for(int x =0; x<fourthBagsList.Count; x++)
            {
                for(int i =0; i<lengg; i++)
                {
                    currentLine=lines[i];

                    if(currentLine.Contains(fourthBagsList[x]))
                {
                    fifthBags.Add(currentLine);
                }
                }
            }

            // remove duplicates
            List<string> distinctFifthBags = fifthBags.Distinct().ToList();

           




           for(int i=0; i<fifthBagsList.Count; i++)
           {
                for(int x =0; x<fifthBags.Count; x++)
                        {
                            currentLine = fifthBags[x];

                            if(currentLine.StartsWith(shinyGold))
                            {
                                fifthBags.Remove(currentLine);
                            }

                            if(currentLine.StartsWith(fifthBagsList[i]))
                            {
                                fifthBags.Remove(currentLine);
                            }

                        }
            }

            for(int x =0; x<fifthBags.Count; x++)
            {
                fifthBagsSplit = fifthBags[x].Split(new string[] {" bags"}, StringSplitOptions.RemoveEmptyEntries);
                fifthBagsList.Add(fifthBagsSplit[0]);
            }

            for(int x =0; x<fifthBagsList.Count; x++)
            {
                for(int i =0; i<lengg; i++)
                {
                    currentLine=lines[i];

                    if(currentLine.Contains(fifthBagsList[x]))
                {
                    sixthBags.Add(currentLine);
                }
                }
            }

            // remove duplicates
            List<string> distinctSixthBags = sixthBags.Distinct().ToList();

           





        for(int i=0; i<sixthBagsList.Count; i++)
           {
                for(int x =0; x<sixthBags.Count; x++)
                        {
                            currentLine = sixthBags[x];

                            if(currentLine.StartsWith(shinyGold))
                            {
                                sixthBags.Remove(currentLine);
                            }

                            if(currentLine.StartsWith(sixthBagsList[i]))
                            {
                                sixthBags.Remove(currentLine);
                            }

                        }
            }

            for(int x =0; x<sixthBags.Count; x++)
            {
                sixthBagsSplit = sixthBags[x].Split(new string[] {" bags"}, StringSplitOptions.RemoveEmptyEntries);
                sixthBagsList.Add(sixthBagsSplit[0]);
            }

            for(int x =0; x<sixthBagsList.Count; x++)
            {
                for(int i =0; i<lengg; i++)
                {
                    currentLine=lines[i];

                    if(currentLine.Contains(sixthBagsList[x]))
                {
                    seventhBags.Add(currentLine);
                }
                }
            }

            // remove duplicates
            List<string> distinctSeventhBags = seventhBags.Distinct().ToList();

           bagsCount = distinctSeventhBags.Count();
            
            
           
            

            return bagsCount;

        }
    }
}*/
// we have "shiny gold bag"
// need to find out how many bags can contain shiny gold bag