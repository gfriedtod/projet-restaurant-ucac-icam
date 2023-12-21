using Microsoft.Xna.Framework;
using model_cuisine;
using System;
using System.Threading;
using System.Xml;
using view_cuisine;

namespace controller_kitchen;

public class Controller
{

    private Models models;
    private Game2 views;

    public Controller(Models models)
    {
        
        this.models = models;
        views = new Game2();
        this.models.Subscribe(views);
        views.Models = this.models;
    }

    public void run()
    {
        
      
        new Thread((() =>
        {
            models.DrawMap();
            try
            {
                // this.models.AssignedTableFOrServeur();
                 if(models.Cheafs.Count>0 && models.LeadCheafs.Count >0)
                for (int i = 0; i < models.Cheafs.Count; i++)
                {                Console.WriteLine(models.Cheafs.Count);

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
