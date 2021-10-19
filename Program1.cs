using System;
using System.Collections.Generic;
using System.Linq;

namespace practice7_1
{
    class Program
    {
        static Dictionary<string, string> word= new Dictionary<string, string>
        {
            ["I"]= "Boy" ,
            ["go"]="run" ,
            ["to"] = "to",
            ["school"] = "cinema"
        };


        static void Main(string[] args)
        {
            string Text = "I go to scool.Girl runs to school";
            string[] sentence = Text.Split('.');
            string Temp = "";
            for (int r = 0; r < sentence.Length; r++)
            {
                string[] temp = sentence[r].Split(' ');
                int k = 0;
                foreach (var i in temp)
                {
                    if (word.ContainsKey(i))
                    {
                        temp[k] = word[i];
                    }
                    Temp += temp[k];
                    if (k + 1 < temp.Length)
                        Temp += " ";
                    else
                        Temp += ". ";
                    k++;
                }
            }
            Text = Temp;
            Console.WriteLine(Text);
            
        }
    }
}
