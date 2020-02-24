using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZone : MonoBehaviour
{
    public GameObject gamemanage;

    private void Awake()
    {
        gamemanage = GameObject.FindGameObjectWithTag("GameManage");
    }

    //충돌처리 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.playerDie==false) {
            if (collision.gameObject.tag.CompareTo("player")==0) {
                gamemanage.GetComponent<GameManage>().Load_Map();
                print(" clearzone ");
            }
        }
    }
    //죽지않은 플레이어가 clearzone에 충돌하면 loadmap을 부르는 함수를 실행

}
