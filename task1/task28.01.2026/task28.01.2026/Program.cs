using System.Collections;
using System.Reflection.Metadata;
using System.Xml.Linq;

//Task 1 - FizzBuzz+
//Goal: practice if/else logic, loops, and basic input/output.
//Requirements
//Read two integers from the console: start and end.
//For every number i in [start..end], print ONE of the following (each on a new line):
// -If i is divisible by 3 and 5: print "FizzBuzz"
// - If i is divisible by 3: print "Fizz"
// - If i is divisible by 5: print "Buzz"
// - Otherwise: print i
//Extra: if start > end, swap them(or print an error and exit - choose one approach and document it).



//namespace task1
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("It is FizzBuzz console program, enter 2 digits: \n");

//            Console.WriteLine("Start: \n");
//            int start = Convert.ToInt32(Console.ReadLine());

//            Console.WriteLine("End: \n");
//            int end = Convert.ToInt32(Console.ReadLine());

//            //swap if end < start 
//            if (start > end)
//            {
//                int someSpace = start;
//                start = end;
//                end = someSpace;
//            }

//            for(int i = start; i <= end; i++)
//            {
//                if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("FizzBuz");
//                else if (i % 5 == 0) Console.WriteLine("Buzz");
//                else if (i % 3 == 0) Console.WriteLine("Fizz");
//                else Console.WriteLine(i);
//            }
//        }
//    }
//}



//Task 2 - Build a Binary Search Tree
//Goal: practice methods, parameters/returns, and an algorithmic problem. You will read numbers, insert them into a Binary Search Tree (BST), and print them in sorted order (in-order traversal).
//Requirements
//Read an integer N: how many numbers will be inserted.
//Read N integers from the console.
//Insert each number into a BST (duplicates can go to the right, or you can count duplicates - choose one approach).
//Implement at least these methods (signatures can vary):
// -Insert(Node root, int value)->Node
// - PrintInOrder(Node root)-> void
//Print the values from left to right using in-order traversal(this outputs ascending order).
//At the end, print the minimum and maximum value found in the tree (using traversal or while loops).


//namespace task2
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            BinarySearchTree bst = new BinarySearchTree();

//            Console.Write("N is: ");
//            int n = Convert.ToInt32(Console.ReadLine());

//            for(int i = 0; i < n; i++)
//            {
//                int value = Convert.ToInt32(Console.ReadLine());
//                bst.Insert(value);
//            }

//            Console.WriteLine("all the nodes: ");
//            bst.PrintInOrder();

//            Console.WriteLine($"{bst.Min()} - min");
//            Console.WriteLine($"{bst.Max()} - max");

//        }
//    }
//    class Node
//    {
//        public int Value;
//        public Node? Left;
//        public Node? Right;

//        public Node(int value)
//        {
//            Value = value;
//            Left = null;
//            Right = null;
//        }
//    }
//    class BinarySearchTree
//    {
//        Node? Root;

//        Node Insert(Node? node, int value)
//        {
//            if (node == null) return new Node(value);

//            if (value < node.Value) //less than value, going left
//            {
//                node.Left = Insert(node.Left, value);
//            }
//            else // more than value or equial to value, going right
//            {
//                node.Right = Insert(node.Right, value);
//            }
//            return node; // knot back 
//        }
//        public void Insert(int value)// another insert for outside usage
//        {
//            Root = Insert(Root, value);
//        }

//        void PrintInOrder(Node? node)
//        {
//            if (node == null) return;

//            PrintInOrder(node.Left);

//            Console.WriteLine(node.Value);

//            PrintInOrder(node.Right);
//        }
//        public void PrintInOrder()
//        {
//            PrintInOrder(Root);
//        }

//        public int Min()
//        {
//            Node current = Root;
//            while (current.Left != null)
//                current = current.Left;
//            return current.Value;
//        }
//        public int Max()
//        {
//            Node current = Root;
//            while (current.Right != null)
//                current = current.Right;
//            return current.Value;
//        }
//    }
//}




