using System.Reflection;

namespace AdvanceConcept
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Get Type Information
            //Type type = typeof(Person);
            Type type = Type.GetType("AdvanceConcept.Person");
            System.Console.WriteLine($"Class Name: {type}");

            // 2. Get Constructors
            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                System.Console.WriteLine($"Constructor: {ctor.Name}");
                foreach (ParameterInfo param in ctor.GetParameters())
                {
                    System.Console.WriteLine($" - Parameter: {param.Name}, Type: {param.ParameterType}");
                }
            }

            // 3. Get Public Properties
            Console.WriteLine("\nPublic Properties:");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Console.WriteLine($"  - {prop.Name} (Type: {prop.PropertyType})");
            }

            // 4. Get All Methods (Public and Private)
            Console.WriteLine("\nAll Methods:");
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            foreach (MethodInfo method in type.GetMethods(flags))
            {
                // We use DeclaringType to filter out methods inherited from 'object'
                if (method.DeclaringType == type)
                {
                    Console.WriteLine($"  - {method.Name} (IsPublic: {!method.IsPrivate})");
                }
            }

            // 5. Create Instance Dynamically
            object personInstance = Activator.CreateInstance(type, new object[] { "Alice", 30 });
            // 6. Invoke Public Method
            MethodInfo introduceMethod = type.GetMethod("Introduce");
            introduceMethod.Invoke(personInstance, null);
            // 7. Invoke Private Method
            MethodInfo topSecretMethod = type.GetMethod("TopSecret", BindingFlags.NonPublic | BindingFlags.Instance);
            topSecretMethod.Invoke(personInstance, null);
            // 8. Invoke Private Method with Parameter
            MethodInfo revealNewAgeMethod = type.GetMethod("RevealNewAge", BindingFlags.NonPublic | BindingFlags.Instance);
            revealNewAgeMethod.Invoke(personInstance, new object[] { 35 });
        }
    }
}
