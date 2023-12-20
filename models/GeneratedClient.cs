using System.Drawing;

namespace mvc;

public class GeneratedClient 
{
    
    private List<IObserver<Client>> observers = new List<IObserver<Client>>();

    
    
    public Client GetClient()
    {
        return new Client(new Size(40,40), new Point(0,0), null, Random.Shared.Next(0, 5), false);
    }

    // public IDisposable Subscribe(IObserver<Client> observer)
    // {
    //     this.Notify(new Client(new Size(40,40), new Point(0,0), null, Random.Shared.Next(0, 5), false));
    //     return null;
    // }
    //
    // public void Notify(Client value)
    // {
    //     foreach (var observer in observers)
    //     {
    //         if (observer.GetType().GetProperty("IsStopped") == null || !(bool)observer.GetType().GetProperty("IsStopped").GetValue(observer, null))
    //             observer.OnNext(value);
    //     }
    // }
}
