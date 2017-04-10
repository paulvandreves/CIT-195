using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Demo_MG_MazeGame
{
    public class Jewel
    {
        #region ENUMS

        public enum TypeName
        {
            Green,
            Red,
            Blue,
            heart


        }

        #endregion

        #region FIELDS

        private ContentManager _contentManager;
        private Texture2D _sprite;
        private TypeName _type;
        private int _spriteWidth;
        private int _spriteHeight;
        private Vector2 _position;
        private Vector2 _center;
        private int _speedHorizontal;
        private int _speedVertical;
        private Rectangle _boundingRectangle;
        private bool _active;
        private Microsoft.Xna.Framework.Content.ContentManager Content;
        private TypeName typeName;
        private Vector2 vector2;
        private Color color;

        #endregion

        #region PROPERTIES

        public ContentManager ContentManager
        {
            get { return _contentManager; }
            set { _contentManager = value; }
        }

        public TypeName Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _center = new Vector2(_position.X + (_spriteWidth / 2), _position.Y + (_spriteHeight / 2));
                _boundingRectangle = new Rectangle((int)_position.X, (int)_position.Y, _spriteWidth, _spriteHeight);
            }
        }

        public Vector2 Center
        {
            get { return _center; }
            set { _center = value; }
        }

        public int SpeedHorizontal
        {
            get { return _speedHorizontal; }
            set { _speedHorizontal = value; }
        }

        public int SpeedVertical
        {
            get { return _speedVertical; }
            set { _speedVertical = value; }
        }

        public Rectangle BoundingRectangle
        {
            get { return _boundingRectangle; }
            set { _boundingRectangle = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// instantiate a new Player
        /// </summary>
        /// <param name="contentManager">game content manager object</param>
        /// <param name="spriteName">file name of sprite</param>
        /// <param name="position">vector position of Player</param>
        public Jewel(
            ContentManager contentManager,
            TypeName type,
            Vector2 position
            )
        {
            _contentManager = contentManager;
            _type = type;
            _position = position;

            // load the jewel image
            if (type == TypeName.Blue)
            {
                _sprite = _contentManager.Load<Texture2D>("Sapphire");
            }
            if (type == TypeName.Green)
            {
                _sprite = _contentManager.Load<Texture2D>("green_jewel");
            }
            if (type == TypeName.heart)
            {
                _sprite = _contentManager.Load<Texture2D>("heart");
            }
            _active = true;
            
            _spriteWidth = _sprite.Width;
            _spriteHeight = _sprite.Height;

            // set the initial center and bounding rectangle for the player
            _center = new Vector2(position.X + (_spriteWidth / 2), position.Y + (_spriteHeight / 2));
            _boundingRectangle = new Rectangle((int)position.X, (int)position.Y, _spriteWidth, _spriteHeight);
        }

        public Jewel(Microsoft.Xna.Framework.Content.ContentManager Content, TypeName typeName, Vector2 vector2, Color color)
        {
            // TODO: Complete member initialization
            this.Content = Content;
            this.typeName = typeName;
            this.vector2 = vector2;
            this.color = color;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// add Player sprite to the SpriteBatch object
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // only draw the player if it is active
            if (_active)
            {
                spriteBatch.Draw(_sprite, _position, Color.White);
            }
        }

        /// <summary>
        /// update each death ball
        /// </summary>
        public void Update()
        {
            Position += new Vector2(SpeedHorizontal, SpeedVertical);
        }

        #endregion
    }
}

