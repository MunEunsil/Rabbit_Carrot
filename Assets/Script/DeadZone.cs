using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //충돌처리 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.Instance.playerDie) { //player가 true 

            if (collision.gameObject.tag.CompareTo("player") == 0 || collision.gameObject.tag.CompareTo("BadCarrotPlayer") == 0) {
                SoundManager.Instance.StopSound("BG");
                DataManager.Instance.playerDie = true;  //player랑 충돌하면 playerDie를 true
                print("player death");
            }
            
        }
    }

}
