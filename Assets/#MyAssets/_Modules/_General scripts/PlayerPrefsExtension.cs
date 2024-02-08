using UnityEngine;

public static class PlayerPrefsExtension
{
    public static bool GetBool(string key, bool defaultValue)
    {
        var result = PlayerPrefs.GetInt(key, -1);

        if (result == 1)
        {
            return true;
        }
        else if (result == 0)
        {
            return false;
        }
        else
        {
            return defaultValue;
        }
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
}
