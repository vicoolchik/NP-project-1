using System;

namespace ЗАПОВІДНИК
{
    public enum GroupEnum
    {
        ссавець=1,
        риба,
        птах,
        рептилія,
        амфібія
    }

    public class Animal
    {
        private int id;
        public int group;
        private string species;
        private string listedInRedBook;

        public int ID { get => id; set => id = value; }
        public int Group { get => group; set => group = value; }
        public string Species { get => species; set => species = value; }
        public string ListedInRedBook { get => listedInRedBook; set => listedInRedBook = value; }

        public Animal(int group = 0, string species="", string listedInRedBook="")
        {
            this.group = group;
            this.species = species;
            this.listedInRedBook = listedInRedBook;
        }

        public override string ToString()
        {
            return $"Царство тварини - {(GroupEnum)Group} , вид тварини - {Species} , чи занесена до Червоної книги - {ListedInRedBook}";
        }

        public static bool operator == (Animal animal1, Animal animal2)
        {
            return (animal1.Group == animal2.Group && animal1.Species == animal2.Species && animal1.ListedInRedBook == animal2.ListedInRedBook);
        }

        public static bool operator !=(Animal animal1, Animal animal2)
        {
            return !(animal1.Group == animal2.Group && animal1.Species == animal2.Species && animal1.ListedInRedBook == animal2.ListedInRedBook);
        }
    }
    
}
