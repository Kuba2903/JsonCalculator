using Newtonsoft.Json;

namespace Launcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> values = new List<double>();
            string json = File.ReadAllText("C:\\Users\\bigie\\source\\repos\\JsonCalculator\\Launcher\\input.json");

            var data = JsonConvert.DeserializeObject<Dictionary<string,Data>>(json);

            double result = 0;
            int counter = 1;

            foreach (var x in data)
            {
                x.Value.ObjName = $"obj{counter}";
                switch (x.Value.Operator) {
                    
                    case "add":
                        result = x.Value.Value1 + x.Value.Value2;
                        break;
                    case "sub":
                        result = x.Value.Value1 - x.Value.Value2;
                        break;
                    case "mul":
                        result = x.Value.Value1 * x.Value.Value2;
                        break;
                    case "div":
                        result = x.Value.Value1 / x.Value.Value2;
                        break;
                    case "sqrt":
                        result = (int)Math.Sqrt(x.Value.Value1);
                        break;
             }   
                
                values.Add(result);
                counter++;
            }

            var pairs = data.Select(x => new { ObjName = x.Value.ObjName, Value = values[data.Keys.ToList().IndexOf(x.Key)] });

            var sortedPairs = pairs.OrderBy(x => x.Value);

            string resultList = "";
            foreach (var pair in sortedPairs)
            {
                resultList += $"{pair.ObjName}: {pair.Value}\n";
            }

            string resultFilePath = "C:\\Users\\bigie\\source\\repos\\JsonCalculator\\Launcher\\output.txt";
            File.WriteAllText(resultFilePath, resultList);

            Console.WriteLine("Result successfully saved. \n");


            Console.WriteLine(resultList);
        }
    }
}