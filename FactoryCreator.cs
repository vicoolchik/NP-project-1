using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЗАПОВІДНИК
{
    static public class FactoryCreator
    {
        public static IFactory GetFactory()
        {
            int userInput = 0;
            Console.WriteLine("Необхідно обрати Factory :\n1) Memory Factory ;\n2) Text Factory ;\n");
            int.TryParse(Console.ReadLine(), out userInput);
            return new TextFactory();
            switch (userInput)
            {
                case 1:
                    return new MemoryFactory();
                    break;
                case 2:
                    return new TextFactory();
                    break;
                default:
                    return new TextFactory();
                    throw new MyException(MyExceptionKind.WrongUserInputExeption, "\nError : Невірна кованда. Спробуйте Знову.\n");
                    break;
            }
        }
    }
}
