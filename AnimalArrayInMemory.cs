using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЗАПОВІДНИК
{
    public class AnimalArrayInMemory: AnimalArray
    {
        private  new List<Animal> arrayAnimal;

        public AnimalArrayInMemory()
        {
            arrayAnimal = new List<Animal>();
        }
        public override string ArrayAnimalToString()
        {
            int tempIndex = 1;
            string arrayAnimalToString = $"| №    | царство  | вид{new string(' ', 17)} | занесені до Червоної книги |\n";

            for (int j = 0; j < arrayAnimal.Count; j++,tempIndex++)
            {
                //arrayAnimalToString += $"{arrayAnimalSpecificGroup[j].ToString()}\n";
                arrayAnimalToString += String.Format("| {0,-4} | {1,-8} | {2,-20} | {3,-26} |\n",
                    tempIndex,
                    (GroupEnum)arrayAnimal[j].Group,
                    arrayAnimal[j].Species,
                    arrayAnimal[j].ListedInRedBook);

            }

            return arrayAnimalToString;
        }

        public override void AddAnimalToArray(Animal newAnimal)
        {
            arrayAnimal.Add(newAnimal);
        }
    }
}
