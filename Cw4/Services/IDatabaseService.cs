using System.Collections.Generic;
using Cw4.Models;

namespace Cw4.Services
{
    public interface IDatabaseService
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimal(int idAnimal);
        int UpdateAnimal(int idAnimal, Animal updatedAnimal);
        int DeleteAnimal(int idAnimal);
        int CreateAnimal(Animal newAnimal);
    }
}