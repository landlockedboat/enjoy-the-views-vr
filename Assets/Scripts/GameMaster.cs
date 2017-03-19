using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singleton<GameMaster> {
    Action onGameOverCallback;

    public void RegisterOnGameOverCallback(Action onGameOverCallback)
    {
        this.onGameOverCallback += onGameOverCallback;
    }

    public void GameOver()
    {
        TriggerCallback(onGameOverCallback);
    }

    void TriggerCallback(Action callback)
    {
        if (callback != null)
        {
            callback();
        }
    }

}
