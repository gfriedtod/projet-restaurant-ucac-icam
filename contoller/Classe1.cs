using Microsoft.Xna.Framework;
using mvc;
using System;
using System.Threading;
using System.Xml;
using view;

namespace Controller;

public class Controller
{

    private Models models;
    private Game1 views;

    public Controller(Models models)
    {
        
        this.models = models;
        views = new Game1();
        this.models.Subscribe(views);
        views.Models = this.models;
    }

    public void run() {
        models.DrawingMap();
      
        new Thread((() =>
        {
            try
            {
                // this.models.AssignedTableFOrServeur();

                for (int i = 0; i < models.Clients.Count; i++)
                {
                  
                    this.models.mHotel.AssignedClient(models.Clients[i]);

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
