using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 점수 계산, 변수값들 모아두는 역할

public class DataManager : MonoBehaviour
{   //게임 플레이 타임 
    public float playerTimeCurrent = 10f;
    public float playImeMax = 10f;
    //플레이어 사망 판단 
    public bool playerDie = false;


    static DataManager instance;
    public static DataManager Instance
 

    {
        get {
            return instance;
        }
    }
    //? 
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //실제 스코어 저장할 곳 
    public int score = 0;



}


