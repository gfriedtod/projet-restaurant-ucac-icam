using System.Drawing;

namespace mvc;

public class Map
{

    private Sprite[,] map;

    public Sprite[,] Map1
    {
        get => map;
        set => map = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int MaxX
    {
        get => Max_X;
        set => Max_X = value;
    }

    public int MaxY
    {
        get => Max_Y;
        set => Max_Y = value;
    }

    private int Max_X;
    private int Max_Y;

    public Map(int maxX, int maxY)
    {
        Max_X = maxX;
        Max_Y = maxY;

        map = new Sprite[Max_X,Max_Y];
    }

    public  List<Sprite> drawMap(String path)
    {

        List<Sprite> sprites = new List<Sprite>();
        StreamReader str = new StreamReader(path);
        Sprite sprite ;
        String line = "";
        int j = 0;
        
        while (line!=null)
        {
           line = str.ReadLine();
           if (line != null)
           {
               for (int i = 0; i < line.Length; i++)

               {
                  char  item = line[i];
                  
                 // Console.WriteLine(item);
                  
                                 

                  switch (item) 
                  {
                                      // case '0':
                                      //     
                                      //     sprite =new TIles(new Size(40,40), new Point(i,j));
                                      //     map[i, j] = sprite;
                                      //    ; 
                                      //    // sprites.Add(sprite);
                                      //     break;
                                      case '9':
                                          sprite = new Table(new Size(40,40), new Point(i,j),5,false, j);
                                          map[i, j] = sprite;
                                          sprites.Add(sprite);
                                          //Console.Write(map[i,j].Sprite1); 
                                          break;
                                      case  '8':
                                          sprite = new Table(new Size(40,40), new Point(i,j),5,false, j);
                                          map[i, j] = sprite;
                                          sprites.Add(sprite);
                                        
                                          break;
                                      case '3':
                                          sprite = new MHotel(new Size(40,40), new Point(i,j), this);
                                          map[i, j] = sprite;
                                          sprites.Add(sprite);
                                        //  Console.Write(map[i,j].Sprite1); 
                                          break;
                                      
                                      case '-':
                                          sprite = new Client(new Size(40, 40), new Point(i, j), this,(int)new Random().NextInt64(5),true);
                                          map[i,j]=sprite;
                                          sprites.Add(sprite);
                                          break;
                                      
                                      case 'r':
                                          sprite = new RangeLead(new Size(40,40), new Point(i,j), this);
                                          map[i, j] = sprite;
                                          sprites.Add(sprite);
                                          break;
                                      
                                      // default :
                                      //     Console.Write(item);
                                      //     sprite = new TIles(new Size(10,10), new Point(i,j));
                                      //     map[i, j] = sprite;
                                      //     Console.Write(map[i,j].Sprite1); 
                                      //    // sprites.Add(sprite);
                                      //     break;
                                      
                                  }
                                  
                                 // map[i][j] = (items.Equals('0'))?new Persone("", new Size(10,20), new Point(i,j),this): new Persone("", new Size(10,10), new Point(i,j),this);
               
               
                                  }
               Console.WriteLine(" ");
               
               j++;
                              }
                              
                          
           }
        

        str.Close();
        

        return sprites;   
           
        }
        
   

    
}