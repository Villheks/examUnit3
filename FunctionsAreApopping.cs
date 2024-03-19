
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
            Console.WriteLine("Nothing to see here yet :P");
        }
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
        myFunctions functions = new myFunctions();
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
        myFunctions functions = new myFunctions();
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
        myFunctions functions = new myFunctions();
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
        myFunctions functions = new myFunctions();
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
        myFunctions functions = new myFunctions();        
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
       myFunctions functions = new myFunctions();
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
public class myFunctions
{
    public int SquaredNumber(int number)
    {
       return number * number;
    }
    public double MmLenght(int inches)
    {
        return inches * 25.4;
    }
    public double RootNumber(int number, int decimals)
    { 
        if (number < 0)
        {
            throw new ArgumentException("Cannot find square root of a negative number.");
        }

        if (number == 0 || number == 1)
        {
            return number;
        }

        double guess = number / 2; 

        while (true)
        {
            double newGuess = 0.5 * (guess + (number / guess)); 

            
            if (Math.Abs(newGuess - guess) < 0.000001) 
            {
            return Math.Round(newGuess, decimals); 
            }

            guess = newGuess; 
        }
    }
    public int CubedNumber(int number)
    {
       return number * number * number;
    }
    public double AreaOfCircle(int radius)
    {
       return 0;
       
    }
    
    public string Greet(string name)
    {
        return "0";
    }
    
}
