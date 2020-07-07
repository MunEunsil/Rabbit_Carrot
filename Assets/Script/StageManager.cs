using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static string[] sceneNameArray = { "", "Stage_1", "Stage_2", "Stage_3","Stage_4","Stage_5","Stage_6","Stage_7","Stage_8","Stage_9","Stage_10","Stage_11"};
    public static string[] sceneStoryNameArry = { "", "Stage1_story", "Stage2_story", "Stage3_story", "Stage4_story", "Stage5_story", "Stage6_story", "Stage7_story", "Stage8_story", "Stage9_story", "Stage10_story" };
    private static StageManager _instance = null;

    public static StageManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(StageManager)) as StageManager;
            }
            return _instance;
        }
    }

    public int StageNum { get; set; }

    private void Awake()
    {
        InitInstance();
    }

    private void InitInstance()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public string GetCurrentStage()
    {
        return sceneNameArray[StageNum];
    }
}
 