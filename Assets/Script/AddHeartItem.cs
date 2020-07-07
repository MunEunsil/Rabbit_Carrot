using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//체력 추가해주는 아이템 

public class AddHeartItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.Instance.playerDie) {

            if (collision.gameObject.tag.CompareTo("player") == 0) {
                Debug.Log("하트 닿았어?");
                //시간추가 
                DataManager.Instance.playerTimeCurrent += 3f;
                //시간이 max 보다 커지면 max로 변환 
                if (DataManager.Instance.playerTimeCurrent > DataManager.Instance.playImeMax) {
                    DataManager.Instance.playerTimeCurrent = DataManager.Instance.playImeMax;
                }

                //닿으면 이미지 끄기 
                gameObject.SetActive(false);
            }

        }
        
    }
}
