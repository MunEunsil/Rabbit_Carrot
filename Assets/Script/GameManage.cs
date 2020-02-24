using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public Image HeartBar;
    public float maxHP =100f;
    public float minHP = 0f;
    public GameObject EndPanel;

    //맵 배열로 보관 
    public GameObject[] NextMap;

    public GameObject LoadMap;

    public void Load_Map() {
        LoadMap.transform.position = new Vector3(15f, LoadMap.transform.position.y, LoadMap.transform.position.z);
        LoadMap.SetActive(true);
    }

    //맵을 한 단계 올리고 선택하는 함수 
    public void Next_Map() {
        //맵을 올리고 

        DataManager.Instance.map += 1;
        DataManager.Instance.mapView += 1;

        //만든 맵을 1~3까지만 유지하게 하기 

        if (DataManager.Instance.map > NextMap.Length) {

            DataManager.Instance.map = DataManager.Instance.map % NextMap.Length;
            if (DataManager.Instance.map==0) {
                DataManager.Instance.map = NextMap.Length;
            }
                
        }
        MapStart();

    }
    //지금 켜야할 맵을 키고 나머지는 끄기 
    public void MapStart() {
        for (int temp = 1; temp <= NextMap.Length; temp++) {

            if (temp == DataManager.Instance.map) {

                //오른쪽에서 왼쪽으로 이동한 맵을 다시 자리잡게 
                NextMap[temp - 1].transform.position = new Vector3(281.8f,152,0);

                // 로드하기 
                NextMap[temp - 1].SetActive(true);
            }
            else {
                NextMap[temp - 1].SetActive(false);
            }
        }
    } 

    void Start()
    {
        minHP = 1 / maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //점수 띄우기 
        //100의 단위 
        int temp = DataManager.Instance.score / 100;
        //점수판 이미지가 없으니 받으면 이부분 하기 
        //10의 단위 0~99까지 계산 
        int temp2 = DataManager.Instance.score % 100;
        //이걸 다시 0~9까지 
        int temp3 = DataManager.Instance.score % 10;


  
        //시간 끝나면 쥬금 
        if (!DataManager.Instance.playerDie) {

            DataManager.Instance.playerTimeCurrent -= 1 * Time.deltaTime; //1초에 1씩 빼기  

            //heartbar 값 빼기 
            HeartBar.fillAmount = DataManager.Instance.playerTimeCurrent / DataManager.Instance.playImeMax;
          
            //시간 다 되면 죽음 
            if (DataManager.Instance.playerTimeCurrent < 0) {
                DataManager.Instance.playerDie = true;
            }

        }
        if (DataManager.Instance.playerDie == true) {
            //배경끄기
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
