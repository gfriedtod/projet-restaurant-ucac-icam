

using mvc  ;
using System;

namespace Controller;

public class Program
{
    private static Controller controller;

    
    public static Models model;
    [STAThread]
    public static void Main()
    {
        model = new Models(); 
        
             controller = new Controller(model);
    
             
             
         controller.run();

    }
}
