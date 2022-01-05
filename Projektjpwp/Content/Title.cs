using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Projektjpwp.Content.Controls;
using Microsoft.Xna.Framework.Input;


namespace Projektjpwp
{
    public class Title
    {
        #region Fields
        private SpriteFont _font;
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        #endregion
        public Title(SpriteFont font)
        {
            _font = font;

        }
    }
}
