using System;
using ЗАПОВІДНИК;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    public class EmployeeMenu
    {
        public static AnimalArray animalArrayObject;


        public static void SafeEmployeeMenu()
        {
            animalArrayObject = FactoryCreator.GetFactory().GetAnimalArray();
            if (animalArrayObject.GetType() == typeof(AnimalArray)) { animalArrayObject.AppendArray(); };
            int userInput = 0;
            var myExeption = WorkWithExeptionFileSingleton.Instance;
            do
            {
                try
                {
                    ShowMenu();
                    int.TryParse(Console.ReadLine(), out userInput);
                    if (userInput == 0) { break; }//точка виходу
                    EmployeeMenuCommand(userInput);
                }
                catch (MyException ex)
                {
                    myExeption.WriteText($"{ex.Data}{ex.Message}\n");
                    Console.WriteLine(ex.Message);
                }
            } while (userInput != '0');
            myExeption.Save();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Вітаємо, ви увійшли в меню заповідника «Ґорґани»\n");
            Console.WriteLine("Виберіть опцію : ");
            Console.WriteLine("0) Вийти з меню ;");
            Console.WriteLine("1) Додати до списку новий вид тварин ;");
            Console.WriteLine("2) Видрукувати список усіх тварин;\n");
        }

        private static void EmployeeMenuCommand(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    AddAnimalInstruction();
                    
                    if (animalArrayObject.GetType() == typeof(AnimalArray)) { WorkWithAnimalFile temp = new WorkWithAnimalFile();  temp.WriteInfoToFile(); };
                    break;
                case 2:
                    Console.WriteLine("\nCписок усіх тварин :\n" + animalArrayObject.ArrayAnimalToString());
                    break;
                default:
                    throw new MyException(MyExceptionKind.WrongUserInputExeption, "\nError : Невірна кованда. Спробуйте Знову.\n");
                    break;
            };
        }

        private static void AddAnimalInstruction()
        {
            int groupSelectedByUser;
            string newspecies;
            string boolrare;

            do
            {
                Console.WriteLine("\nОберіть до якої з навединих груп ви хочете додати тварину : ");
                Console.WriteLine("0) Якщо хочете повернутися до головного меню ;");
                ShowListOfGroupOfAnimal();
                int.TryParse(Console.ReadLine(), out groupSelectedByUser);
                if (groupSelectedByUser == 0) { Console.WriteLine(); break; }
                if (groupSelectedByUser < 0 || groupSelectedByUser >= 6) 
                {
                    throw new MyException(MyExceptionKind.WrongUserInputExeption,"\nError : Невірна кованда. Спробуйте Знову.\n");
                    break;
                }
                Console.WriteLine("\nВведіть вид нової тварини :");
                newspecies = Console.ReadLine();
                Console.WriteLine("Чи занесений до Червоної Книги (так/ні):");
                boolrare = Console.ReadLine();
                animalArrayObject.AddAnimalToArray(new Animal(groupSelectedByUser, newspecies, boolrare));

            } while (groupSelectedByUser != 0);
        }

        private static void ShowListOfGroupOfAnimal()
        {
            Console.WriteLine("1) Ссавці ;");
            Console.WriteLine("2) Риби ; ");
            Console.WriteLine("3) Птахи ;" );
            Console.WriteLine("4) Рептилії ;");
            Console.WriteLine("5) Амфібії ;\n");
        }
    }
}
