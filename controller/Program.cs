

using mvc  ;

namespace Controller;

public class Program
{
    private static Controller controller;

    public static Models model;
    public static void Main()
    {
        model = new Models(); 
        
             controller = new Controller(model);
    
         controller.run();

    }
}
