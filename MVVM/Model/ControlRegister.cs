using Unity;

namespace Password_Manager.MVVM.Model;

public static class ControlRegister {
    public static IUnityContainer RegisterControl<T> (T control) where T : IPasswordSupplier {
        IUnityContainer container = new UnityContainer();
        container.RegisterInstance<IPasswordSupplier>(control);
        return container;
    }
}
