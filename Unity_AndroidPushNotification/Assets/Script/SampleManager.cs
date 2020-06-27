using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private Button m_PushNotificaitonButton_Immediately = null;
    [SerializeField]
    private Button m_PushNotificationButton_Delay = null;
    [SerializeField]
    private Button m_PushNotificationButton_Repeating = null;
    [SerializeField]
    private Button m_CancelButton = null;


    private void OnApplicationQuit()
    {
#if UNITY_ANDROID
        NotificationControl.CancelNotificationAll();
#endif
    }

    private void Awake()
    {
#if UNITY_ANDROID
        NotificationControl.LoadNotificationData();
        NotificationControl.CancelNotificationAll();
        NotificationControl.ClearShowNotification();
#endif

        m_PushNotificaitonButton_Immediately.onClick.AddListener(delegate { PushNotificationOnce(0, 0); });
        m_PushNotificationButton_Delay.onClick.AddListener(delegate { PushNotificationOnce(1, 60); });
        m_PushNotificationButton_Repeating.onClick.AddListener(delegate { PushNotificationRepeating(2, 60); });
        m_CancelButton.onClick.AddListener(delegate { CancelAllNotification(); });
    }

    public void PushNotificationOnce(int id, int delayTime)
    {
#if UNITY_ANDROID
        NotificationControl.SetNotificationOnce(id, delayTime, "Notification Title", string.Format($"Push Notification delayTime is {delayTime} Sec."), null,
            "sampleimage", Color.white, "samplering");
#endif
    }

    public void PushNotificationRepeating(int id, int delayTime)
    {
#if UNITY_ANDROID
        NotificationControl.SetNotificationRepeating(id, delayTime, delayTime, "Notification Title (Repeating)", string.Format($"Push Notification delay Time / repeating Time is {delayTime} Sec."), null,
            "sampleimage", Color.white, "samplering");
#endif
    }

    public void CancelAllNotification()
    {
#if UNITY_ANDROID
        NotificationControl.CancelNotificationAll();
#endif
    }

}
