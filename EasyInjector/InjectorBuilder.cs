namespace EasyInjector;
public class InjectorBuilder : IInjectorBuilder
{
    private readonly IDictionary<Type, Type> _typesToInject;
    public InjectorBuilder()
    {
        _typesToInject = new Dictionary<Type, Type>();
    }

    public void AddScoped<TInterface, TImplementation>()
        where TImplementation : TInterface
    {
        _typesToInject[typeof(TInterface)] = typeof(TImplementation);
    }

    public void AddScoped<TImplementation>()
        where TImplementation : class
    {
        AddScoped<TImplementation, TImplementation>();
    }

    public void AddScoped<TInterface, TImplementation>(TImplementation implementation)
    {
        throw new NotImplementedException();
    }

    public IInjector BuildInjector()
    {
        return new Injector(_typesToInject);
    }
}
