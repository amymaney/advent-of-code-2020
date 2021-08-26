using System;

namespace day8_part1_part2
{
    class Program
    {
        static void Main()
        {
            
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
