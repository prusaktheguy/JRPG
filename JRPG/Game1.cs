using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace JRPG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        private static MainGame instance;
        public static MainGame Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainGame();
                }
                return instance;
            }
        }

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private GamescreenManager gamescreenManager;
        public GamescreenManager GamescreenManager
        {
            get
            {
                return gamescreenManager;
            }
        }

        private InputManager inputManager;
        public InputManager InputManager
        {
            get
            {
                return inputManager;
            }
        }

        private ContentManager contentManager;
        public ContentManager ContentManager
        {
            get
            {
                return contentManager;
            }
        }

        private SoundManager soundManager;
        public SoundManager SoundManager
        {
            get
            {
                return soundManager;
            }
        }

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            inputManager = new InputManager();
            gamescreenManager = new GamescreenManager();
            contentManager = new ContentManager();
            soundManager = new SoundManager(new List<SoundFX> {
                new SoundFX {
                    Key = "Coin", Filename = "Content/SFX/coin.wav", DefaultPitch = 1, DefaultVolume = 0.10f
                }
            });
        }

        protected override void Initialize()
        {
            base.Initialize();

            gamescreenManager.Push(new StartupGamescreen());
        }

        protected override void LoadContent()
        {
            contentManager.Prepare(GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            soundManager.LoadContent(contentManager);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime);

            gamescreenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gamescreenManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
