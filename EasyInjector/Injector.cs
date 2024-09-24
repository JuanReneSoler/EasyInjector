namespace EasyInjector;
public class Injector : IInjector
{
    private IDictionary<Type, Type> _typesToInject;
    internal Injector(IDictionary<Type, Type> typesToInject)
    {
        _typesToInject = typesToInject;
    }

    public TInterface GetInstance<TInterface>()
    {
        return (TInterface)GetInstance(typeof(TInterface));
    }

    public object GetInstance(Type TInterface)
    {
        if (_typesToInject.TryGetValue(TInterface, out var implementationType))
        {
            var controuctorInfo = implementationType.GetConstructors()[0];
            var parameters = controuctorInfo.GetParameters();
            var parameterInstances = new List<object>();
            foreach (var parameter in parameters)
            {
                var instance = GetInstance(parameter.ParameterType);
                parameterInstances.Add(instance);
            }
            return controuctorInfo.Invoke(parameterInstances.ToArray());
        }
        else
        {
            throw new Exception($"{TInterface} no registrado.");
        }
    }
}
