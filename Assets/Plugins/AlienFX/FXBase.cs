using UnityEngine;
using System.Collections;

using AlienFXManagedWrapper;

namespace Alienware
{
    public abstract class FXBase
    {
        public LFX_Position position { get; protected set; }
        public LFX_ColorStruct lfxColor;

        protected Color _color;
        public Color color
        {
            get { return _color; }

            set
            {
                _color = value;

                lfxColor.brightness = (byte)(_color.a * 255f);
                lfxColor.red = (byte)(_color.r * 255f);
                lfxColor.green = (byte)(_color.g * 255f);
                lfxColor.blue = (byte)(_color.b * 255f);
            }
        }

        public FXBase(LFX_Position position)
        {
            this.position = position;

            this.color = Color.black;
        }
    }
}

