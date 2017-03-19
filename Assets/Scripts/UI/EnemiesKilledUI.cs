using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesKilledUI : Singleton<EnemiesKilledUI> {

    int enemiesKilled;
    TextMesh enemiesKilledText;

    private void Start()
    {
        enemiesKilledText = GetComponent<TextMesh>();
    }

    public void EnemyKilled(){
        ++enemiesKilled;
        enemiesKilledText.text = enemiesKilled.ToString();
    }

}
