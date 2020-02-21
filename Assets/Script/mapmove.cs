using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapmove : MonoBehaviour
{
    public float mapSpeed = 10f;

    private void Update()
    {
        if (!DataManager.Instance.playerDie) { //player 가 death면 멈춤
            //맵 스피트 만큼 -x 축으로 이동 
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }
     
    }
}
