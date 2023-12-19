using System.Drawing;

namespace mvc;

public class MHotel    : Persone
{
    public MHotel( Size size, Point position, Map map) : base( size, position, map)
    {
        this.Sprite1 = "mh";
    }

    public void AssignedClient(Client client)
    {
        client.TableNumber = 10;
    }
}