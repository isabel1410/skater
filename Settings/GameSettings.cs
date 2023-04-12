using System.IO;
using UnityEngine;


[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Settings")]
    public float MusicVolume;
    public float SfxVolume;

    private string _jsonPath => Application.dataPath + "/" + name + ".txt";

    internal void Save()
    {
        string settings = JsonUtility.ToJson(this, true);
        File.WriteAllText(_jsonPath, settings);
    }

    internal void Load()
    {
#if !UNITY_EDITOR
        Reset();
#endif
        if (File.Exists(_jsonPath))
        {
            string settingsText = File.ReadAllText(_jsonPath);
            JsonUtility.FromJsonOverwrite(settingsText, this);
        }
    }

    private void Reset()
    {
        MusicVolume = .5f;
        SfxVolume = .5f;
    }

}
