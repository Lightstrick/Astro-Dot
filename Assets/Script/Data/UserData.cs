using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;

[Serializable]
public class UserData
{
    private const string DATA_PATH = "data.astro";
    private static UserData current;
    public static UserData Current
    {
        get
        {
            if(current == null)
            {
                Load();
            }
            return current;
        }
    }

    public int AccumulatedScore = 0;
    public int BestScore = 0;

    private static bool isLoaded = false;

    private static void Load ()
    {
        var path = Path.Combine(Application.persistentDataPath, DATA_PATH);

        try
        {
            if (File.Exists(path))
            {
                FileStream file = File.Open(path, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                current = (UserData)formatter.Deserialize(file);
                file.Close();
            }
            else
            {
                //Create new user data file
                CreateNewUserDataFile();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occured while loading user data: \n" + ex.Message);
            CreateNewUserDataFile();
        }
    }

    private static void Save ()
    {
        if(current == null)
        {
            return;
        }

        var path = Path.Combine(Application.persistentDataPath, DATA_PATH);

        try
        {
            FileStream file = File.Create(path);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, current);
            file.Close();
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occured while saving user data: \n" + ex.Message);
        }
    }

    private static void CreateNewUserDataFile ()
    {
        current = new UserData();
        Save();
    }

    public void AccumulateScore (int score)
    {
        AccumulatedScore += score;

        if(score > BestScore)
        {
            BestScore = score;
        }

        Save();
    }
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