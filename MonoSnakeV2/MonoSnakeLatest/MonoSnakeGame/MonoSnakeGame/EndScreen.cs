﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MonoSnakeGame
{
    public class EndScreen : GameWindow
    {

        //private SpriteFont spriteFont;
        private Rectangle bb;
        private Texture2D texture;
        private Color color;
        SpriteFont font;


        public EndScreen(Game1 g, SpriteBatch sb, Texture2D tex)  : base(g, sb)
        {

            //spriteFont = sf;
            bb = new Rectangle(0, 0, 1000, 600);
            texture = tex;
            color = Color.White;
            texture = g.Content.Load<Texture2D>("SnakeEnd");
            font = g.Content.Load<SpriteFont>("finalScore");

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Draw(texture, bb, color);
            spriteBatch.DrawString(font, "1. " + "Nick", new Vector2(300, 200), Color.Black);
            //spriteBatch.DrawString(spriteFont, "Press A Continue", new Vector2(100, 100), Color.White);
        }

    }
}
