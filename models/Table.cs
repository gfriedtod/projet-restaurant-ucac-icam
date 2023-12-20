using System.Drawing;

namespace mvc;

public class Table :Sprite,IObservable<Table>
{
    
    private int number_clinet;
    private bool state;
    //private List<IObserver<Table>> observer = new List<IObserver<Table>>();
    public bool State
    {
        get { return state; }
        set { state = value; }
    }
    private int table_number;
    private List<IObserver<Table>> observers = new List<IObserver<Table>>();
    public int TableNumber
    {
        get { return table_number; }
        set { table_number = value; }
        
    }
    public Table(Size size, Point position, int numberClinet , bool state,int tableNumber) : base(size, position)
    {
        number_clinet = numberClinet;
        table_number = table_number;
        this.Sprite1="table";
        this.state = state;
    }
    public int Number_clinet
    {
        get { return number_clinet; }
        set { number_clinet = value; }
    }




    public IDisposable Subscribe(IObserver<Table> observer)
    {
        observers.Add(observer);
        return null;
    }
}
