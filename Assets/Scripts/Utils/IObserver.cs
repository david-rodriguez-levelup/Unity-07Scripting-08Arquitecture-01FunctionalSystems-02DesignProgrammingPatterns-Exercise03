public interface IObserver
{
    void OnNotify();
}


public interface IObserver<T>
{
    void OnNotify(T parameter);
}