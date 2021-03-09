public interface ISubject
{

    void AddObserver(IObserver observer);

    void RemoveObserver(IObserver observer);

    void Notify();

}


public interface ISubject<T>
{

    void AddObserver(IObserver<T> observer);

    void RemoveObserver(IObserver<T> observer);

    void Notify();

}
