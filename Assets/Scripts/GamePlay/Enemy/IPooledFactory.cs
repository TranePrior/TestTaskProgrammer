public interface IPooledFactory<T>
{
    T GetNewObject();
    void DisableAllObjects();
}