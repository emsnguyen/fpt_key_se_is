package com.example.thaigiang.notificationdemo;

import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.TaskStackBuilder;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.support.annotation.RequiresApi;
import android.support.v4.app.NotificationCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

public class NotificationDemoActivity extends AppCompatActivity {

    private final int notificationId = 101;
    private final String NOTIFICATION_CHANNEL = "My channel";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_notification_demo);
    }


    @RequiresApi(api = Build.VERSION_CODES.O)
    public void sendNotification(View view) {

        Intent resultIntent = new Intent(this, NotificationReceiverActivity.class);
        PendingIntent pendingIntent = PendingIntent.getActivity(this, 0, resultIntent, PendingIntent.FLAG_UPDATE_CURRENT);
        Notification.Builder builder = new Notification.Builder(this, NOTIFICATION_CHANNEL)
                .setSmallIcon(android.R.drawable.ic_dialog_info)
                .setContentTitle("A Notification")
                .setContentText("This is an example notification")
                .setChannelId(NOTIFICATION_CHANNEL)
                .setContentIntent(pendingIntent);

        NotificationChannel channel = new NotificationChannel(NOTIFICATION_CHANNEL, "My notification channel", NotificationManager.IMPORTANCE_HIGH);
        NotificationManager notificationManager =(NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        notificationManager.createNotificationChannel(channel);
        notificationManager.notify(notificationId, builder.build());
    }
}
