using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projektjpwp
{
    public class Animation
    {   
        public int frame;
        public Texture2D sprite;
        public Skater skater;
        public bool flag;
        public Animation(int frame, Texture2D sprite, Skater skater,bool flag)
        {
            this.frame = frame;
            this.sprite = sprite;
            this.skater = skater;
            this.flag = flag;

        }
        public void Update()
        { 
            if (flag = true)
            {

            }


        }


    }
}
