using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadZone : MonoBehaviour
{
    public GameObject gamemanager;
    public GameObject LoadMap;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.playerDie == false) {
         
            if (collision.gameObject.tag.CompareTo("player") == 0) {

                //다음스테이지 로드 
                gamemanager.GetComponent<GameManage>().Next_Map();

                //로드맵 끄기 close 1초 뒤에 실행 
                
                Invoke("Close", 1.5f);

            }
        }
    }
    void Close() {

        LoadMap.SetActive(false);
    }

}
