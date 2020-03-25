﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float jump = 10f; //첫번째 점프 값 
    public float jump2 = 12f; //두번째 점프 값 
    public float Speed = 5f; //플레이어 달리기 속도 

    int jumpCount = 0;

 //   public GameObject coinAudio;
  //  public GameObject jumpAudio;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump_Btn();
        }
        
    }
    //마우스 좌클릭(스마트폰 터치)
    public void Jump_Btn() {
        if (!DataManager.Instance.playerDie) {
            if (jumpCount == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                // y축으로 속도 증가? 
                jumpAudio.GetComponent<AudioSource>().Play();
                jumpCount++;  //점프횟수 추가. 

            }
            else if (jumpCount == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                jumpAudio.GetComponent<AudioSource>().Play();
                jumpCount++;

            }
        }
      
     }

    //2개의 충돌체의 isTrigger가 꺼져 있으면 호출=>물리적 접촉시,
    private void OnCollisionEnter2D(Collision2D collision)
    {   //땅과 접촉하면 jumpCount 초기화 
    
        if (collision.gameObject.tag.CompareTo("Land") == 0) {
            jumpCount = 0; 
        }


    }
    
    
    //당근효과음을 위한것 
    //뭔가 더러워지기 시작한다 
  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag.CompareTo("Carrot") == 0)
        {
            coinAudio.GetComponent<AudioSource>().Play();


        }
    }
    */
}
