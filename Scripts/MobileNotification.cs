using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class MobileNotification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Remove notification
        AndroidNotificationCenter.CancelAllDisplayedNotifications();


        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);


        var notification = new AndroidNotification();
        notification.Title = "Math Genius";
        notification.Text = "Hey Genius! Come back";
        notification.FireTime = System.DateTime.Now.AddSeconds(15);

       var id =  AndroidNotificationCenter.SendNotification(notification, "channel_id");

        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
        notification.LargeIcon = "my_custom_large_icon_id";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
