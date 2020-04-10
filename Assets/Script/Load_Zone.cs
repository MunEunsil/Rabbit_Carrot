using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Zone : MonoBehaviour
{
    public GameObject gamemanage;
    public GameObject Load_Map;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.playerDie == false)
        {

            if (collision.gameObject.tag.CompareTo("player") == 0)
            {

                //다음스테이지 로드 
                gamemanage.GetComponent<GameManage>().Next_Map();

                //로드맵 끄기 close 1초 뒤에 실행 
                Invoke("Close", 3.1f);

            }
        }
    }
    void Close()
    {
        Load_Map.SetActive(false);
    }

}
