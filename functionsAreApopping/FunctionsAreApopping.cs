
#pragma warning disable CS8604
#pragma warning disable CS8600
public class FunctionsAreApopping
{
    public static void Main(string[] args)
    {
        if (args.Contains("-t"))
        {
            RunTests();
        }
        else
        {
            MyFunctions functions = new MyFunctions();
            Console.WriteLine(functions.enterName);
            string name = Console.ReadLine();
            Console.WriteLine(functions.Greet(name));

            Console.WriteLine(functions.squareANumber);
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"{functions.SquaredNumber(number)}");

            Console.WriteLine(functions.convertInches);
            double inches = double.Parse(Console.ReadLine());
            Console.WriteLine($"{functions.MmLenght(inches)}");

            Console.WriteLine(functions.findTheRoot);
            double theRootNumber = double.Parse(Console.ReadLine());
            Console.WriteLine(functions.RootNumber(theRootNumber,3));

            Console.WriteLine(functions.cubeANumber);
            int cubeNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(functions.CubedNumber(cubeNumber));

            Console.WriteLine(functions.findTheArea);
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine(functions.AreaOfCircle(radius));

            Console.WriteLine(functions.thanks);
        };
    }
    public static void RunTests()
    {
        TestSquaredNumber();
        TestMmLength();
        TestRootNumber(); 
        TestCubedNumber();
        TestAreaOfCircle();
        TestGreet();
    }
    
    public static void TestSquaredNumber()
    {
        MyFunctions functions = new MyFunctions();
        int input1 = 5;
        int expected1 = 25;
        int result1 = functions.SquaredNumber(input1);
        if (result1 == expected1)
        {
            Console.WriteLine($"🟢Test passed! SquaredNumber({input1}) = {result1}, Expected: {expected1}");
        }
        else
        {
            Console.WriteLine($"🔴Test failed! SquaredNumber({input1}) = {result1}, Expected: {expected1}");
        }
    }
    
    public static void TestMmLength()
    {
        MyFunctions functions = new MyFunctions();
        int input1 = 10;
        double expected1 = 254;
        double result1 = functions.MmLenght(input1);
        if (result1 == expected1)
        {
            Console.WriteLine($"🟢Test passed! MmLength({input1}) = {result1}, Expected: {expected1}");
        }
        else
        {
            Console.WriteLine($"🔴Test failed! MmLength({input1}) = {result1}, Expected: {expected1}");
        }
    }
    
    public static void TestRootNumber()
    {
        MyFunctions functions = new MyFunctions();
        int input1 = 10;
        double expected1 = 3.16;
        double result1 = functions.RootNumber(input1,2);
        if (result1 == expected1)
        {
            Console.WriteLine($"🟢Test passed! RootNumber({input1}) = {result1}, Expected: {expected1}");
        }
        else
        {
            Console.WriteLine($"🔴Test failed! RootNumber({input1}) = {result1}, Expected: {expected1}");
        }
    }
    
    public static void TestCubedNumber()
    {
        MyFunctions functions = new MyFunctions();
        int input1 = 3;
        int expected1 = 27;
        int result1 = functions.CubedNumber(input1);
        if (result1 == expected1)
        {
            Console.WriteLine($"🟢Test Passed! CubedNumber({input1}) = {result1}, Expected: {expected1}");
        }
        else
        {
            Console.WriteLine($"🔴Test failed! CubedNumber({input1}) = {result1}, Expected: {expected1}");
        }
    }
    
    public static void TestAreaOfCircle()
    {
        MyFunctions functions = new MyFunctions();        
        int input1 = 5;
        double expected1 = 78.5;
        double result1 = functions.AreaOfCircle(input1);
        if (result1 == expected1)
        {
            Console.WriteLine($"🟢Test passed! AreaOfCircle({input1}) = {result1}, Expected: {expected1}");
        }
        else
        {
            Console.WriteLine($"🔴Test failed! AreaOfCircle({input1}) = {result1}, Expected: {expected1}");
        }
    }
    public static void TestGreet()
    {
       MyFunctions functions = new MyFunctions();
        string name = "John";
        string greeting = functions.Greet(name);
        if (greeting.Contains(name))
        {
            Console.WriteLine($"🟢Test passed! Greet({name}) = {greeting}");
        }
        else
        {
            Console.WriteLine($"🔴Test failed! Greet({name}) = {greeting}");
        }
    }
    
}
public class MyFunctions
{
    public int SquaredNumber(int number)
    {
       return number * number;
    }
    public double MmLenght(double inches)
    {
        return inches * 25.4;
    }
    public double RootNumber(double theRootNumber, int decimals)
    { 
        if (theRootNumber < 0)
        {
            throw new ArgumentException("Cannot find square root of a negative number.");
        }

        if (theRootNumber == 0 || theRootNumber == 1)
        {
            return theRootNumber;
        }

        double guess = theRootNumber / 2; 

        while (true)
        {
            double newGuess = 0.5 * (guess + (theRootNumber / guess)); 

            
            if (Math.Abs(newGuess - guess) < 0.000001) 
            {
            return Math.Round(newGuess, decimals); 
            }

            guess = newGuess; 
        }
    }
    public int CubedNumber(int cubeNumber)
    {
       return cubeNumber * cubeNumber * cubeNumber;
    }
    public double AreaOfCircle(double radius)
    {
       double pi = 3.14;
       double area = radius * radius * pi;
       return area;
       
    }
    
    public string Greet(string name)
    {
        
        string[] greetings = { "Hello", "Hi", "Hey", "Greetings", "Welcome" };
        Random rand = new Random();
        int index = rand.Next(greetings.Length);
        return $"{greetings[index]}, {name}!";
    }

    public string enterName = "Enter your name :)";
    public string squareANumber = "Enter a number to be squared";
    public string convertInches = "Enter a length of inches to be converted to mm";
    public string findTheRoot = "Enter a number to find the root";
    public string cubeANumber ="Enter a number to be cubed";
    public string findTheArea ="Enter the radius of a circle to find the area";
    public string thanks ="Thanks for running my program :)";
    
}

    

