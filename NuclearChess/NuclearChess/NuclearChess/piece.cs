using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace NuclearChess
{
    class piece
    {
        string name;
        tile start;
        tile current;
        Texture2D texture;
        Rectangle textureSlice;

        public piece()
        {

        }

        public piece(string name, tile start, Texture2D tex, Rectangle texSlice)
        {
            
        }

        public void Initialize() { }

        public void Update() { }

        public void Draw(SpriteBatch sb) 
        {
            sb.Draw(texture, new Rectangle(current.center_x, current.center_y, textureSlice.Width, textureSlice.Height), textureSlice, Color.White);
        }
    }
}
