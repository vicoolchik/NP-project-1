using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ЗАПОВІДНИК
{
    public class WorkWithExeptionFileSingleton
    {
        private static readonly Lazy<WorkWithExeptionFileSingleton> instance =
            new Lazy<WorkWithExeptionFileSingleton>(() => new WorkWithExeptionFileSingleton());

        public static WorkWithExeptionFileSingleton Instance { get=>instance.Value; }

        private string FilePath { get; }

        public string Text { get; private set; }

        private WorkWithExeptionFileSingleton()
        {
            FilePath = @"C:\work\c#\ЗАПОВІДНИК_2.0\ЗАПОВІДНИК\exception.txt";
        }

        public void WriteText(string text)
        {
            Text += text;
        }

        public void Save()
        {
            try
            {
                using (var writer = new StreamWriter(FilePath, true))
                {
                    writer.Write(Text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
    }
}
