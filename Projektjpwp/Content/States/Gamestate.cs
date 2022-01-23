using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Projektjpwp.Backgrounds;
using Projektjpwp.Content.Controls;
using Microsoft.Xna.Framework.Input;
using Projektjpwp.Obstacles;


namespace Projektjpwp.Content.States
{
    public class Gamestate : state
    {
        int ascii_index;
        Texture2D background1;
        Texture2D background2;
        private List<component> menu;
        SpriteFont font;
        SpriteFont buttonFont;
        SpriteFont pixelFont;
        Scrolling scrolling1;
        Scrolling scrolling2;
        int loop =1;
        string gowno;
        public Skater skater;
        public List <Obstacle>  objects;
        
        int speed=5;
        int timer;
        int frametimer=60;
        int frametimmerfall = 60;

        int skaterY = 625;
        bool colision=false;
        bool flagkey = false;
        bool flagkey1 = false;
        bool level2 = false;
        bool gameover1=false;
        int helpin = 0;
        Keys A;

        KeyboardState _currentkey;
        KeyboardState _previouskey;

        void Jump(int frametimer, Skater skater,bool flag)
        { 
                switch (frametimer / 5)
                {
                    case 12:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 01");
                        break;
                    case 11:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 02");
                        break;
                    case 10:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 03");
                        break;
                    case 9:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 04");
                        break;
                    case 8:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 05");
                        break;
                    case 7:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                        break;
                    case 6:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 07");
                        break;
                    case 5:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 08");
                        break;
                    case 4:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 09");
                        break;
                    case 3:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 10");
                        break;
                    case 2:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 11");
                        break;
                    case 1:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 12");
                    flagkey1 = false;
                    flagkey = false;
                        break;
                
            }


        }
        void fall(int frametimmer, Skater skater)
        {
            switch (frametimer / 10)
            {
                case 6:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 25");
                    
                    break;
                case 5:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 21");
                    break;
                case 4:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 22");
                    break;
                case 3:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 23");
                    break;
                case 2:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 24");
                    break;
                case 1:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 25");
                    break;
            }

         

        }
        void NextObject(int i)
        {
            objects[i].size.X = objects[i].size.X + 4000;




        }
         Keys Rndchar()
        {
            
            Random rnd = new Random();
            int ascii_index = rnd.Next(65, 91);
            char myRandomUpperCase = Convert.ToChar(ascii_index);
            Keys cAsKey = (Keys)((int)(char.ToUpper(myRandomUpperCase)));
            return cAsKey;
            


        }





        public Gamestate(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            timer = 60 * 2;
            gowno = loop.ToString();
            
            font = _content.Load<SpriteFont>("Fonts/Title");
            var buttonTexture = _content.Load<Texture2D>("button/Button");
             buttonFont = _content.Load<SpriteFont>("Fonts/bubblefont");
           
            pixelFont = _content.Load<SpriteFont>("Fonts/PIPI");
            skater = new Skater(2, new Rectangle(0, skaterY, 300, 300), _content.Load<Texture2D>("sprites_skater/Sprite 12"));
            
            objects = new List <Obstacle> { new Obstacle(new Rectangle(600, 725, 200, 200), _content.Load<Texture2D>("Objects/Pipes Sprite 33"), speed, Rndchar()),
                new Obstacle(new Rectangle(1600, 725, 200, 200), _content.Load<Texture2D>("Objects/Pipes Sprite 34 Variation"), speed, Rndchar()),
             new Obstacle(new Rectangle(2600, 725, 200, 200), _content.Load<Texture2D>("Objects/Banana Sprite 28"), speed, Rndchar()),
             new Obstacle(new Rectangle(3600, 725, 200, 200), _content.Load<Texture2D>("Objects/Lower Obstacle Sprite 32"), speed, Rndchar())};
            
            
            scrolling1 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(0, 0, 1280, 1024),skater,speed);
            scrolling2 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(1280, 0, 1280, 1024),skater,speed);
            
