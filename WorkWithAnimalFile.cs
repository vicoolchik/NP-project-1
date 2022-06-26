using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ЗАПОВІДНИК
{
    public class WorkWithAnimalFile
    {
        public AnimalArray temp ;
        private const string filePath = @"C:\work\c#\ЗАПОВІДНИК_2.0\ЗАПОВІДНИК\animal.txt";

        public static List<string> GetInfoFromFileToList()
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader((filePath), Encoding.GetEncoding(1251)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return lines;
        }

        public  void WriteInfoToFile()
        {
            temp = new AnimalArray();
            var enc1251 = Encoding.GetEncoding(1251);
            try
            {
                string infoToFile = "";
                using (StreamWriter sw = new StreamWriter(filePath,false, encoding: enc1251))
                {
                    for (int i = 1; i < 6; i++)
                    {
                        List<Animal> tempList =temp.ArrayAnimalSpecificGroup(i);
                        infoToFile += $"Усі види {(GroupEnum)tempList[0].Group}:\n";
                        for (int j = 0; j < tempList.Count; j++)
                        {
                            infoToFile += $"{tempList[j].Species}, {tempList[j].ListedInRedBook};\n";
                        }
                    }
                    sw.Write(infoToFile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }

}
