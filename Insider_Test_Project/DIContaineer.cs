using System;

namespace Insiders_Test_Project
{
    public class DIContainer
    {
        private readonly Dictionary<Type, Func<object>> _registrations = new Dictionary<Type, Func<object>>();

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _registrations[typeof(TService)] = () => Resolve(typeof(TImplementation));
        }
        public void Register<TService>(Func<TService> factory)
        {
            _registrations[typeof(TService)] = () => factory();
        }
        public TService Resolve<TService>()
        {
            return (TService)Resolve(typeof(TService));
        }
        public object Resolve(Type serviceType)
        {
            if (_registrations.TryGetValue(serviceType, out var factory))
            {
                return factory();
            }

            var constructor = serviceType.GetConstructors().First();
            var parameters = constructor.GetParameters()
                                        .Select(p => Resolve(p.ParameterType))
                                        .ToArray();
            return Activator.CreateInstance(serviceType, parameters);
        }
    }
}
