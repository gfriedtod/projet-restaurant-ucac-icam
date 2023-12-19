namespace mvc;

public class Models
{

    private List<Sprite> _tables=new List<Sprite>();
    private Map _map=new Map(200,200);
    public List<Sprite> Tables
    {
        get { return _tables; }
        set { _tables = value ?? throw new ArgumentNullException(nameof(value)); }
    }
    public Map Map
    {
        get { return _map; }
        set { _map = value ?? throw new ArgumentNullException(nameof(value)); }
    }




    public void DrawingMap()
    {
        
        
        _tables = _map.drawMap("assets/map.txt");
        
                            
    }
    

}
