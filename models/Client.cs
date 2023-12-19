using System.Drawing;

namespace mvc;

public class Client : Persone ,Move
{

    private int number_client;

    private int NumberClient
    
    {
        get => number_client;
        set => number_client = value;
    }

    public bool Type
    {
        get => type;
        set => type = value;
    }

    private bool type;

    public int TableNumber
    {
        get => tableNumber;
        set => tableNumber = value;
    }

    private List<Food> commande;

    private int  tableNumber ;

    public Client(Size size, Point position, Map map, int numberClient, bool type) : base( size, position, map)
    {
        number_client = numberClient;
        this.type = type;
        this.Sprite1 = "client";
    }

    public void move(Point target)
    {
        throw new NotImplementedException();
    }

    public void commandPass()
    {
        for (int i = 0; i <= number_client; i++)
        {
            
            this.commande.Add(new Food());
            
        }
        
    }
    
}