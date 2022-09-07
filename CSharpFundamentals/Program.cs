namespace CSharpFundamentals
{
    public class Program : Program4
    {

        String name;
        String firstName;
        String lastName;
        //method default constructor
        public Program(String name)
        {
            this.name = name;
        }

        //another constructor
        public Program(String firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void getName()
        {
            Console.WriteLine("My name is " + this.name);
        }


        public void getData()
        {
            Console.WriteLine("I am inside the method");
        }

        static void Main(string[] args)
        {

            Program p = new Program("Edison");
            p.getData();
            p.setData();
            p.getData();

            Console.WriteLine("Hello, World!");
            int a = 4;
            Console.WriteLine("number is " + a);

            string name = "Edison";
            Console.WriteLine("Name is " + name);

            Console.WriteLine($"Name is {name}");

            var age = 23;
            Console.WriteLine("Age is " + age);

            dynamic height = 13.2;
            Console.WriteLine("Height is " + height);
            height = "string";
            Console.WriteLine("Height is " + height);

         }


    }
}