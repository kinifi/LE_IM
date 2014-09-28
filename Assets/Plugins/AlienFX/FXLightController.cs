using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using AlienFXManagedWrapper;

namespace Alienware
{
    public class FXLightController : FXBase
    {
        public uint index { get; private set; }
        public string name { get; private set; }

        private int maxPriority = 0;

        private List<FXLight> lights;

        public FXLightController(uint index, string name, LFX_Position position, int priority = 0)
            : base(position)
        {
            this.index = index;
            this.name = name;

            lights = new List<FXLight>();

            Reset();
        }

        public FXLight GetLight(int priority)
        {
            FXLight result = null;

            foreach (FXLight state in lights)
            {
                if (state.priority == priority)
                {
                    result = state;
                    break;
                }
            }

            if (result == null)
            {
                result = new FXLight(this, priority);
                lights.Add(result);
            }

            return result;
        }

        public void SetColor(Color color, int priority)
        {
            if (this.maxPriority <= priority)
            {
                this.color = color;
                this.maxPriority = priority;
            }
        }

        public void Reset()
        {
            maxPriority = 0;
        }
    }
}

