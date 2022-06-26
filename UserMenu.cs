using System;
using ЗАПОВІДНИК;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProject
{

    public class UserMenu
    {
        public static AnimalArray animalArrayObject;

        private static void ShowMenu()
        {
            Console.WriteLine("Вітаємо, ви увійшли в меню заповідника «Ґорґани»\n");
            Console.WriteLine("Виберіть опцію : ");
            Console.WriteLine("0) Вийти з меню ;");
            Console.WriteLine("1) Переглянути інформацію про екскурсії;");
            Console.WriteLine("2) Видрукувати список усіх тварин;");
            Console.WriteLine("3) Видрукувати список усіх тварин занесених до Червоної книги;");
            Console.WriteLine("4) Видрукувати тварину із списку за індексом ;");
            Console.WriteLine("5) Порівняти двох тварину із  списку;\n");
        }

        public static void SafeUserMenu()
        {
            animalArrayObject = FactoryCreator.GetFactory().GetAnimalArray();
            int userInput = 0;
            var myExeption = WorkWithExeptionFileSingleton.Instance;
            do
            {
                try
                {
                    ShowMenu();
                    int.TryParse(Console.ReadLine(), out userInput);
                    if (userInput == 0) { break; }//точка виходу
                    UserMenuComand(userInput);
                }
                catch (MyException ex)
                {
                    myExeption.WriteText($"{ex.Data}{ex.Message}\n");
                    Console.WriteLine(ex.Message);
                }
            } while (userInput != '0');
            myExeption.Save();
        }


        public static void UserMenuComand(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    Excursions();
                    break;
                case 2:
                    if (animalArrayObject.GetType() == typeof(AnimalArray))
                    {
                        animalArrayObject.AnimalArrayApdate();
                    }
                    Console.WriteLine("\nCписок усіх тварин :\n" + animalArrayObject.ArrayAnimalToString());
                    break;
                case 3:
                    if (animalArrayObject.GetType() == typeof(AnimalArray))
                    {
                        animalArrayObject.AnimalArrayApdate();
                    }
                    Console.WriteLine("\nУсі види тварин записаних до Червоної Книги :\n" + animalArrayObject.AnimalListedInRedBookToString());
                    break;
                case 4:
                    int index;
                    Console.WriteLine("\nВедіть індекс тварини :\n");
                    int.TryParse(Console.ReadLine(), out index);
                    if (index > animalArrayObject.AnimalCountStartWork || index < 1)
                    { throw new MyException(MyExceptionKind.WrongIndexExeption,"\nНеіснуючий індекс. Спробуйте Знову.\n"); }
                    //AnimalArray tempArray = new AnimalArray();
                    Console.WriteLine($"\n{animalArrayObject[index].ToString()}\n");
                    break;
                case 5:
                    int index1;
                    int index2;
                    Console.WriteLine("\nВедіть індекс тварини  :\n");
                    int.TryParse(Console.ReadLine(), out index1);
                    if (index1 > animalArrayObject.AnimalCountStartWork || index1 < 1)
                    { throw new MyException(MyExceptionKind.WrongIndexExeption,"\nНеіснуючий індекс. Спробуйте Знову.\n"); }
                    Console.WriteLine("\nВедіть індекс тварини з якою бажаєте порівняти :\n");
                    int.TryParse(Console.ReadLine(), out index2);
                    if (index2 > animalArrayObject.AnimalCountStartWork || index2 < 1)
                    { throw new MyException(MyExceptionKind.UnknownExeption,"\nНеіснуючий індекс. Спробуйте Знову.\n"); }
                        //AnimalArray tempArray1 = new AnimalArray();                    
                        if (animalArrayObject[index1] == animalArrayObject[index2]) Console.WriteLine("\nТварини еквівалентні\n");
                    else if (animalArrayObject[index1] != animalArrayObject[index2]) Console.WriteLine("\nТварини не еквівалентні\n");
                    else throw new MyException(MyExceptionKind.UnknownExeption,"\nError : Щось пішло не так. Спробуйте Знову.\n");
                    break;
                default:
                    
                    throw new MyException(MyExceptionKind.WrongUserInputExeption,"\nError : Невірна кованда. Спробуйте Знову.\n");
                    break;
            };
        }

        private static decimal PriceCalculator(int numberOfAdult, int numberOfChildren, int excursion)
        {
            if (excursion == 1)
            {
                return (decimal)((decimal)(numberOfAdult * 200) + (decimal)(numberOfChildren * 100));
            }
            else if (excursion == 2)
            {
                return (decimal)((decimal)(numberOfAdult * 50) + (decimal)(numberOfChildren * 25));
            }
            else if (excursion == 3)
            {
                return (decimal)((decimal)(numberOfAdult * 800) + (decimal)(numberOfChildren * 400));
            }
            return 0;
        }

        private static void Excursions()
        {
            int userInput=0;
            int numberOfAdult;
            int numberOfChildren;
            int excursion;

            do
            {
                Console.WriteLine("\n0) Повернутися до головного меню ;");
                Console.WriteLine("1) Види екскурсій ;");
                Console.WriteLine("2) Прайс-лист ;");
                Console.WriteLine("3) Калькулятор ціни ;\n");
                int.TryParse(Console.ReadLine(), out userInput);
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("\n1) Піша екскурсія;\n2) Онлайн екскурсія;\n3) Сафарі;\n");
                        break;
                    case 2:
                        Console.WriteLine("\nДля дітей віком до 12 років знижка 50% ;\n1) Піша екскурсіяж - 200 грн ;\n2) Онлайн екскурсія - 50 грн ;\n3) Сафарі - 800 грн ;\n");
                        break;
                    case 3:
                        Console.WriteLine("\nВиберіть одну із запропонованих екскурсій :\n");
                        int.TryParse(Console.ReadLine(), out excursion);
                        if(excursion>=4||excursion<=0) throw new MyException(MyExceptionKind.WrongUserInputExeption,"\nError : Невірна кованда. Спробуйте Знову.\n");
                        Console.WriteLine("\nВедіть кількість дорослих :\n");
                        int.TryParse(Console.ReadLine(), out numberOfAdult);
                        Console.WriteLine("\nВедіть кількість дітей :\n");
                        int.TryParse(Console.ReadLine(), out numberOfChildren);
                        Console.WriteLine($"\nВартість екскурсії = {PriceCalculator(numberOfAdult, numberOfChildren, excursion)}\n");
                        break;
                    default:
                        throw new MyException(MyExceptionKind.WrongUserInputExeption,"\nError : Невірна кованда. Спробуйте Знову.\n");
                        break;
                }
            } while (userInput != '0');
        }
    }


}


