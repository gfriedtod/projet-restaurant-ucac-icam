using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using mvc;
using System;

namespace view;

public class Game1 : Game ,IObserver<Models>
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Models models;
    public Models Models
    {
        get { return models; }
        set { models = value; }
    }




    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        
        //set width of the screen
        _graphics.PreferredBackBufferWidth = 800;
        //set height of the screen
        _graphics.PreferredBackBufferHeight = 600;
        _graphics.ApplyChanges();
      
        
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
       
         
       //  _model = Content.Load<Texture3D>("wall"); // TODO: use this.Content to load your game content here_model
       

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
            // TODO: Add your update logic here
           

            base.Update(gameTime);

        
        

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Brown);

        if (Models.Map.Map1 != null)
            for (int i = 0; i < Models.Map.MaxY; i++)
           
        {

            for (int j = 0; j < Models.Map.MaxX; j++)
            {
                if (models.Map.Map1[j, i] != null || models.Map.Map1[j, i] is Sprite)
                {
                    _spriteBatch.Begin();           
                
                     // Console.Write(models.Map.Map1[j,i].Position.X+" "+models.Map.Map1[j,i].Position.Y+"    ");
                     // Console.Write(j+" "+i);
                    
                    _spriteBatch.Draw(
                        Content.Load<Texture2D>(models.Map.Map1[j,i].Sprite1), 
                        new Rectangle(new Point(models.Map.Map1[j,i].Position.X * models.Map.Map1[j,i].Size.Width, models.Map.Map1[j,i].Position.Y*models.Map.Map1[j,i].Size.Width), new Point(models.Map.Map1[j,i].Size.Width, models.Map.Map1[j,i].Size.Height)), 
                        Color.White);
                    _spriteBatch.End();
                }  
               
                
            }
           
          
        }
      //  _spriteBatch.
        

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Models value)
    {
        this.models = value;
        this.Update(new GameTime());
        Console.WriteLine("modify");
    }
}
