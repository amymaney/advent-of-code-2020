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
            Console.WriteLine(HighestSeatID(false));
        }

        static int HighestSeatID(bool useMyMap)
        {

            int highestseat = 0;

            // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file, holds in lines
            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            List<int> listOfRows = new List<int>();
            List<int> listofColumns = new List<int>();



            for(int i=0; i<lengg; i++)
            {
                // current seat
                string currentSeat = lines[i];
               
                    List<int> rows = new List<int>();
                    rows = Enumerable.Range(0, 128).ToList();

                    int a = 0;

                    if(currentSeat[a]=='F')
                    {
                       rows.RemoveRange(64,64);
                    }
                    else if(currentSeat[a]=='B')
                    {
                        rows.RemoveRange(0,64);
                    }

                    a++;

                    if(currentSeat[a]=='F')
                    {
                        rows.RemoveRange(32,32);
                    }
                    else if(currentSeat[a]=='B')
                    {
                        rows.RemoveRange(0, 32);
                    }

                    
                    a++;
                    if(currentSeat[a]=='F')
                    {
                        rows.RemoveRange(16,16);
                    }
                    else if(currentSeat[a]=='B')
                    {
                        rows.RemoveRange(0,16);
                    }

                    
                    a++;
                    if(currentSeat[a]=='F')
                    {
                        rows.RemoveRange(8,8);
                    }
                    else if(currentSeat[a]=='B')
                    {
                        rows.RemoveRange(0,8);
                    }

                   
                    a++;
                    if(currentSeat[a]=='F')
                    {
                        rows.RemoveRange(4,4);
                    }
                    else if(currentSeat[a]=='B')
                    {
                        rows.RemoveRange(0,4);
                    }

                    a++;
                    
                    if(currentSeat[a]=='F')
                    {
                        rows.RemoveRange(2,2);
                    }
                    else if(currentSeat[a]=='B')
                    {
                        rows.RemoveRange(0,2);
                    }

                    a++;

                    if(currentSeat[a]=='F')
                    {
                        rows.RemoveRange(1,1);
                    }
                    else if(currentSeat[a]=='B')
                    {
                        rows.RemoveRange(0,1);
                    }

                    listOfRows.Add(rows[0]);

                    rows.Clear();

                    List<int> columns = new List<int>();
                    columns = Enumerable.Range(0, 8).ToList();

                    a++;

                    if(currentSeat[a]=='L')
                    {
                       columns.RemoveRange(4,4);
                    }
                    else if(currentSeat[a]=='R')
                    {
                        columns.RemoveRange(0,4);
                    }

                    a++;

                    if(currentSeat[a]=='L')
                    {
                       columns.RemoveRange(2,2);
                    }
                    else if(currentSeat[a]=='R')
                    {
                        columns.RemoveRange(0,2);
                    }

                    a++;

                    if(currentSeat[a]=='L')
                    {
                       columns.RemoveRange(1,1);
                    }
                    else if(currentSeat[a]=='R')
                    {
                        columns.RemoveRange(0,1);
                    }

                    listofColumns.Add(columns[0]);

                    columns.Clear();
    
            }

            List<int> listofSeatID = new List<int>();

            for(int x=0; x<lengg; x++)
            {
                listofSeatID.Add(listOfRows[x]*8 + listofColumns[x]);
            }

            highestseat = listofSeatID.Max();

            // PART 2

            listofSeatID.Sort();

            var missingSeatList = Enumerable.Range(0, listofSeatID.Max()).Except(listofSeatID);

            var missingSeat = missingSeatList.Max();

            return highestseat;

        }
    }
}
