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

        public piece() { }

        public piece(string n, tile st)
        {
            name = n;
            start = st;
            current = start;
        }

        public piece(string n, tile st, Texture2D tex, Rectangle texSlice)
        {
            name = n;
            start = st;
            current = start;
            current.piece = this;
            texture = tex;
            textureSlice = texSlice;
        }


        //moves piece to parameter in tile
        public void move(tile t)
        {
            current.piece = null;
            if (t.piece != null)
            {
                takePiece(t);
                return;
            }
            current = t;
            t.piece = this;
        }

        public void takePiece(tile t) 
        {
            t.piece.current = null;
            t.piece = null;
            t.fallout = true;
            this.current = null;
        }

        public void Initialize() { }

        public void Update() { }

        public void Draw(SpriteBatch sb) 
        {
            if (current != null)
                sb.Draw(texture, new Rectangle((int)current.center.X- this.textureSlice.Width/2, (int)current.center.Y- this.textureSlice.Height/2, textureSlice.Width, textureSlice.Height), textureSlice, Color.White);
        }

    }
}
