using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Projektjpwp.Backgrounds
{
    public class Scrolling: Background
    {
        public bool space = false;
        public int speed;

        
      

        public Scrolling(Texture2D newTexture, Rectangle newRectangle,Skater skater,int speed)
        {
            
            this.skater = skater;
            texture = newTexture;
            rectangle = newRectangle;
            this.speed = speed;

        }

        
       
        public void Update()
        {
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
                space = true;

            if (space == true )
                rectangle.X -= speed;
            
           

        }
            
    }
}
