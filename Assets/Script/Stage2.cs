﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2: MonoBehaviour
{
    public int stageNum;
    // Start is called before the first frame update
    void Start()
    {
       // ChangeScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene() {
        if (StageManager.sceneClearInfo[stageNum] !=0) {
            StageManager.Instance.StageNum = stageNum;
            SceneManager.LoadScene(StageManager.sceneStoryNameArry[stageNum]);
        }
    }
}
