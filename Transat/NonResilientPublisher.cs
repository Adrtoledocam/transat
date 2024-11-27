namespace Transat;

public class NonResilientPublisher(FaillibleQos0Storage storage1, FaillibleQos0Storage storage2)
{
    private readonly string _id = Guid.NewGuid().ToString("n");
    
    public void Send(int message)
    {
        var uniqueMessageId = $"{_id}-{Guid.NewGuid().ToString("n")}";

        while (!storage1.Data.Keys.Any(key => key.StartsWith(uniqueMessageId)))
        {
            storage1.Store(uniqueMessageId, message);

        }
        storage2.Store(_id, message);
    }

}