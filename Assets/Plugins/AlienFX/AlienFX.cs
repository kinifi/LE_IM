using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Alienware;
using AlienFXManagedWrapper;

public class AlienFX : MonoBehaviour
{
    public int updatesPerSecond = 30;

    public static bool isLoaded { get { return _instance != null; } }
    public static bool isInit { get; private set; }

    private static List<FXZone> zones;
    private static List<FXDevice> devices;

    private static bool _applicationIsQuitting;

    private static ILightFXController fxControl = null;

    #region Unity Methods
    private static AlienFX _instance = null;
    private static AlienFX instance
    {
        get
        {
            // Don't allow new instances to be created when the application is quitting to avoid the object never being destroyed.
            // These dangling instances can't be found with FindObjectOfType and so you'd get multiple instances in a scene.
            if (!_instance && !_applicationIsQuitting)
            {
                // check if there is a GO instance already available in the scene graph
                _instance = FindObjectOfType(typeof(AlienFX)) as AlienFX;

                // nope, create a new one
                if (!_instance)
                {
                    var obj = new GameObject("AlienFX");
                    _instance = obj.AddComponent<AlienFX>();
                    DontDestroyOnLoad(obj);
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        isInit = false;
        _applicationIsQuitting = false;

        if (!isInit)
        {
            Startup();
        }
    }

    private void OnDestroy()
    {
        Shutdown();
    }

    private void OnApplicationQuit()
    {
        Shutdown();

        _instance = null;
        Destroy(gameObject);
        _applicationIsQuitting = true;
    }
    #endregion

    public static FXLight GetLightByName(string word)
    {
        return GetLightByName(0, word);
    }

    public static FXLight GetLightByName(int priority, string word)
    {
        if (!isLoaded)
            Load();

        if (!isInit)
            return null;

        foreach (var device in devices)
        {
            foreach (var light in device.lights)
            {
                if (light.name.Contains(word))
                {
                    return light.GetLight(priority);
                }
            }
        }

        return null;
    }

    public static List<FXLight> GetLightsByName(params string[] words)
    {
        return GetLightsByName(0, words);
    }

    public static List<FXLight> GetLightsByName(int priority, params string[] words)
    {
        if (!isLoaded)
            Load();

        if (!isInit)
            return null;

        List<FXLight> result = new List<FXLight>();

        foreach (var device in devices)
        {
            foreach (var light in device.lights)
            {
                bool match = true;

                foreach (string word in words)
                {
                    if (!light.name.Contains(word))
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    result.Add(light.GetLight(priority));
                }
            }
        }

        return result;
    }

    public static List<FXLight> GetLightsByPosition(LFX_Position position)
    {
        return GetLightsByPosition(0, position);
    }

    public static List<FXLight> GetLightsByPosition(int priority, LFX_Position position)
    {
        if (!isLoaded)
            Load();

        if (!isInit)
            return null;

        List<FXLight> result = new List<FXLight>();

        foreach (var device in devices)
        {
            foreach (var light in device.lights)
            {
                if ((light.position & position) != 0)
                {
                    result.Add(light.GetLight(priority));
                }
            }
        }

        return result;
    }

    public static FXZone GetZoneByPosition(LFX_Position position)
    {
        return GetZoneByPosition(0, position);
    }

    public static FXZone GetZoneByPosition(int priority, LFX_Position position)
    {
        if (!isLoaded)
            Load();

        if (!isInit)
            return null;

        FXZone result = new FXZone(position, priority);
        zones.Add(result);

        return result;
    }

    public static void RemoveZone(FXZone zone)
    {
        zones.Remove(zone);
    }

    // force the lazy load.
    public static void Load()
    {
        _instance = instance;
    }

    private void Startup()
    {
        fxControl = new LightFXController();

        devices = new List<FXDevice>();
        zones = new List<FXZone>();

        var result = fxControl.LFX_Initialize();
        if (result == LFX_Result.LFX_Success)
        {
            Debug.Log("AlienFX: Initialized.");

            isInit = true;

            const byte MAX_BUFFER = 255;
            uint numDevices;

            fxControl.LFX_GetNumDevices(out numDevices);
            for (uint devIndex = 0; devIndex < numDevices; ++devIndex)
            {
                // get the device type.
                var desc = new StringBuilder(MAX_BUFFER);
                LFX_DeviceType devType;

                fxControl.LFX_GetDeviceDescription(devIndex, desc, MAX_BUFFER, out devType);

                FXDevice dev = new FXDevice(devIndex, desc.ToString(), devType);

                devices.Add(dev);
                
                // get the zones for this device.
                uint numLights;
                fxControl.LFX_GetNumLights(devIndex, out numLights);

                for (uint lightIndex = 0; lightIndex < numLights; ++lightIndex)
                {
                    LFX_Position position;

                    desc = new StringBuilder(MAX_BUFFER);

                    fxControl.LFX_GetLightDescription(devIndex, lightIndex, desc, MAX_BUFFER);
                    fxControl.LFX_GetLightLocation(devIndex, lightIndex, out position);

                    FXLightController light = new FXLightController(lightIndex, desc.ToString(), position);

                    //Debug.Log("Adding: " + light.name);

                    dev.lights.Add(light);
                }
            }

            StartCoroutine("Run");
        }
        else
        {
            Debug.LogError("AlienFX: Failed Init.");
        }
    }

    private IEnumerator Run()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / updatesPerSecond);

            foreach (var device in devices)
            {
                foreach (var light in device.lights)
                {
                    foreach (var zone in zones)
                    {
                        if ((zone.position & light.position) != 0)
                        {
                            // this light is in a defined zone,so try setting the color.
                            light.SetColor(zone.color, zone.priority);
                        }
                    }
                    
                    // now that all of the zones have been applied, our light has all of the proper information
                    // to determine what the highest priority color should be.

                    // send the color to the hardware
                    fxControl.LFX_SetLightColor(device.index, light.index, ref light.lfxColor);

                    // reset the max priority for the light for the next "commit"
                    light.Reset();
                }
            }

            fxControl.LFX_Update();
        }
    }

    private void Shutdown()
    {
        if (isInit)
        {
            StopCoroutine("Run");

            if (fxControl != null)
            {
                Debug.Log("AlienFX: Released.");

                fxControl.LFX_Release();
            }

            isInit = false;
        }
    }
}
