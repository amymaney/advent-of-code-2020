using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day8_part1_part2
{
    class Program
    {
        static void Main()
        {
            // PART 1
            Console.WriteLine(Part1_FindAccumulatorValue(false));

            // PART 2
            Console.WriteLine(Part2_FindAccumulatorValue(false));
        }

        static int Part2_FindAccumulatorValue(bool useMyMap)
        {
            // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file, holds in lines
            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            for (int lineToAdjust = 0; lineToAdjust < lengg; lineToAdjust++)
            {
                int accumulatorCount = 0;

                lines = File.ReadAllLines(text);

                List<string> operations = new List<string>();
                List<int> arguments = new List<int>();
                List<int> usedIndexes = new List<int>();

                for (int i = 0; i < lengg; i++)
                {
                    var currentLine = lines[i];

                    string[] currentInstruction;

                    currentInstruction = currentLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    arguments.Add(int.Parse(currentInstruction[1]));
                    operations.Add(currentInstruction[0]);
                }

                if(operations[lineToAdjust]=="jmp")
                {
                    //Console.WriteLine($"changing line {lineToAdjust} to nop");
                    operations[lineToAdjust] = "nop";
                }
                else if(operations[lineToAdjust] =="nop")
                {
                    //Console.WriteLine($"changing line {lineToAdjust} to jmp");
                    operations[lineToAdjust] = "jmp";
                }
                else
                {
                    continue;
                }

                for (int i = 0; i < lengg; i++)
                {
                    var currentLine = lines[i];

                    string[] currentInstruction;

                    currentInstruction = currentLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    arguments.Add(int.Parse(currentInstruction[1]));
                    operations.Add(currentInstruction[0]);
                }

                for (int i = 0; i < lengg;)
                {
                    if (operations[i] == "nop")
                    {
                        usedIndexes.Add(i);

                        // essentially checking if loop has started again
                        if (usedIndexes.Count != usedIndexes.Distinct().Count())
                        {
                            break;
                        }
                        else
                            i++;
                    }

                    if (operations[i] == "acc")
                    {
                        usedIndexes.Add(i);
                        if (usedIndexes.Count != usedIndexes.Distinct().Count())
                        {
                            break;
                        }
                        else
                            accumulatorCount = accumulatorCount + arguments[i];
                        i++;
                    }

                    if (operations[i] == "jmp")
                    {
                        usedIndexes.Add(i);
                        if (usedIndexes.Count != usedIndexes.Distinct().Count())
                        {
                            break;
                        }
                        else
                            i = arguments[i] + i;
                    }

                    if (i == lengg)
                    {
                        return accumulatorCount;
                    }
                }
            }
            throw new InvalidOperationException("No suitable alteration found to end program");
        }


        static int Part1_FindAccumulatorValue(bool useMyMap)
        {
            int accumulatorCount = 0;

            // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file, holds in lines
            string[] lines = File.ReadAllLines(text);

            int lengg = lines.Length;

            List<string> operations = new List<string>();
            List<int> arguments = new List<int>();
            List<int> usedIndexes = new List<int>();

            for (int i = 0; i < lengg; i++)
            {
                var currentLine = lines[i];

                string[] currentInstruction;

                currentInstruction = currentLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                arguments.Add(int.Parse(currentInstruction[1]));
                operations.Add(currentInstruction[0]);
            }

            for (int i = 0; i < lengg;)
            {
                if (operations[i] == "nop")
                {
                    usedIndexes.Add(i);

                    // essentially checking if loop has started again
                    if (usedIndexes.Count != usedIndexes.Distinct().Count())
                    {
                        break;
                    }
                    else
                        i++;
                }

                if (operations[i] == "acc")
                {
                    usedIndexes.Add(i);
                    if (usedIndexes.Count != usedIndexes.Distinct().Count())
                    {
                        break;
                    }
                    else
                        accumulatorCount = accumulatorCount + arguments[i];
                    i++;
                }

                if (operations[i] == "jmp")
                {
                    usedIndexes.Add(i);
                    if (usedIndexes.Count != usedIndexes.Distinct().Count())
                    {
                        break;
                    }
                    else
                        i = arguments[i] + i;
                }
            }
            return accumulatorCount;
        }
    }
}

// operation:
// acc, jump, nop

// argument:
// signed number (e.g. +4 or -20)

// acc:
// increase/ decrease 'accumulator'
// by whatever is in argument
// accumulator starts at 0

// jmp:
// jumps to new instruction
// depends on argument number
// jmp +1 -> instruction immediately below
// jmp -20 -> instruction 20 lines above next

// nop:
// does nothing
// instruction immediately below executed next

// find value of accuulator before the loop is executed again
