using UnityEngine;
using System.Collections;

namespace Alienware
{
    public class FXLight
    {
        public FXLightController light;
        public int priority;

        private Color _color;
        public Color color
        {
            get { return _color;  }
            set
            {
                _color = value;

                light.SetColor(_color, priority);
            }
        }

        public FXLight(FXLightController light, int priority)
        {
            this.light = light;
            this.priority = priority;
        }
    }
}
