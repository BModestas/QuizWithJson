using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace ConsoleApp2
{
    public class Fruit
    {
        public int id { get; set; }
        public string fruit { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
        public int correct_answer { get; set; }
        //use list if there is list item in json []
        // public List<string> answers { get; set; }
    }
    public class Parsing
    {
        public static void Main(string[] args)
        {
            //Json file must be in bin>Debug directory
            string json = System.IO.File.ReadAllText("test.json");
            //install Newtonsoft nuGet
            var people = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Fruit>>(json);
            // taking every item in list
            List<int> ids =new List<int>();
            List<string> fruites = new List<string>();
            List<string> answerAs = new List<string>();
            List<string> answerBs = new List<string>();
            List<int> correct_answers = new List<int>();
            foreach (var item in people)
            {
                ids.Add(item.id);
                fruites.Add(item.fruit); 
                answerAs.Add(item.answerA);
                answerBs.Add(item.answerB);
                correct_answers.Add(item.correct_answer);
            }
            double count = 0;
            for (int i = 0; i < ids.Count; i++)
            {
                Console.WriteLine("What color is " + fruites[i] + "?");
                Console.WriteLine("1) " + answerAs[i]);
                Console.Write("2) " + answerBs[i] + " ");
                int ans = int.Parse(Console.ReadLine());               
                if (ans == correct_answers[i])
                {                                     
                    count++;
                }  
            }
            double percentage = (count * 100) / 3;
            if (percentage > 65)
            {
                Console.WriteLine("Great your result is " + percentage + "% you pass!!!!");
            }
        }
    }
}