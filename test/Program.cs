using EasyInjector;

public interface IHello
{
    void SayHello();
}

public class Hello : IHello
{
    public void SayHello()
    {
        Console.WriteLine("Hello");
    }
}

public class Execution
{
    private readonly IHello _hello;
    public Execution(IHello hello)
    {
        _hello = hello;
    }

    public void Run()
    {
        _hello.SayHello();
    }
}

public class Program
{
    public static void Main()
    {
        var builder = new InjectorBuilder();
        builder.AddScoped<IHello, Hello>();
        builder.AddScoped<Execution>();
        var injector = builder.BuildInjector();
        var exec = injector.GetInstance<Execution>();
        exec.Run();
    }
}

