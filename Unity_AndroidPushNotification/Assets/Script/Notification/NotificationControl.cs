using System;
using UnityEngine;

public static class NotificationControl
{
#if UNITY_ANDROID
    private static string androidNotificationClassName = "jm.plugin.androidnotification.PushNotificationManager";
    private static AndroidJavaClass pluginClass = null;
#endif

#if UNITY_5_6_OR_NEWER
    private static string bundleIdentifier
    {
        get
        {
            return Application.identifier;
        }
    }
#else
    private static string bundleIdentifier
    {
        get
        {
            return Application.identifier;
        }
    }
#endif

    public static bool SetNotificationOnce(int id, int delaySec, string titleOrNull, string messageOrNull, string tickerOrNull, string iconOrNull, Color color,
        string soundNameOrNull, bool isSmall_Icon = true, bool isSound = true, bool isVibrate = true, bool isLight = true) 
    {
#if UNITY_ANDROID
        if (pluginClass != null)
        {
            if (id < 0)
            {
                Debug.Assert(false, "Error - ID is not under 0");
                return false;
            }

            if (titleOrNull == null)
            {
                titleOrNull = "";
            }
            
            if (messageOrNull == null)
            {
                messageOrNull = "";
            }

            if (tickerOrNull == null)
            {
                tickerOrNull = "";
            }

            if (iconOrNull == null)
            {
                iconOrNull = "";
            }

            if (soundNameOrNull == null)
            {
                soundNameOrNull = "";
            }


            long delayMS = delaySec * 1000;

            pluginClass.CallStatic("SetNotificationOnce", id, bundleIdentifier, delayMS, titleOrNull, messageOrNull, tickerOrNull,
                                    iconOrNull, ColorToInt(color), isSmall_Icon, isSound, soundNameOrNull, isVibrate, isLight);
        }
        else
        {
            Debug.Assert(false, "pluginClass is NULL");
            return false;
        }

        return true;
#else
        return false;
#endif
    }

    public static bool SetNotificationRepeating(int id, int delaySec, int repSec, string titleOrNull, string messageOrNull, string tickerOrNull, string iconOrNull,
                                               Color color, string soundNameOrNull, bool isSmall_Icon = true, bool isSound = true, bool isVibrate = true,
                                               bool isLight = true)
    {
#if UNITY_ANDROID
        if (pluginClass != null)
        {
            if (id < 0)
            {
                Debug.Assert(false,"Error - ID is not under 0");
                return false;
            }

            if (titleOrNull == null)
            {
                titleOrNull = "";
            }

            if (messageOrNull == null)
            {
                messageOrNull = "";
            }

            if (tickerOrNull == null)
            {
                tickerOrNull = "";
            }

            if (iconOrNull == null)
            {
                iconOrNull = "";
            }

            if (soundNameOrNull == null)
            {
                soundNameOrNull = "";
            }

            long delayMS = delaySec * 1000;
            long repeatMS = repSec * 1000;

            pluginClass.CallStatic("SetNotificationRepeating", id, bundleIdentifier, delayMS, repeatMS, titleOrNull, messageOrNull, tickerOrNull, iconOrNull, isSmall_Icon,
                ColorToInt(color), isSound, soundNameOrNull, isVibrate, isLight);
        }
        else
        {
            Debug.Assert(false,"pluginClass is NULL !");
            return false;
        }

        return true;
#else
        return false;
#endif
    }

    public static void CancelNotificationAll()
    {
#if UNITY_ANDROID
        if (pluginClass != null)
        {
            pluginClass.CallStatic("CancelPendingNotificationAll");
        }
#endif
    }

    public static int CancelNotification(int id)
    {
#if UNITY_ANDROID
        if (pluginClass != null)
        {
            pluginClass.CallStatic("CancelPendingNotification", id);
        }
#endif
        return id;
    }

    public static void ClearShowNotification()
    {
#if UNITY_ANDROID

        if (pluginClass != null)
        {
            pluginClass.CallStatic("ClearShowingNotification");
        }
#endif
    }

    public static void LoadNotificationData()
    {
#if UNITY_ANDROID
        pluginClass = new AndroidJavaClass(androidNotificationClassName);
        if (pluginClass != null)
        {
            pluginClass.CallStatic("LoadNotificationStatic");
        }
#endif
    }

    private static int ColorToInt(Color32 color)
    {
        return color.r * 65536 + color.g * 256 + color.b;
    }
}
