using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public Slider hpBar;
    public float maxHP =100f;
    public float minHP = 0f;
    public GameObject EndPanel;

    // Start is called before the first frame update
    void Start()
    {
        minHP = 1 / maxHP;
    }

    // Update is called once per frame
    void Update()
    {   // 시간에 따라 1씩 값 감소 
        //hpBar.value -= 1 * Time.deltaTime;
        //점수 띄우기 
        //100의 단위 
        //이 부분은 이미지 받으면 해보기로 

        if (!DataManager.Instance.playerDie) {
            hpBar.value -= 1 * Time.deltaTime;
            //시간 다 되면 죽음 
            if (DataManager.Instance.playerTimeCurrent < 0) {
                DataManager.Instance.playerDie = true;
            }

        }
        if (DataManager.Instance.playerDie == true) {
            EndPanel.SetActive(true);
        }


    }
    public void RestartButton() { //다시시작 버튼 
        DataManager.Instance.score = 0;
        DataManager.Instance.playerDie = false;
        DataManager.Instance.playerTimeCurrent = DataManager.Instance.playImeMax;

        SceneManager.LoadScene("Stage_0");
    }
}