//Task 3 - Animal Shelter
//Goal: practice interfaces, multiple implementations, and polymorphic behavior.
//Core domain
//Create an interface IAnimal with:
//-string Name { get; }
// -string Species { get; }
// -string Speak();   // returns the sound
//Create 3 implementations: Cat, Dog, Snake.
//Each animal must have a different Speak() implementation:
// -Cat-> "Meow"
// - Dog-> "Woof"
// - Snake-> "Hiss"
//Each implementation should also have one unique property:
// -Cat: int LivesLeft(default 9)
// -Dog: bool IsTrained(true/false)
// -Snake: bool IsVenomous(true/false)
//Program flow
//Prompt the user for how many animals will be added (count).
//Loop count times: for each animal, ask for its type (cat / dog / snake) and its name.
//For Dog: ask if trained(y / n).For Snake: ask if venomous(y / n).For Cat: optionally ask lives left(or use default 9).
//Store all animals in a List<IAnimal>.
//At the end print a single summary line in the EXACT format below (numbers and sounds must match the animals added):
//There are X animals in our shelter - A cats, B dogs, C snakes. <sound1>, <sound2>, ...
//Example
//Example input
//Example output
//How many animals? 5
//1) type: cat, name: Mimi
//2) type: dog, name: Rex, trained: y
//3) type: snake, name: Sly, venomous: n
//4) type: cat, name: Luna
//5) type: dog, name: Max, trained: n
//There are 5 animals in our shelter - 2 cats, 2 dogs, 1 snake. Meow, Woof, Hiss, Meow, Woof


//Acceptance criteria
//Uses IAnimal and stores animals polymorphically (List<IAnimal>).
//Correct counting per animal type.
//Correct sound order (same order as user added animals).
//Clean separation between input handling and domain classes (Cat/Dog/Snake should not read from console).

namespace task3
{
    interface IAnimal
    {
        string Name { get; }
        string Species { get; }
        string Speak();
    }

    class Cat : IAnimal
    {
        public string Name { get; }
        public string Species { get; }
        public int LivesLeft { get; }
        public Cat(string name, int livesLeft = 9)
        {
            Name = name;
            Species = "cat";
            LivesLeft = livesLeft;
        }

        public string Speak()
        {
            return "Meow";
        }
    }

    class Dog : IAnimal
    {
        public string Name { get; }
        public string Species { get; }
        public bool IsTrained { get; }
        public Dog(string name, bool isTrained = false)
        {
            Name = name;
            Species = "dog";
            IsTrained = isTrained;
        }

        public string Speak()
        {
            return "Woof";
        }
    }
    class Snake : IAnimal
    {
        public string Name { get; }
        public string Species { get; }
        public bool IsVenomous { get; }
        public Snake(string name, bool isVenomous = true)
        {
            Name = name;
            Species = "snake";
            IsVenomous = isVenomous;
        }

        public string Speak()
        {
            return "Hiss";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();

            int catCounter = 0;
            int dogCounter = 0;
            int snakeCounter = 0;

            Console.WriteLine("The animal shelter!!!");
            Console.WriteLine("you will write animals which you want to add to the shelter.");
            Console.WriteLine("first, write the quantity: ");

            int quantity = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i<quantity; i++)
            {
                Console.WriteLine("name: ");
                string name = Console.ReadLine();

                Console.WriteLine("type of animal (dog, cat or snake (for now)): ");
                string type = Console.ReadLine().ToLower();

                if (type == "dog")
                {
                    Console.WriteLine("is he trained?(y/n) ");
                    string input = Console.ReadLine();

                    bool isTrained = input == "y";

                    animals.Add(new Dog(name, isTrained));
                    dogCounter++;
                }
                else if (type == "cat")
                {
                    Console.WriteLine("how many lives left?  ");
                    string input = Console.ReadLine();
                    int livesLeft = input == "" ? 9 : Convert.ToInt32(input);

                    animals.Add(new Cat(name, livesLeft));
                    catCounter++;
                }
                else if (type == "snake")
                {
                    Console.WriteLine("is your snake venomous?(y/n) ");
                    string input = Console.ReadLine();

                    bool isVenomous = input == "y";

                    animals.Add(new Snake(name, isVenomous));
                    snakeCounter++;
                }
                else
                {
                    Console.WriteLine("shelter's goverment is really sorry,");
                    Console.WriteLine("but for now we don't have enough space here to type of your animal");
                }
            }
            Console.Write($"There are {catCounter + dogCounter + snakeCounter} animals in the shelter - {catCounter} cats, {dogCounter} dogs, {snakeCounter} snakes. ");

            List<string> sounds = new List<string>();

            foreach (IAnimal animal in animals)
            {
                sounds.Add(animal.Speak());
            }

            Console.WriteLine(string.Join(", ", sounds));
        }
    }
}