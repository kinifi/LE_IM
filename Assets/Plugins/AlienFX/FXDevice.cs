using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using AlienFXManagedWrapper;

namespace Alienware
{
    public class FXDevice 
    {
        public uint index { get; private set; }
        public string name { get; private set; }
        public LFX_DeviceType devType { get; private set; }

        public List<FXLightController> lights;

        public FXDevice(uint index, string name, LFX_DeviceType devType)
        {
            this.index = index;
            this.name = name;
            this.devType = devType;

            lights = new List<FXLightController>();
        }
    }
}

