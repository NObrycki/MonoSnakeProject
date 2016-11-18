using System;
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
    public class GameScreen : GameWindow
    {

        //private SpriteFont spriteFont;
        private Rectangle bb;
        private Texture2D texture;
        private Color color;
        Player pOne;
        Gem gOne;
        Gem gTwo;
        Gem gThree;
        Gem gFour;
        SpriteFont font;

        public GameScreen(Game1 g, SpriteBatch sb, Texture2D tex) : base(g, sb)
        {

            font = g.Content.Load<SpriteFont>("gemScore");
            bb = new Rectangle(0, 0, 900, 750);
            
            color = Color.Black;

            pOne = new Player(4, Color.Green, new Rectangle(300, 300, 25, 25), tex);

            gOne = new Gem(tex, Color.Purple);
            gTwo = new Gem(tex, Color.Purple);
            gThree = new Gem(tex, Color.Purple);
            gFour = new Gem(tex, Color.Purple);

        }

        public override void Update(GameTime gameTime)
        {

            pOne.Update(gameTime);
            gOne.Update(gameTime);
            gTwo.Update(gameTime);
            gThree.Update(gameTime);
            gFour.Update(gameTime);

            base.Update(gameTime);

            if (pOne.getColor() == Color.Black)
            {
               
            }

            if (pOne.gemGet(gOne) == true)
            {
                gOne.Hide();
                pOne.grow();
                pOne.addScore(1);
                gOne.Respawn();
                gOne.Show();
                pOne.grow();
            }

            if (pOne.gemGet(gTwo) == true)
            {
                gTwo.Hide();
                pOne.grow();
                pOne.addScore(1);
                pOne.grow();
                gTwo.Respawn();
                gTwo.Show();

            }

            if (pOne.gemGet(gThree) == true)
            {
                gThree.Hide();
                pOne.grow();
                pOne.addScore(1);
                pOne.grow();
                gThree.Respawn();
                gThree.Show();
            }

            if (pOne.gemGet(gFour) == true)
            {
                gFour.Hide();
                pOne.grow();
                pOne.addScore(1);
                pOne.grow();
                gFour.Respawn();
                gFour.Show();
            }
        }

        public override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);

            // Drawing the Gem's and Player
            pOne.Draw(spriteBatch);
            gOne.Draw(spriteBatch);
            gTwo.Draw(spriteBatch);
            gThree.Draw(spriteBatch);
            gFour.Draw(spriteBatch);

            // Drawing the score
            double final_score = pOne.addScore(0);
            spriteBatch.DrawString(font, "Score: " + final_score, new Vector2(25, 25), Color.White);

            // TODO: Add your drawing code here

            //spriteBatch.DrawString(spriteFont, "Press A Continue", new Vector2(100, 100), Color.White);
        }

        public Boolean isDead()
        {
            if (pOne.getColor() == Color.Black)
            {
                return true;
            } else
            {
                return false;
            }
        }

    }
}
