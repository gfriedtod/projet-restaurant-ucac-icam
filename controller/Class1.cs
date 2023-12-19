using mvc;

namespace Controller;

public class Controller
{

    private Models models;
    private view.Game1 views;

    public Controller(Models models)
    {
        
        this.models = models;
        views = new view.Game1();
        views.Models = this.models;
    }

    public void run() {
        
        models.DrawingMap();  
        
        if (views != null)
            views.Run();
        
    }
}
