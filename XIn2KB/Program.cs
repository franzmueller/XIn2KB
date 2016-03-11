using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XInputDotNetPure;

namespace XIn2KB
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename = "settings.xml";
            foreach(String arg in args)
            {
                if (!arg.Contains("xml"))
                    switch (arg)
                    {
                        case "help":
                        case "-help":
                        case "--help":
                            Console.WriteLine("Check the file readme.md and settings.xml for help!");
                            return;
                    }
                else
                    filename = arg;
            }


            RuleManager ruleManager = new RuleManager();     
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
            XDocument doc = XDocument.Load(filename);            
            var controllers = doc.Element("settings").Descendants("controller");
            foreach(var controller in controllers)
            {
                int playerIndex = Int32.Parse(controller.Element("playerindex").Value); //TODO Try Int32.TryParse
                var rules = controller.Descendants("rule");
                foreach(var rule in rules)
                {
                    int input = Int32.Parse(rule.Element("input").Value); //TODO Try Int32.TryParse                    
                    byte output = Convert.ToByte(rule.Element("output").Value, 16); //Maybe try this as well
                    Rule rrule = new Rule(input, output);

                    ruleManager.addRule(rrule, PlayerIndexHelper.Int32ToPlayerIndex(playerIndex));

                    Console.WriteLine("Added output \"" + output + "\" after input " + input + " on Controller " + playerIndex);
                }
            }
            if (ruleManager.hasRules())
            {
                while (true)
                {
                    ruleManager.runRules();
                    System.Threading.Thread.Sleep(5);
                }
            }
            else
            {
                Console.WriteLine("No rule found, please check "+filename+"\nPress any key to exit.");
                while (!Console.KeyAvailable)
                    System.Threading.Thread.Sleep(30);
            }
                
        }
    }
}
