namespace EasyInjector;
public interface IInjector
{
    TInterface GetInstance<TInterface>();
    object GetInstance(Type TInterface);
}
