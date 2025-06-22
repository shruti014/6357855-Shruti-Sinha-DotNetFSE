# Factory Pattern

## Overview

This assignment demonstrates the **Factory Design Pattern** in Java using a simple console application. The Factory pattern provides a way to **create objects without specifying the exact class** of object that will be created.

This is particularly useful in scenarios such as:
- Creating objects based on input or configuration at runtime.
- Encapsulating object creation logic in one place.
- Promoting loose coupling and scalability in code by relying on common interfaces.

---

### Animal Interface

```java
interface Animal{
    void makeSound();
}
```

### Concrete Classes

```java
class Dog implements Animal {
    public void makeSound() {
        System.out.println("Woof!");
    }
}

class Cat implements Animal {
    public void makeSound() {
        System.out.println("Meow!");
    }
}
```

### Factory Class

```java
class AnimalFactory {
    public static Animal createAnimal(String animalType) {
        if (animalType.equalsIgnoreCase("dog")) {
            System.out.println("Dog Object created.");
            return new Dog();
        } else if (animalType.equalsIgnoreCase("cat")) {
            System.out.println("Cat Object created.");
            return new Cat();
        } else {
            // default case
            System.out.println("Invalid animal type.");
            return null;
        }
    }
}
```

### Main Class
```java
public class exercise2 {
    public static void main(String[] args) {
        // Requesting Dog Obj.
        System.out.println("Requesting Dog:");
        Animal a1 = AnimalFactory.createAnimal("dog");
        a1.makeSound();

        // Requesting Cat Obj.
        System.out.println("Requesting Cat:");  
        Animal a2 = AnimalFactory.createAnimal("cat");
        a2.makeSound();

        // Requesting Horse Obj.
        System.out.println("Requesting Horse:");  
        Animal a3 = AnimalFactory.createAnimal("horse");
        if (a3 != null) a3.makeSound(); // Safe Check as a3 will return null
    }
}
```

## How to Run
### Prerequisites
- Java JDK 8 or later must be installed
- Any terminal or command prompt

---

### Compilation

```bash
javac exercise2.java
```

### Execution
```bash
java exercise2
```

## Output
```bash
Requesting Dog:
Dog Object created.
Woof!
Requesting Cat:
Cat Object created.
Meow!
Requesting Horse:
Invalid animal type.
```