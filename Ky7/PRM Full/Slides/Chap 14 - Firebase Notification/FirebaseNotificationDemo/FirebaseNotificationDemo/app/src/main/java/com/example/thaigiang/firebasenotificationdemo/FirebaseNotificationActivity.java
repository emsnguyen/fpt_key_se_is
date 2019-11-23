package com.example.thaigiang.firebasenotificationdemo;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.support.v4.content.LocalBroadcastManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

public class FirebaseNotificationActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_firebase_notification);


        Bundle customData = getIntent().getExtras();
        if (customData != null) {
            TextView textView = (TextView) findViewById(R.id.textView);
            textView.setText(customData.getString("Android class scheule"));
        }
    }


    @Override
    protected void onResume() {
        super.onResume();
        IntentFilter intentFilter = new IntentFilter();
        intentFilter.addAction("com.my.app.onMessageReceived");
        MyBroadcastReceiver receiver = new MyBroadcastReceiver();
        registerReceiver(receiver, intentFilter);
    }

    private class MyBroadcastReceiver extends BroadcastReceiver {
        @Override
        public void onReceive(Context context, Intent intent) {
            Bundle extras = intent.getExtras();

            String message = "";

            for (String key: extras.keySet()) {
                message += key + ": " + extras.getString(key) + "\n";
            }

            updateView(message);// update your textView in the main layout
        }
    }

    public void updateView(String text){
        TextView textView = findViewById(R.id.textView);
        textView.setText(text);
    }
}
