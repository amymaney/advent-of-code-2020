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
            //Console.WriteLine(NoOfPassports1(false));

            // PART 2  
            Console.WriteLine(NoOfPassports2(false));
            
        }

         static int NoOfPassports1(bool useMyMap)
        {
            // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file
            string[] lines = File.ReadAllLines(text);

            // holds number of valid passports
            int validPassport = 0;

            // length of list
            int lengg = lines.Length;

            List<string> currentPassport = new List<string>();

            string[] requiredPassportFields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

            string byr = requiredPassportFields[0];
            string iyr = requiredPassportFields[1];
            string eyr = requiredPassportFields[2];
            string hgt = requiredPassportFields[3];
            string hcl = requiredPassportFields[4];
            string ecl = requiredPassportFields[5];
            string pid = requiredPassportFields[6];
            

            for(int i=0; i<lengg; i++)
            {

                string joinedPassport = " ";

                // takes the current passport into one list
                do
                {
                    currentPassport.Add(lines[i]);
                    i++;
                }
                while(i<lengg && lines[i].Length != 0);

                // puts the list holding current passport into a single string
                joinedPassport = string.Join(" ", currentPassport);

                // check if current passport contains all 7 required fields
                bool isValid = requiredPassportFields.All(field => joinedPassport.Contains(field));

                // adds one to no. of valid passports if current contains all field
                if(isValid)
                {
                    validPassport++;
                }

                // clears the list containing the current passport
                currentPassport.Clear();
           
            }

            return validPassport;
    
        }



        static int NoOfPassports2(bool useMyMap)
        {
            // to swap between example map and real map (for testing)
            string text = useMyMap ? @"sample.txt" : "input.txt";

            // reads the file
            string[] lines = File.ReadAllLines(text);

            // holds number of valid passports
            int validPassport2 = 0;

            int validFields = 0;

            // length of list
            int lengg = lines.Length;

            // holds current passport we are looking at
            List<string> currentPassport = new List<string>();

            string[] requiredPassportFields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

            string byr = requiredPassportFields[0];
            string iyr = requiredPassportFields[1];
            string eyr = requiredPassportFields[2];
            string hgt = requiredPassportFields[3];
            string hcl = requiredPassportFields[4];
            string ecl = requiredPassportFields[5];
            string pid = requiredPassportFields[6];

            string joinedPassport = " ";

            // only certain colours allowed
            string[] ecl_allowedvalues = {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

            // only years between 1920 and 2002 allowed
            int[] byr_allowedvalues1 = Enumerable.Range(1920, 83).ToArray();
            List<string> byr_allowedvalues = new List<string>(); 
            for(int i=0; i<byr_allowedvalues1.Length; i++)
            {
                byr_allowedvalues.Add(byr_allowedvalues1[i].ToString());
            }
            
            // only years between 2010 and 2020 allowed
            int[] iyr_allowedvalues1 = Enumerable.Range(2010, 11).ToArray();
            List<string> iyr_allowedvalues = new List<string>(); 
            for(int i=0; i<iyr_allowedvalues1.Length; i++)
            {
                iyr_allowedvalues.Add(iyr_allowedvalues1[i].ToString());
            }

            // only years between 2020 and 2030 allowed
            int[] eyr_allowedvalues1 = Enumerable.Range(2020, 11).ToArray();
            List<string> eyr_allowedvalues = new List<string>(); 
            for(int i=0; i<eyr_allowedvalues1.Length; i++)
            {
                eyr_allowedvalues.Add(eyr_allowedvalues1[i].ToString());
            }

            // hair colours have # followed by exactly 6 chars either 0-9 or a-f
            string hcl_allowedvalues = "^#[a-f0-9][a-f0-9][a-f0-9][a-f0-9][a-f0-9][a-f0-9]$";

            // heights are 150-193cm or 59-76in
            string hgt_allowedvaluescm = "[1][5-9][0-3]cm";
            string hgt_allowedvaluesin = "[6-7][0-6]in";
            string hgt_allowedvaluesin2 = "[5][9]in";
            string hgt_allowedvaluescm2 = "[1][5-8][4-9]cm";
            string hgt_allowedvaluesin3 = "[6][7-9]";
            
            
            
            // pid only 9 digit numbers
            string pid_allowedvalues = "^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$";

            // takes the current passport into one list
            for(int i = 0; i <lengg; i++)
            {
                do
                {
                    currentPassport.Add(lines[i]);
                    i++;
                }
                while(i<lengg && lines[i].Length != 0);

                // puts the list holding current passport into a single string
                joinedPassport = string.Join(" ", currentPassport);

                // split
                string[] splitPassport;

                splitPassport = joinedPassport.Split(new[] {' ', ':'}, StringSplitOptions.RemoveEmptyEntries);

                int byr_index = 0;
                int iyr_index = 0;
                int eyr_index = 0;
                int hgt_index = 0;
                int hcl_index = 0;
                int ecl_index = 0;
                int pid_index = 0;

                for(int x = 0; x < splitPassport.Length; x++)
                {
                    byr_index = Array.FindIndex(splitPassport, row => row.Contains(byr));
                    iyr_index = Array.FindIndex(splitPassport, row => row.Contains(iyr));
                    eyr_index = Array.FindIndex(splitPassport, row => row.Contains(eyr));
                    ecl_index = Array.FindIndex(splitPassport, row => row.Contains(ecl));
                    hcl_index = Array.FindIndex(splitPassport, row => row.Contains(hcl));
                    hgt_index = Array.FindIndex(splitPassport, row => row.Contains(hgt));
                    pid_index = Array.FindIndex(splitPassport, row => row.Contains(pid));
                }

                    validFields = 0;

                    // ecl
                    bool isValid = ecl_allowedvalues.Any(field => splitPassport[ecl_index+1].Contains(field));
                    if(isValid)
                    {
                        validFields++;
                    }

                    // byr
                    isValid = byr_allowedvalues.Any(field => splitPassport[byr_index+1].Contains(field));
                    if(isValid)
                    {
                        validFields++;
                    }

                    // iyr
                    isValid = iyr_allowedvalues.Any(field => splitPassport[iyr_index+1].Contains(field));
                    if(isValid)
                    {
                        validFields++;
                    }

                    // eyr
                    isValid = eyr_allowedvalues.Any(field => splitPassport[eyr_index+1].Contains(field));
                    if(isValid)
                    {
                        validFields++;
                    }

                    
                    // hcl
                    int validhcl = 0;
                    if(splitPassport[hcl_index+1].Length == 7)
                    {
                        validhcl++;
                    }
                    
                    bool hcl_yes = Regex.IsMatch(splitPassport[hcl_index+1], hcl_allowedvalues);
                    if(hcl_yes == true)
                    {
                        validhcl++;
                    }

                    if(validhcl == 2)
                    {
                        validFields++;
                    }

                    // hgt
                    bool hgt_cm = Regex.IsMatch(splitPassport[hgt_index+1], hgt_allowedvaluescm);
                    bool hgt_in = Regex.IsMatch(splitPassport[hgt_index+1], hgt_allowedvaluesin);
                    bool hgt_in2 = Regex.IsMatch(splitPassport[hgt_index+1], hgt_allowedvaluesin2);
                    bool hgt_cm2 = Regex.IsMatch(splitPassport[hgt_index+1], hgt_allowedvaluescm2);
                    bool hgt_in3 = Regex.IsMatch(splitPassport[hgt_index+1], hgt_allowedvaluesin3);

                    if((hgt_cm || hgt_in || hgt_in2 || hgt_cm2 || hgt_in3) == true)
                    {
                        validFields++;
                    }

                    // pid
                    int validpid = 0;
                    if(splitPassport[pid_index+1].Length == 9)
                    {
                        validpid++;
                    }
                    bool pid_yes = Regex.IsMatch(splitPassport[pid_index+1], pid_allowedvalues);
                    if(pid_yes == true)
                    {
                        validpid++;
                    }

                    if(validpid == 2)
                    {
                        validFields++;
                    }

                    if(validFields == 7)
                    {
                        validPassport2++;
                    }

                
                currentPassport.Clear();
            }


            return validPassport2;

        }
    }
}

