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
    public class GameWindow : DrawableGameComponent
    {

        private List<GameComponent> _components;
        public SpriteBatch spriteBatch;

        public GameWindow(Game g, SpriteBatch sb) : base(g)
        {

            _components = new List<GameComponent>();
            spriteBatch = sb;

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            foreach (GameComponent comp in _components)
            {
                if (comp.Enabled) comp.Update(gameTime);
            }

        }

        public override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);
            foreach (GameComponent comp in _components)
                if (comp is DrawableGameComponent && ((DrawableGameComponent)comp).Visible)
                    ((DrawableGameComponent)comp).Draw(gameTime);

        }

        public virtual void Show()
        {

            this.Visible = true;
            this.Enabled = true;
            foreach (GameComponent comp in _components)
            {
                comp.Enabled = true;
                if (comp is DrawableGameComponent)
                    ((DrawableGameComponent)comp).Visible = true;
            }

        }

        public virtual void Hide()
        {

            this.Visible = false;
            this.Enabled = false;
            foreach (GameComponent comp in _components)
            {
                comp.Enabled = false;
                if (comp is DrawableGameComponent)
                    ((DrawableGameComponent)comp).Visible = false;
            }

        }

    }
}
