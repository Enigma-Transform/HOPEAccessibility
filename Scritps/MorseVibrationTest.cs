using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MorseVibrationTest
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

#else
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator;

#endif

    public static void Viberate(long milliseconds = 250)
    {
        if(IsAndroid())
        {
            vibrator.Call("vibrate", milliseconds);
        }
        else
        {
            Handheld.Vibrate();
        }
    }
    public static void VibrateMorseCode(string code)
    {
        // Make sure the vibrator object is not null and the platform is Android
        if (vibrator != null && Application.platform == RuntimePlatform.Android)
        {
            // Convert the Morse code string to vibrations
            foreach (char c in code)
            {
                if (c == '.') // Short signal
                {
                    Viberate(200); // Vibrate for 200 milliseconds (0.2 seconds)
                    // Delay for a short pause
                    System.Threading.Thread.Sleep(300); // Wait for 300 milliseconds (0.3 seconds)
                }
                else if (c == '-') // Long signal
                {
                    Viberate(600); // Vibrate for 600 milliseconds (0.6 seconds)
                    // Delay for a short pause
                    System.Threading.Thread.Sleep(300); // Wait for 300 milliseconds (0.3 seconds)
                }
                else if (c == ' ') // Word separator
                {
                    // Delay for a longer pause
                    System.Threading.Thread.Sleep(700); // Wait for 700 milliseconds (0.7 seconds)
                }
            }
        }
    }

  
    public static void Cancel()
    {
        if (IsAndroid())
        {
            vibrator.Call("cancel");
        }
    }
    public static bool IsAndroid()
    {
#if UNITY_ANDROID
        return true;


#else
    return false;
#endif
    }
}