            //banana = new Obstacle(new Rectangle(, 725, 200, 200), _content.Load<Texture2D>("Objects/Cone Sprite 30"), speed);
            //pipe = new Pipe( new Rectangle (500,725,200,200),_content.Load<Texture2D>("Objects/Pipes Sprite 33"),speed,500);
            var menubutton = new Button(buttonTexture, buttonFont)
            { 
                Position= new Vector2(50,50),
                Text="Menu",
            };
            menu = new List<component>()
      {
        menubutton
      };
            menubutton.Click += menuButton_Click;
            
            

        }

       
       



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            scrolling1.Draw(spriteBatch);
            scrolling2.Draw(spriteBatch);
            spriteBatch.Draw(objects[helpin].sprite, objects[helpin].size, Color.White);
            spriteBatch.Draw(objects[helpin + 1].sprite, objects[helpin + 1].size, Color.White);
            spriteBatch.Draw(objects[helpin + 2].sprite, objects[helpin + 2].size, Color.White);
            spriteBatch.Draw(objects[helpin + 3].sprite, objects[helpin + 3].size, Color.White);
            spriteBatch.DrawString(font, gowno, new Vector2(200, 200), Color.Black);
            spriteBatch.DrawString(font, skater.lifes.ToString(), new Vector2(250, 250), Color.White);
            spriteBatch.DrawString(pixelFont, objects[helpin].leather.ToString(), new Vector2(objects[helpin].size.X + 70, 700), Color.Red);
            spriteBatch.DrawString(pixelFont, objects[helpin + 1].leather.ToString(), new Vector2(objects[helpin + 1].size.X + 70, 700), Color.Red);
            spriteBatch.DrawString(pixelFont, objects[helpin + 2].leather.ToString(), new Vector2(objects[helpin + 2].size.X + 70, 700), Color.Red);
            spriteBatch.DrawString(pixelFont, objects[helpin + 3].leather.ToString(), new Vector2(objects[helpin + 3].size.X + 70, 700), Color.Red);
            spriteBatch.Draw(skater.skatersprite, skater.size, skater.color);
            
            // spriteBatch.DrawString(pixelFont, "Press to start", new Vector2(500, 500), Color.Black); narazie kom
            foreach (var component in menu)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();


        }
        private void menuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new Menustate(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            timer--;
            frametimer--;
            frametimmerfall--;
            //ruchome tlo 

            foreach (var component in menu)
                component.Update(gameTime);
            if (scrolling1.rectangle.X + scrolling1.texture.Width <= 0)
            {
                scrolling1.rectangle.X = scrolling2.rectangle.X + scrolling2.texture.Width;
                
                loop++;
                gowno = loop.ToString();
                
            }
            if (scrolling2.rectangle.X + scrolling2.texture.Width <= 0)
            {
                scrolling2.rectangle.X = scrolling1.rectangle.X + scrolling2.texture.Width;
                 loop++;
                gowno = loop.ToString();
            }
            KeyboardState state = Keyboard.GetState();
            _previouskey = _currentkey;
            _currentkey = Keyboard.GetState();
            #region pipe1
            for (int i = 0; i < 4; i++)
            {
                if (_currentkey.IsKeyUp(objects[i].leather) && _previouskey.IsKeyDown(objects[i].leather) && objects[i].size.X >= 130 && objects[i].size.X <= 250 && flagkey1==false)
                {
                    skater.lifes += 1;
                    flagkey = true;
                    frametimer = 60;
                    flagkey1 = true;
                    
                }
                if (flagkey == true && objects[i].size.X >= 130)
                {
                    Jump(frametimer, skater, flagkey);

                }


                else if (objects[i].size.X <= 100 && objects[i].size.X > 0 && skater.lifes > 0 && colision == false && flagkey == false )
                {   
                    skater.lifes -= 1;
                   
                    skater.color = Color.Red;
                    timer = 30;
                    colision = true;
                    

                }
                if (objects[i].size.X < -200)
                {
                    NextObject(i);
                    objects[i].leather = Rndchar();
                }
                

            }
            if (loop == 5 && level2 == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    objects[i].speed += 3;
                    
                    
                }
                scrolling1.speed += 3;
                scrolling2.speed += 3;
                level2 = true;
                loop = 0;
            }
            if (loop == 0)
            {
                level2 = false;
            }

            #endregion

            if (timer == 0)
            {   
                skater.color = Color.White;
                colision = false;

            }
            if (skater.lifes == 0)
            {
                objects[0].speed = 0;
                objects[1].speed =0;
                objects[2].speed = 0;
                objects[3].speed = 0;
                scrolling1.speed = 0;
                scrolling2.speed = 0;
                frametimer = 60;
                gameover1 = true;
                
            }
            if (gameover1 == true)
            {
                fall(frametimer, skater);
            }
           
           

            scrolling1.Update();
            scrolling2.Update();
            objects[0].Update();
            objects[1].Update();
            objects[2].Update();
            objects[3].Update();
           
           
            // pobiera co jest wcisniete
            
            if (state.IsKeyDown(Keys.Escape))
           _game.ChangeState(new Menustate(_game, _graphicsDevice, _content));




            

        }
    }
}
