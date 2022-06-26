using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЗАПОВІДНИК
{
    public class MemoryFactory: IFactory
    {
        public AnimalArray GetAnimalArray()
        {
            return new AnimalArrayInMemory();
        }
    }
} 
