public interface ICommandAction
{

    string Id { get; }

    void Perform();

}
