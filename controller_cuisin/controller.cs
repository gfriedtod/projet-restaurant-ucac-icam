using model_cuisine;
using view_cuisine;

namespace controller_cuisin;

using Microsoft.Xna.Framework;
using System;
using System.Threading;
using System.Xml;


public class Controller
{

    public static void main()
    {
        Console.WriteLine("run");
    }
    private Models models;
    private Game2 views;

    public Controller(Models models)
    {
        
        this.models = models;
        views = new Game2();
        this.models.Subscribe(views);
        views.Models = this.models;
    }

    public void run() {
        models.DrawMap();
      
        new Thread((() =>
        {
            try
            {
                // this.models.AssignedTableFOrServeur();

                for (int i = 0; i < models.Cheafs.Count; i++)
                {
                  
                    this.models.LeadCheafs[0].AssignTask(models.Cheafs[i]);

                }
                // foreach (var client in models.Clients)
                // { Console.WriteLine("runable");
                //     ;
                // }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        })).Start();
             
        ;    
        // this.models.run();
      
     
            
        if (views != null)
            views.Run();
        
     
           

        
        
        
    }
}
