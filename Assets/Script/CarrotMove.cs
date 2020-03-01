using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 해야할거 이 코드 수정^^ TF_BadCarrot에 이 당근친구가 충돌하면 사라지게 하자 이 친구는 먹지말고 피하자 

public class CarrotMove : MonoBehaviour
{
    public float Speed = 5f; //당근 속도
    public float xMove = 0;

    // Update is called once per frame
    void Update()
    {
        xMove = 0;
      
        xMove = Speed * Time.deltaTime;

   
         this.transform.Translate(new Vector3(-xMove, 0, 0));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TF_Carrot_zone에 들어가면 사라지는게 좋겠어 

        if (collision.gameObject.tag.CompareTo("TF_Carrot_zone") == 0)
        {
            gameObject.SetActive(false);
        }
        //player랑 충돌하면 사라짐 + 중독? 효과를 이 코드에 넣는게 좋을까 ?
        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            gameObject.SetActive(false);
        }
      
    }
}
