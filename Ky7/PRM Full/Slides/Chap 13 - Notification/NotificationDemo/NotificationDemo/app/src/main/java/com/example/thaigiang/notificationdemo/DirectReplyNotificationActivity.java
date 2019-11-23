package com.example.thaigiang.notificationdemo;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.support.annotation.RequiresApi;
import android.support.v4.app.NotificationCompat;
import android.support.v4.app.RemoteInput;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

public class DirectReplyNotificationActivity extends AppCompatActivity {

    private static int notificationId = 101;
    private final String NOTIFICATION_CHANNEL = "My channel";
    private static String KEY_TEXT_REPLY = "key_text_reply";

    @RequiresApi(api = Build.VERSION_CODES.O)
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_direct_reply_notification);

        Intent intent = this.getIntent();
        Bundle bundleData = RemoteInput.getResultsFromIntent(intent);
        if (bundleData != null) {
            TextView myTextView = (TextView) findViewById(R.id.textView2);
            String inputString = bundleData.getCharSequence(
                    KEY_TEXT_REPLY).toString();
            myTextView.setText(inputString);
            Notification repliedNotification = new Notification.Builder(this)
                    .setSmallIcon(android.R.drawable.ic_dialog_info)
                    .setContentText("Reply received")
                    .setChannelId(NOTIFICATION_CHANNEL)
                    .build();
            NotificationManager notificationManager =
                    (NotificationManager)
                            getSystemService(Context.NOTIFICATION_SERVICE);
            notificationManager.notify(notificationId,
                    repliedNotification);
        }
    }



    public void sendNotification(View view) {
        String replyLabel = "Enter your reply here";
        RemoteInput remoteInput = new RemoteInput.Builder(KEY_TEXT_REPLY)
                .setLabel(replyLabel)
                .build();


        Intent resultIntent = new Intent(this, DirectReplyNotificationActivity.class);
        PendingIntent resultPendingIntent =
                PendingIntent.getActivity(this, 0, resultIntent, PendingIntent.FLAG_UPDATE_CURRENT);


        NotificationCompat.Action replyAction = new NotificationCompat.Action.Builder(
                android.R.drawable.ic_dialog_info,
                "Reply", resultPendingIntent)
                .addRemoteInput(remoteInput)
                .build();

        Notification newMessageNotification = new NotificationCompat.Builder(this)
                .setColor(ContextCompat.getColor(this, R.color.colorPrimary))
                .setSmallIcon(android.R.drawable.ic_dialog_info)
                .setContentTitle("My Notification")
                .setContentText("This is a test message")
                .addAction(replyAction)
                .setChannelId(NOTIFICATION_CHANNEL)
                .build();

        NotificationManager notificationManager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        notificationManager.notify(notificationId, newMessageNotification);


    }
}
