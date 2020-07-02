using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static string[] sceneNameArray = { "", "Stage_1", "Stage_2", "Stage_3","Stage_4"};

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
 