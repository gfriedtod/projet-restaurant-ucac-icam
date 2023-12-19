using System.Drawing;

namespace mvc;

public class Table :Sprite
{
    
    private int number_clinet;
    private bool state;
    private int table_number;
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
    }
    public int Number_clinet
    {
        get { return number_clinet; }
        set { number_clinet = value; }
    }
    
    

 
}
