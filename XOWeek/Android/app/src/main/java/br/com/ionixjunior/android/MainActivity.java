package br.com.ionixjunior.android;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private Button _btCarregar;
    private TextView _lbDescricao;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        _btCarregar = (Button)this.findViewById(R.id.btCarregar);
        _lbDescricao = (TextView)this.findViewById(R.id.lbDescricao);

        _btCarregar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                _lbDescricao.setText("XOWeek - Android");
            }
        });
    }

}
