using System;
using System.Reflection;

public class MyClass
{
    public void MyMethodWithoutParameter()
    {
        Console.WriteLine("MethodWithoutParameter invoked");
    }

    public void MyMethodWithParameter(string parameter)
    {
        Console.WriteLine($"MethodWithParameter invoked with parameter: {parameter}");
        Console.WriteLine("------------------------");
    }
    

    public void MyMethodWithMultipleParameters(string parameter1, int parameter2, bool parameter3)
    {
        Console.WriteLine($"MethodWithMultipleParameters invoked with parameters: {parameter1}, {parameter2}, {parameter3}");
    }

    public int MyMethodWithReturnValue()
    {
        return 42;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of MyClass
        MyClass myClass = new MyClass();

        // Invoke MyMethodWithoutParameter using reflection
        MethodInfo methodWithoutParameter = typeof(MyClass).GetMethod("MyMethodWithoutParameter");
        methodWithoutParameter.Invoke(myClass, null);

        // Invoke MyMethodWithParameter using reflection
        MethodInfo methodWithParameter = typeof(MyClass).GetMethod("MyMethodWithParameter");
        methodWithParameter.Invoke(myClass, new object[] { "Good Evening" });

        // Invoke MyMethodWithMultipleParameters using reflection
        MethodInfo methodWithMultipleParameters = typeof(MyClass).GetMethod("MyMethodWithMultipleParameters");
        methodWithMultipleParameters.Invoke(myClass, new object[] { "Good Evening", 24, true });

        // Invoke MyMethodWithReturnValue using reflection
        MethodInfo methodWithReturnValue = typeof(MyClass).GetMethod("MyMethodWithReturnValue");
        int result = (int)methodWithReturnValue.Invoke(myClass, null);
        Console.WriteLine($"Result: {result}");
    }
}