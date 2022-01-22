﻿using Microsoft.Xna.Framework;
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
    class Scrolling: Background
    {
        public bool space = false;
       

        public Scrolling(Texture2D newTexture, Rectangle newRectangle,Skater skater)
        {

            this.skater = skater;
            texture = newTexture;
            rectangle = newRectangle;

        }

        
       
        public void Update()
        {
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
                space = true;

            if (space == true && skater.lifes>0) 
           rectangle.X -= 5;
           

        }
            
    }
}
