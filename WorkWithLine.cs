using System;
using System.Collections.Generic;
using System.Text;


namespace ЗАПОВІДНИК
{
    public class WorkWithLine
    {
        
        public static Animal FromLineToAnimal(string line)
        {
            Animal animalFromLine =new Animal();
            if (line[0] == 'У')
            {
                for (int i=1; i<6; i++)
                {
                    if (line[9..^1] == ((GroupEnum)i).ToString("g"))
                    {
                        animalFromLine.Group = i;
                        break;
                    }
                }
            }
            else
            {
                string[] tempLine = line.Split(", ");
                animalFromLine.Species = tempLine[0];
                string tempLine2 = tempLine[1];
                animalFromLine.ListedInRedBook = tempLine2[..^1]; 
            }
            return animalFromLine;
        }
    }
}
