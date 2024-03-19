using System;
using System.Collections;
using System.IO;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        // Read array structure from JSON file
        ArrayList exampleArray = ReadArrayFromFile("arrays.json");

        // Flatten the example array
        List<int> flattenedArray = FlattenArray(exampleArray);

        // Print the flattened array
        foreach (var item in flattenedArray)
        {
            Console.WriteLine(item);
        }
    }

    static ArrayList ReadArrayFromFile(string filename)
    {
        using (StreamReader sr = new StreamReader(filename))
        {
            StringBuilder json = new StringBuilder();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                json.Append(line);
            }
            return ParseArray(json.ToString());
        }
    }

    static ArrayList ParseArray(string json)
    {
        ArrayList array = new ArrayList();
        json = json.Trim();
        if (json[0] == '[' && json[json.Length - 1] == ']')
        {
            json = json.Substring(1, json.Length - 2);
            int start = 0;
            int end = 0;
            for (int i = 0; i < json.Length; i++)
            {
                if (json[i] == '[')
                {
                    int count = 1;
                    for (int j = i + 1; j < json.Length; j++)
                    {
                        if (json[j] == '[')
                            count++;
                        else if (json[j] == ']')
                            count--;
                        if (count == 0)
                        {
                            end = j;
                            break;
                        }
                    }
                    array.Add(ParseArray(json.Substring(i, end - i + 1)));
                    i = end;
                }
                else if (json[i] == ',')
                {
                    array.Add(int.Parse(json.Substring(start, i - start).Trim()));
                    start = i + 1;
                }
            }
            if (start < json.Length)
                array.Add(int.Parse(json.Substring(start).Trim()));
        }
        else
        {
            array.Add(int.Parse(json.Trim()));
        }
        return array;
    }

    static List<int> FlattenArray(ArrayList array)
    {
        List<int> flattened = new List<int>();
        foreach (var item in array)
        {
            if (item is ArrayList)
            {
                flattened.AddRange(FlattenArray((ArrayList)item));
            }
            else if (item is int)
            {
                flattened.Add((int)item);
            }
        }
        return flattened;
    }
}