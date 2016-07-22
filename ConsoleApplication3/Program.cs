using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Animal
    {
        //public, protected or private
        public double height { get; set; }
        public double weight { get; set; }
        public string sound { get; set; }

        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; } //value is the default for setting 
        }

        // Constructor
        public Animal()
        {
            this.height = 0;
            this.weight = 0;
            this.name = "No Name";
            this.sound = "No Sound";
            numOfAnimals++;
        }

        public Animal(double height, double weight, string name, string sound)
        {
            this.height = height;
            this.weight = weight;
            this.name = name;
            this.sound = sound;
            numOfAnimals++;
        }

        // Static "field" when it doesn't make sense for the actual object to have that capability
        static int numOfAnimals = 0;

        // Static Method
        //A static method can't update non-static class members
        public static int getNumOfAnimals()
        {
            return numOfAnimals;
        }

        public string toString()
        {
            return String.Format("{0} is {1} inches tall, weight {2} lbs and likes to say {3}", name, height, weight, sound);
        }

        //method overloading
        public int getSum(int num1 = 1, int num2 = 2)
        {
            return num1 + num2;
        }

        public double getSum(double num1 = 1, double num2 = 2)
        {
            return num1 + num2;
        }

        static void Main(string[] args)
        {
            Animal spot = new Animal(15, 10, "Spot", "Woof");

            Console.WriteLine("{0} says {1}", spot.name, spot.sound);

            // Static method belongs to the Class not the object so it's called via the Class
            Console.WriteLine("Number of Animals " + Animal.getNumOfAnimals());

            Console.WriteLine(spot.toString());
            Console.WriteLine("use getSum() default 2nd arg: " + spot.getSum(6));
            Console.WriteLine("getSum() passed int: " + spot.getSum(3, 4));
            Console.WriteLine("getSum() passed double: " + spot.getSum(2.1, 1.88));
            // Can also pass args in any order
            Console.WriteLine("getSum() pass param names: " + spot.getSum(num2: 5, num1: 10));

            // Create an object using object initializer
            Animal grover = new Animal
            {
                name = "Grover",
                height = 16,
                weight = 20,
                sound = "Grrrr...",
            };
            Console.WriteLine("*****************************************");

            Dog spike = new Dog();

            Dog pete = new Dog(12, 10, "Petey", "Zzzzz", "Milk Duds");

            Console.WriteLine(pete.toString() );


            // END
            Console.WriteLine("Press any key to quit...");
            Console.Read();
        }

    }

    //Create a subclass... can be same namespace but outside of prior class declaration
    //Inheritance
    class Dog : Animal
    {
        public string favFood { get; set; }

        // Public constructor which calls the superclass init via base()
        public Dog() : base()  // set all defaults from Animal superclass
        {
            this.favFood = "No Favorite Food";
        }
        
        // Pass args to superclass initializer via base()
        public Dog(double height, double weight, string name, string sound, string favFood) : base 
            (height, weight, name, sound)
        {
            this.favFood = favFood;
        }

        // Override a method by adding "new"
        new public string toString()
        {
            return String.Format("{0} is {1} inches tall, weight {2} lbs and likes to say {3} and eats {4}", 
                name, height, weight, sound, favFood);
        }
    }

    // Abstract Class = An abstract class is only to be sub-classed (inherited from)
    abstract class Shape
    {
        public abstract double area();
        public void sayHi()
        {
            Console.WriteLine("Hello");
        }
    }

    public interface ShapeItem
    {
        double area();
    }

    class Rectangle : Shape
    {
        private double length; 
        private double width;

        public Rectangle(double num1, double num2)
        {
            length = num1;
            width = num2;
        }

        public override double area()
        {
            return length * width; 
        }

// Operator Overloading = Change the behavior of an operator as needed for a class
        public static Rectangle operator+ (Rectangle rect1, Rectangle rect2)
        {
            double rectLength = rect1.length + rect2.length;
            double rectWidth = rect1.width + rect2.width;

            return new ConsoleApplication3.Rectangle(rectLength, rectWidth);
        }

    }

    class Triangle : Shape
    {
        private double theBase;
        private double height;

        public Triangle(double num1, double num2)
        {
            theBase = num1;
            height = num2;
        }

        public override double area()
        {
            return .5 * (theBase * height);
        }
    }
}
