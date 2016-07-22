using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    // Delegate used to pass methods as arguments to other methods
    delegate double GetSum(double num1, double num2);


    // A struct is a value type. Similar to classes but are lightweight. int, bool, float are technically structs.
    struct Customers
    {
        private string name;
        private double balance;
        private int id;

        public void createCust(string n, double b, int i)
        {
            name = n;
            balance = b;
            id = i;
        }

        public void showCust()
        {
            Console.WriteLine("Name " + name);
            Console.WriteLine("Balance " + balance);
            Console.WriteLine("ID " + id);
        }

    }
    public class EnumTest
    {

        // Enum has symbolic names and associated values. An enum consists of a set of named constants called the enumerator list. 
        public enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

        public void writeDay(int dom)
        {
            int x = (int)Days.Sun;
            int y = (int)Days.Fri;
            int z = (int)Days.Thu;
            Console.WriteLine("Sun = {0}", x);
            Console.WriteLine("Fri = {0}", y);
            if ( z == dom )
            {
                Console.WriteLine("Day entered is Thursday");
            }
        }
    }

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
            Console.WriteLine("*****************************************************");

            Dog spike = new Dog();

            Dog pete = new Dog(12, 10, "Petey", "Zzzzz", "Milk Duds");

            Console.WriteLine(pete.toString() );

            Console.WriteLine("************Polymorphism*****************************");
// Polymorphism through the use of an abstract class
            Shape rect = new Rectangle(5, 5);
            Shape tri = new Triangle(5, 5);
            //due to polymorphism the correct area method will be called for each class
            Console.WriteLine("Rect Area " + rect.area());
            Console.WriteLine("Tri Area " + tri.area());

            //this adds two rectangles via the + operator overload
            Shape combRect = new Rectangle(5, 5) + new Rectangle(5, 5);
            Console.WriteLine("CombRect area = " + combRect.area());

            Console.WriteLine("*************Generic Class****************************");
            KeyValue<string, string> superman = new KeyValue<string, string>("", "");
            superman.key = "Superman";
            superman.value = "Clark Kent";
            superman.showData();

            //KeyValue<int, string> television = new KeyValue<int, string>(0, "");
            KeyValue<int, string> television = new KeyValue<int, string>(1234, "flat screen TV");
            //television.key = 1234;
            //television.value = "flat screen TV";
            television.showData();
            Console.WriteLine("*************Enum*************************************");

            EnumTest myEnum = new EnumTest();
            myEnum.writeDay(4);

            Console.WriteLine("*************Struct*************************************");

            var bob = new Customers();
            bob.createCust("Bob", 134.32, 42);
            bob.showCust();

            Console.WriteLine("*************DELEGATE w/Anonymous Method***************");
            // sum is initialized as a GetSum delegate defined above
            {
                GetSum sum = delegate (double num1, double num2)
                {
                    // the anonymous method
                    return num1 + num2;
                };
            Console.WriteLine("5 + 10 = " + sum(5, 10));
            }

            Console.WriteLine("*************DELEGATE w/lambda Expression***************");
            Func<int, int, int> getSum = (x, y) => x + y;

            Console.WriteLine("5 + 3 = " + getSum.Invoke(5, 3));

            Console.WriteLine("*************Lambda Expression w/List *****************");

            List<int> numList = new List<int>{ 5, 10, 15, 20, 25 };
            List<int> oddList = numList.Where(n => n % 2 == 1).ToList();

            foreach( int i in oddList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("*************StreamReader/StreamWriter******************");

            string[] custs = { "Tom", "Fred", "Joe" };
            using (StreamWriter sw = new StreamWriter("custs.txt"))
            {
                foreach (string cust in custs)
                {
                    sw.WriteLine(cust);
                }
            }
            Console.WriteLine("***************Write to file done**********************");
            string custName = "";
            using (StreamReader sr = new StreamReader("custs.txt"))
            {
                while ((custName = sr.ReadLine()) != null)
                {
                    Console.WriteLine(custName);
                }
            }
            Console.WriteLine("***************Read from file done**********************");

            Console.WriteLine("********************END*********************************");
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

// Generics / Generic Class = You don't have to specify the data type of an element in a class or in a method.

    class KeyValue<TKey, TValue>
    {
        public TKey key { get; set; }
        public TValue value { get; set; }

        public KeyValue(TKey k, TValue v)
        {
            key = k;
            value = v;
        }

        public void showData()
        {
            Console.WriteLine("{0} is {1} ", this.key, this.value);
        }
    }
}
