using System;
using System.Collections.Generic;

namespace Abc3
{
    public class Blocks
    {
        public List<string> generateBlocks()
        {
            var sampleBlocks = new List<string>
            {
                "BO",
                "XK",
                "DQ",
                "CP",
                "NA",
                "GT",
                "RE",
                "TG",
                "QD",
                "FS",
                "JW",
                "HU",
                "VI",
                "AN",
                "OB",
                "ER",
                "FS",
                "LY",
                "PC",
                "ZM",
            };

            return sampleBlocks;
        }

        public bool CanMakeBlocks(string word, List<string> sampleBlocks)
        {
            word = word.ToUpper();

            var usedBlocks = new List<string>();
            
            

            for (var i = 0; i < word.Length; i++)
            {
                for (var j = 0; j < sampleBlocks.Count; j++)
                {
                    //Console.WriteLine("checking if block[j]:" + sampleBlocks[j] + "word[i]:" + word[i]);
                    
                    if (sampleBlocks[j].Contains(word[i]))
                    {
                        usedBlocks.Add(sampleBlocks[j]);
                        sampleBlocks.Remove(sampleBlocks[j]);
                        Console.WriteLine("{0} found at position{1}", word[i], j);
                        break;
                    }

                }

                if (usedBlocks.Count == word.Length)
                    return true;

            }
            
            return false;
            
        }
        
        public void RunABC()
        {
            Console.WriteLine("Enter your word: ");
            var input = Console.ReadLine();

            var sampleBlocks = generateBlocks();

            Console.WriteLine(CanMakeBlocks(input, sampleBlocks));

        }
        

    }
}

//There's a chance for an overshoot - so could you say usedBlocks.Count > word.Length, return false