using Microsoft.VisualStudio.TestTools.UnitTesting;
using ЗАПОВІДНИК;
using UserProject;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class AnimalArrayTest
    {
        [TestMethod]
        public void TestCompare2Animal()
        {
            Animal animal1 = new Animal(0, "f", "f");
            Animal animal2 = new Animal(0, "f", "f");

            bool expectResult = true;

            bool actualResult = animal1 == animal2;

            Assert.AreEqual(expectResult, actualResult);
        }

        [TestMethod]
        public void FindByIndexTest()
        {
            AnimalArray array1 = new AnimalArray();
            Animal animal1 = new Animal(0, "g", "f");
            array1.AddAnimalToArray(animal1);
            int index=0;
            for (int i = 0; i < array1.Count(); i++)
            {
                if (array1[i+1] == animal1) {  index = i; }
            }

            if (array1[index+1] == animal1) Assert.IsTrue(true);
            else { Assert.IsTrue(false); }
        }

        [TestMethod]
        public void ArrayAnimalSpecificGroupTest()
        {
            AnimalArray array1 = new AnimalArray();
            Animal animal1 = new Animal(0, "f", "f");
            array1.AddAnimalToArray(animal1);
            List<Animal> list1 = array1.ArrayAnimalSpecificGroup(0);
            bool actualResult = false;
            
            for (int i=0; i<list1.Count; i++)
            {
                if (list1[i] == animal1) { actualResult = true; } 
            }
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void IDToAnimalArrayxTest()
        {
            AnimalArray array1 = new AnimalArray();
            Animal animal1 = new Animal(0, "f", "f");
            array1.AddAnimalToArray(animal1);

            array1.AddIDToAnimalArray();
            if (array1[3].ID == 3) Assert.IsTrue(true);
            else { Assert.IsTrue(false); }
        }

        [TestMethod]
        public void AnimalListedInRedBookTest()
        {
            AnimalArray array1 = new AnimalArray();
            Animal animal1 = new Animal(0, "f", "yes");
            array1.AddAnimalToArray(animal1);
            List<Animal> list1 = array1.AnimalListedInRedBook();
            bool actualResult = false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] == animal1) { actualResult = true; }
            }
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void FromLineToAnimalTest()
        {
            string animalstring = "Усі види ссавець:";
            Animal animal1 = new Animal(1);
            if (WorkWithLine.FromLineToAnimal(animalstring).ToString() == animal1.ToString()) Assert.IsTrue(true);
            else { Assert.IsTrue(false); }
        }

        [TestMethod]
        public void UserMenuComandTest_ThrowsException()
        {
            Assert.ThrowsException<MyException>(() => UserMenu.UserMenuComand(10));
        }

        [TestMethod]
        public void AppendArrayTest()
        {
            AnimalArray array1 = new AnimalArray();
            array1.Clear();
            array1.AppendArray();
            List<string> animalCount = WorkWithAnimalFile.GetInfoFromFileToList();
            if ((animalCount.Count - 5) != array1.Count()) Assert.IsTrue(true);
            else { Assert.IsTrue(false); }
        }

        [TestMethod]
        public void ToStringTest()
        {
            string animalstring = "Царство тварини - 0 , вид тварини - f , чи занесена до Червоної книги - f";
            AnimalArray array1 = new AnimalArray();
            array1.Clear();
            Animal animal1 = new Animal(0, "f", "f");
            array1.AddAnimalToArray(animal1);
            if (animalstring == array1[1].ToString()) { Assert.IsTrue(true); }
            else { Assert.IsTrue(false); }
        }

        [TestMethod]
        public void NotEqualAnimalTest()
        {
            Animal animal1 = new Animal(0, "f", "f");
            Animal animal2 = new Animal(0, "f", "g");
            if (animal1 != animal2) { Assert.IsTrue(true); }
            else { Assert.IsTrue(false); }
        }
    }
}