using UnityEngine;
using System.Collections;

using AlienFXManagedWrapper;

public static class WrapperExtensions
{
    public static uint GetHexColor(this LFX_ColorStruct lfxColor)
    {
          return (uint)lfxColor.brightness << 24 |
                 (uint)lfxColor.red << 16 |
                 (uint)lfxColor.green << 8 |
                 (uint)lfxColor.blue;
    }
}
