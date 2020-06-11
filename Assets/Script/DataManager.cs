using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 점수 계산, 변수값들 모아두는 역할

public class DataManager : MonoBehaviour
{   //게임 플레이 타임 
    public float playerTimeCurrent = 10f;
    public float playImeMax = 10f;
    public float playlmeMin = 0f;
    //플레이어 사망 판단 
    public bool playerDie = false;

    //스테이지 클리어 판단 
    public bool stageClear = false;

    //아이템 효과를 위한 bool
    public bool EatBadHeart = false;

    //내부적으로 맵 번호 설정하기 
    public int map = 0;
    public int mapView = 0;


    static DataManager instance = null;
    public static DataManager Instance{
        get {
            return instance;
        }
    }
    //? 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    //실제 스코어 저장할 곳 
    public int score = 0;



}


