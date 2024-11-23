namespace Transat;

public class Publisher
{
    private readonly Storage _storage1;
    private readonly Storage _storage2;
    private readonly string _id = Guid.NewGuid().ToString("n");
    
    
    public Publisher(Storage storage1,Storage storage2)
    {
        _storage1 = storage1;
        _storage2 = storage2;
    }
    
    public void Send(int message)
    {
        _storage1.Store(_id,message);
        _storage2.Store(_id, message);
    }
}