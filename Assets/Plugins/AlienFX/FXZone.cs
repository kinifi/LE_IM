using UnityEngine;
using System.Collections;

using AlienFXManagedWrapper;

namespace Alienware
{
    public class FXZone : FXBase
    {
        public int priority { get; private set; }

        public FXZone(LFX_Position position, int priority = 0)
            : base(position)
        {
            this.priority = priority;
        }
    }
}
