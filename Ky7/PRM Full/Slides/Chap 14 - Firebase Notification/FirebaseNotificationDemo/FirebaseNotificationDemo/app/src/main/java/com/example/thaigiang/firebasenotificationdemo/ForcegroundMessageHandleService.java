package com.example.thaigiang.firebasenotificationdemo;

import android.app.Service;
import android.content.Intent;
import android.os.Bundle;
import android.os.IBinder;
import android.support.v4.content.LocalBroadcastManager;
import android.util.Log;
import android.widget.Toast;

import com.google.firebase.messaging.FirebaseMessagingService;
import com.google.firebase.messaging.RemoteMessage;

import java.util.Map;

public class ForcegroundMessageHandleService extends FirebaseMessagingService {
    public ForcegroundMessageHandleService() {
    }

    String TAG = "Firebase notification";

    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {
        Log.d(TAG, "Notification Title: " +
                remoteMessage.getNotification().getTitle());
        Log.d(TAG, "Notification Message: " +
                remoteMessage.getNotification().getBody());

        Intent intent = new Intent();
        Bundle extras = new Bundle();
        extras.putString("Title",remoteMessage.getNotification().getTitle());
        extras.putString("Message",remoteMessage.getNotification().getBody());


        for (Map.Entry<String, String> entry : remoteMessage.getData().entrySet()) {
            String key = entry.getKey();
            String value = entry.getValue();
            extras.putString(key, value);
        }

        intent.putExtras(extras);
        intent.setAction("com.my.app.onMessageReceived");
        sendBroadcast(intent);


    }
}
