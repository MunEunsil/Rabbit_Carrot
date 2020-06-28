using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float jump = 5f; //첫번째 점프 값 
    public float jump2 = 10f; //두번째 점프 값 
    public float Speed = 5f; //플레이어 달리기 속도 

    int jumpCount = 0;

    public GameObject coinAudio;

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


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

            
            SoundManager.Instance.PlaySound("Jump");
            if (jumpCount == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                // y축으로 속도 증가? 
               // 점프 애니메이션 
                animator.SetBool("Rabbit_Jump",true);
                jumpCount++;  //점프횟수 추가. 

            }
            else if (jumpCount == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                //jumpAudio.GetComponent<AudioSource>().Play();
               // animator.SetBool("Rabbit_Jump", true);
                jumpCount++;

            }
        }
      
     }

    //2개의 충돌체의 isTrigger가 꺼져 있으면 호출=>물리적 접촉시,
    private void OnCollisionEnter2D(Collision2D collision)
    {   //땅과 접촉하면 jumpCount 초기화 
        
        if (collision.gameObject.tag.CompareTo("Land") == 0) {
            jumpCount = 0;
            Debug.Log("land 접촉 ");
            animator.SetBool("Rabbit_Jump", false); 
        }


    }
    
    

}
