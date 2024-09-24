namespace EasyInjector;
public interface IInjectorBuilder
{
    void AddScoped<TInterface, TImplementation>()
        where TImplementation : TInterface;

    void AddScoped<TImplementation>()
        where TImplementation : class;

    void AddScoped<TInterface, TImplementation>(TImplementation implementation);

    IInjector BuildInjector();
}

