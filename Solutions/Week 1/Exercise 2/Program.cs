using System;

// Animal Interface
interface IAnimal
{
    void MakeSound();
}

class Dog : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

class Cat : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}

// Factory class
class AnimalFactory
{
    public static IAnimal CreateAnimal(string animalType)
    {
        if (animalType.Equals("dog", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Dog Object created.");
            return new Dog();
        }
        else if (animalType.Equals("cat", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Cat Object created.");
            return new Cat();
        }
        else
        {
            Console.WriteLine("Invalid animal type.");
            return null;
        }
    }
}

// Main class
class Exercise2
{
    static void Main(string[] args)
    {
        // Requesting Dog Obj.
        Console.WriteLine("Requesting Dog:");
        IAnimal a1 = AnimalFactory.CreateAnimal("dog");
        a1?.MakeSound();

        // Requesting Cat Obj.
        Console.WriteLine("\nRequesting Cat:");
        IAnimal a2 = AnimalFactory.CreateAnimal("cat");
        a2?.MakeSound();

        // Requesting invalid animal
        Console.WriteLine("\nRequesting Bird:");
        IAnimal a3 = AnimalFactory.CreateAnimal("bird");
        a3?.MakeSound();
    }
}
