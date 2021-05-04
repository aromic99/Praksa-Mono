using System;
namespace oops
{   
    
    public interface IsEmployed {
        void works();
    }

    public abstract class Employee : IsEmployed
    {
        protected string name;
        public int salary = 10000;

        public Employee(string firstName, string lastName)
        {
            name = firstName + " " + lastName;

        }

        public virtual void work()
        {
            Console.WriteLine("working...");
        }

        public abstract void goToWork();

        public void works() 
        {
            Console.WriteLine("works");
        }

        public void PrintName()
        {
            Console.WriteLine(name);
        }

    }

    public class NotAnEmployee : IsEmployed
    {
        protected string name;

        public NotAnEmployee(string firstName, string lastName)
        {
            name = firstName + " " + lastName;

        }

        public void works()
        {
            Console.WriteLine("does not work");
        }
    }



    public class Programmer : Employee
    {
        public int bonus = 5000;
        
        public Programmer(string firstName, string lastName ):base( firstName, lastName) { }
        
        public override void work()
        {
            Console.WriteLine("working on a project...");
        }
        
        public override void goToWork() {
            Console.WriteLine("driving to work");
        }
    }

    public class Economist : Employee 
    {
        public int bonus = 500;
        
        public Economist(string firstName, string lastName) : base(firstName, lastName) { }
        
        public override void work()
        {
            Console.WriteLine("working in a bar...");
        }

        public override void goToWork()
        {
            Console.WriteLine("going on foot");
        }


    }

    class GenericClass
    {
        public void show<T>(T msg)
        {
            Console.WriteLine(msg);
        }
    }

    class Test
    {
        public static void Main(string[] args)
        {
            Programmer Teo = new Programmer("Teo", "Marić");
            Economist Ivan = new Economist("Ivan", "Ivić");
            Console.WriteLine("programmer salary = " + Teo.salary);
            Console.WriteLine("programmer bonus = " + Teo.bonus);
            Console.WriteLine("economist salary + bonus = " + (Ivan.salary + Ivan.bonus));
            Teo.work();
            Ivan.work();
            Teo.goToWork();
            Ivan.goToWork();
            NotAnEmployee Joško = new NotAnEmployee("Joško", "Jakić");
            Joško.works();
            Teo.works();
            GenericClass GenClass = new GenericClass();
            GenClass.show("Danas nam je prvi dan prakse.");
            GenClass.show(3399);
        }
    }
}