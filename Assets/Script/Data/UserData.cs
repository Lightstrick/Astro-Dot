using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    
}

public static class Options
{
    private const string VOLUME_PREF_KEY = "volume";

    public static float Volume = PlayerPrefs.HasKey(VOLUME_PREF_KEY) ? PlayerPrefs.GetFloat(VOLUME_PREF_KEY) : 1;

    public static void SetVolume (float volume = 1)
    {
        PlayerPrefs.SetFloat(VOLUME_PREF_KEY, volume);
    }
}