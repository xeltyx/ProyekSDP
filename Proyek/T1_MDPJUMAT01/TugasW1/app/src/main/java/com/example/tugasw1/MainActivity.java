package com.example.tugasw1;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    Button[][] arrbtn = new Button[6][5];
    Boolean wingame=false;
    int temp=0;
    int kolom=0;
    int baris=5;
    int player1=0,player2=0;
    Boolean firstplayer=true;
    TextView text1,text2;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        reset();
        findViewById(R.id.btnreset).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                reset();
                player1=0;
                player2=0;
                text1.setText("Player1:"+player1);
                text2.setText("Player2:"+player2);
            }
        });

        findViewById(R.id.btnnewgame).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                reset();
            }
        });
        text1=findViewById(R.id.tvplayer1);
        text2=findViewById(R.id.tvplayer2);
    }

    public void reset()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                String btnId ="btn"+i+j;
                int srcId = getResources().getIdentifier(btnId, "id", getPackageName());
                arrbtn[i][j] = findViewById((srcId));
                arrbtn[i][j].setTag("gray");
                arrbtn[i][j].setBackgroundColor(getResources().getColor(R.color.gray));
                firstplayer=true;
                wingame=false;
                baris=5;
            }
        }
    }

    public void winlogic(){
        for (int i=0; i<3; i++)
        {
            if(arrbtn[i+0][kolom].getTag().equals("cyan")
                    && arrbtn[i+1][kolom].getTag().equals("cyan")
                    && arrbtn[i+2][kolom].getTag().equals("cyan")
                    && arrbtn[i+3][kolom].getTag().equals("cyan"))
            {
                int duration = Toast.LENGTH_SHORT;
                Toast toast = Toast.makeText(getApplicationContext(), "player1 win", duration);
                toast.show();
                wingame=true;
                player1++;
                text1.setText("Player1:"+player1);
            }

            else if(arrbtn[i+0][kolom].getTag().equals("red")
                    && arrbtn[i+1][kolom].getTag().equals("red")
                    && arrbtn[i+2][kolom].getTag().equals("red")
                    && arrbtn[i+3][kolom].getTag().equals("red"))
            {
                int duration = Toast.LENGTH_SHORT;
                Toast toast = Toast.makeText(getApplicationContext(), "player2 win", duration);
                toast.show();
                wingame=true;
                player2++;
                text2.setText("Player2:"+player2);
            }
        }

        for(int i=0; i<6; i++)
        {
            for(int j=0;j<2; j++)
            {
                if(arrbtn[i][j+0].getTag().equals("cyan")
                        && arrbtn[i][j+1].getTag().equals("cyan")
                        && arrbtn[i][j+2].getTag().equals("cyan")
                        && arrbtn[i][j+3].getTag().equals("cyan"))
                {
                    int duration = Toast.LENGTH_SHORT;
                    Toast toast = Toast.makeText(getApplicationContext(), "player1 win", duration);
                    toast.show();
                    wingame=true;
                    player1++;
                    text1.setText("Player1:"+player1);
                    break;
                }
                else if(arrbtn[i][j+0].getTag().equals("red")
                        && arrbtn[i][j+1].getTag().equals("red")
                        && arrbtn[i][j+2].getTag().equals("red")
                        && arrbtn[i][j+3].getTag().equals("red"))
                {
                    int duration = Toast.LENGTH_SHORT;
                    Toast toast = Toast.makeText(getApplicationContext(), "player2 win", duration);
                    toast.show();
                    wingame=true;
                    player2++;
                    text2.setText("Player2:"+player2);
                    break;
                }
            }
        }
    }

    public void btnclick(View view){
        if(view.getTag().equals("gray"))
        {
            if(!wingame)
            {
                String btntxt = ((Button)view).getText().toString();
                kolom=Integer.parseInt(btntxt.charAt(1)+"");
                if(kolom!=temp)
                {
                    baris=5;
                    for (int i=5; i>-1; i--)
                    {
                        if(!arrbtn[i][kolom].getTag().equals("gray"))
                            baris--;
                    }
                }
                temp=kolom;

                if(baris<0)
                    baris=0;

                if(firstplayer==true){
                    arrbtn[baris][kolom].setBackgroundColor(getResources().getColor(R.color.cyan));
                    arrbtn[baris][kolom].setTag("cyan");
                    firstplayer=false;
                }
                else
                {
                    arrbtn[baris][kolom].setBackgroundColor(getResources().getColor(R.color.red));
                    arrbtn[baris][kolom].setTag("red");
                    firstplayer=true;
                }
                winlogic();

                baris--;
            }
        }
    }



}