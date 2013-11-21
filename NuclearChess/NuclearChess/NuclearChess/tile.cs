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
    class tile
    {
        
        char x;
        int y;
        bool black;
        bool fallout;
        piece piece;
        public int center_x;
        public int center_y;

        tile() { }

        public void Initialize() { }

        public void Update() { }

        public void Draw(SpriteBatch sb) { }

    }
}
