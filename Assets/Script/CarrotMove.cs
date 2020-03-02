using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 외계당근이 사라져야한다 사라져야한다 진ㅉ ㅏ진짜 사라져야한다 사라지게 해보자 아니 해주라 



public class CarrotMove : MonoBehaviour
{
    public float Speed = 5f; //당근 속도
    public float xMove = 0;


    //충돌처리 
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //TF_Carrot_zone에 들어가면 사라지는게 좋겠어 

        if (collision.gameObject.tag.CompareTo("TF_Carrot_zone") == 0)
        {
            print("이거랑은 충돌함?");
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            gameObject.SetActive(false);

            print("공이랑 만났다 만났어 만났다니까");
        }
        //player랑 충돌하면 사라짐 + 중독? 효과를 이 코드에 넣는게 좋을까 ? 
        //왜! 안! 사!라! 지! 냐! 얼척없네 사라지라 했자낭나ㅏ아랄아ㅣㄹ어ㅏㄹㅇㅁㄹㅇㄴㅁ
        //사라져라머리머..아니 사라져라 당근당근 아니 왜 안사라지는데 
        //원하는 코드 줬으면 사라져야지 
        //내가 뭘 더 해주길원하는데 말을 해 말을해야알지 알려나주고 이러라고 
        //충돌은 전혀 못하네? 뭐가 문제일까? 왜 아무거랑도 충돌을 안하는걸까
        //z축 문제도 아니면 뭐가 문제일까 음...훔....후으으으으음...왜
    }
    */
    // Update is called once per frame
    void Update()
    {
        xMove = 0;

        xMove = Speed * Time.deltaTime;


        this.transform.Translate(new Vector3(-xMove, 0, 0));

    }

}
