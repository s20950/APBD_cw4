using System.Collections.Generic;
using Cw4.Models;

namespace Cw4.Services
{
    public class MockAnimalService : IDatabaseService
    {
        public static List<Animal> Animals { get; set; } = new List<Animal>();

        public int CreateAnimal(Animal newAnimal)
        {
            Animals.Add(newAnimal);
            return 1;
        }

        public int DeleteAnimal(int idAnimal)
        {
            foreach (var animal in Animals)
            {
                if (animal.IdAnimal == idAnimal)
                {
                    Animals.Remove(animal);
                    return 1;
                }
            }
            return 0;
        }

        public Animal GetAnimal(int idAnimal)
        {
            foreach (var animal in Animals)
            {
                if (animal.IdAnimal == idAnimal)
                    return animal;
            }
            return null;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return Animals;
        }

        public int UpdateAnimal(int idAnimal, Animal updatedAnimal)
        {
            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].IdAnimal == idAnimal)
                {
                    Animals[i] = updatedAnimal;
                    return 1;
                }
            }
            return 0;
        }
    }
}