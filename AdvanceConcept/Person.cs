namespace AdvanceConcept
{
    public class Person
    {
        public string Name { get; set; }
        private int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Introduce()
        {
            System.Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }

        private void TopSecret()
        {
            System.Console.WriteLine("This is a top secret method.");
        }

        private void RevealNewAge(int age)
        {
            System.Console.WriteLine($"My age new age is {age}.");
        }
    }
}
