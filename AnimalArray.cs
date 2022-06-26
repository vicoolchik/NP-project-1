using System;
using System.Collections.Generic;
using System.Text;

namespace ЗАПОВІДНИК
{
    public class AnimalArray
    {
        
        private static List<Animal> arrayAnimal=new List<Animal>();
        
        private  int animalCountStartWork ;

        public AnimalArray()
        {
        }

        public int Count()
        {
            return arrayAnimal.Count;
        }

        public List<Animal> GetAll() { return arrayAnimal; }

        public  int AnimalCountStartWork { get => animalCountStartWork; }

        public  List<Animal> ArrayAnimalSpecificGroup(int group)//friend
        {
            List<Animal> arrayAnimalSpecificGroup=new List<Animal>();
            for (int i=0 ; i<arrayAnimal.Count; i++)
            {
                if (group == (int)arrayAnimal[i].Group ) arrayAnimalSpecificGroup.Add(arrayAnimal[i]);
            }
            return arrayAnimalSpecificGroup;
        }

        public Animal this[int value]
        {
            get => arrayAnimal[value - 1];
        }

        public virtual string ArrayAnimalToString()
        {
            
            string arrayAnimalToString=$"| №    | царство  | вид{new string(' ',17)} | занесені до Червоної книги |\n";
            int tempIndex = 1;
            for (int i=1; i<6; i++)
            {
                List<Animal> arrayAnimalSpecificGroup = ArrayAnimalSpecificGroup(i);
                for (int j =0; j<arrayAnimalSpecificGroup.Count; j++, tempIndex++)
                {
                    //arrayAnimalToString += $"{arrayAnimalSpecificGroup[j].ToString()}\n";
                    arrayAnimalToString += String.Format("| {0,-4} | {1,-8} | {2,-20} | {3,-26} |\n", 
                        tempIndex,
                        (GroupEnum)arrayAnimalSpecificGroup[j].Group, 
                        arrayAnimalSpecificGroup[j].Species,
                        arrayAnimalSpecificGroup[j].ListedInRedBook);
                
                }
            }
            return arrayAnimalToString;
        }

        public string AnimalListedInRedBookToString()
        {
            string animalListedInRedBookToString = "";
            for (int i = 0; i < arrayAnimal.Count; i++)
            {
                if (arrayAnimal[i].ListedInRedBook == "так") animalListedInRedBookToString += arrayAnimal[i].ToString() + "\n";
            }
            return animalListedInRedBookToString;
        }
        public List<Animal> AnimalListedInRedBook()
        {
            List<Animal> animalListedInRedBook=new List<Animal>();
            for (int i = 0; i < arrayAnimal.Count; i++)
            {
                if (arrayAnimal[i].ListedInRedBook == "yes") animalListedInRedBook.Add(arrayAnimal[i]);
            }
            return animalListedInRedBook;
        }

        public virtual void AddAnimalToArray( Animal newAnimal)
        {
            arrayAnimal.Add(newAnimal);
        }

        public  void AppendArray()
        {
            List<string> lines = WorkWithAnimalFile.GetInfoFromFileToList();
            Animal tempAnimal=new Animal();
            foreach(string line in lines)
            {
                Animal animalFromFile=WorkWithLine.FromLineToAnimal(line);
                if (animalFromFile.Species == "")
                {
                    tempAnimal.Group = animalFromFile.Group;
                    continue;
                }
                if (animalFromFile.Group == 0)
                {
                    animalFromFile.Group= tempAnimal.Group;

                    AddAnimalToArray( animalFromFile);
                }     
            }
            // = new List<Animal>();
            animalCountStartWork = (int)arrayAnimal.Count;
        }

        public  void AnimalArrayApdate()
        {
            List<string> animalCount = WorkWithAnimalFile.GetInfoFromFileToList();
            if ((animalCount.Count-5) != animalCountStartWork)
            {
                arrayAnimal.Clear();
                AppendArray();
            }
        }

        public void AddIDToAnimalArray()
        {
            int id = 1;
            for (int i = 0; i < arrayAnimal.Count; i++, id++)
            {
                arrayAnimal[i].ID = id;
            }
        }

        public void Clear()
        {
            arrayAnimal.Clear();
        }

    }

 
    
}
