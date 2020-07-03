using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_Stage7 : MonoBehaviour
{
    public GameObject rabbit;  //player
    private int carrot_score;
    public GameObject deadzone; //데드존
    private bool cobool=false;

    private void Update()
    {
        carrot_score = DataManager.Instance.score;
        if (carrot_score==10)
        {
            //토끼 커지는 코드 
            rabbit.transform.localScale = new Vector3(0.1909576f, 0.1838609f, 1f);
            // 뭔가 또로롱 하는 효과음이 있으면 어떨까? 
            Debug.Log(rabbit.transform.localScale);
        }
        else if (carrot_score > 26)
        {
            rabbit.GetComponent<Animator>().SetBool("Rabbit_Run_State", false);
            rabbit.transform.localScale = new Vector3(0.3f, 0.3f, 1f);

            deadzone.SetActive(false); //데드존 없애고
            rabbit.GetComponent<BoxCollider2D>().isTrigger = true; //아래로 떨어지게
            if (cobool == false) { 
                StartCoroutine(WaitSeconds());
            }
            
            //2초정도 있다가 게임 클리어 화면 띄우고 싶음 
           


        }
    }
    IEnumerator WaitSeconds()
    {
        print("코루틴 실행");
        yield return new WaitForSeconds(0.8f);
        cobool = true;
        print("코루틴 종료");
        StageClear();

    }
    void StageClear()
    {
        DataManager.Instance.stageClear = true;
        DataManager.Instance.playerDie = true;
    }

}
