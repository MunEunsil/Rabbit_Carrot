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
    public GameObject stageClear;
    public GameObject RedPanel;
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


  
        //플레이어가 살아있는동안 
        if (!DataManager.Instance.playerDie) {
            //시간 줄이기 
            DataManager.Instance.playerTimeCurrent -= 1 * Time.deltaTime;   

            //heartbar 값 빼기 
            HeartBar.fillAmount = DataManager.Instance.playerTimeCurrent / DataManager.Instance.playImeMax;
          
            //시간 다 되면 죽음 
            if (DataManager.Instance.playerTimeCurrent < 0) {
                DataManager.Instance.playerDie = true;
            }
            //클리어 하면 죽음으로 표시해서 모두 멈추기 
            if (DataManager.Instance.stageClear == true)
            {
                DataManager.Instance.playerDie = true;
            }
            //아이템 효과 
            if (DataManager.Instance.EatBadHeart == true)
            {
                StartCoroutine(BadHeartEffect());
            }


        }
        //코루틴~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 종료했음에도 꺼졌다 켜졌다 난리다...! 
        // 좀 무섭게 깜빡인다.....! waitForSeconds무시하는것같다...! 또 의문 중첩가능한것인가?
        IEnumerator BadHeartEffect()
        {
            print("코루틴 실행");
            int count = 0;
          
            while (count <5)
            {
                count += 1;

                RedPanel.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                RedPanel.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                
                Debug.Log(count);

                if (DataManager.Instance.playerDie == true) {
                    break;
                }
            }
            RedPanel.SetActive(false);
            DataManager.Instance.EatBadHeart = false;

           
            print("하트 코루틴 종료");
            
        }
        //코루틴 끝날 때 DataManager.Instance.EatDHeart = false 하기~


        //조건 추가 MapClear가 Fale이면 앤드패널 True이면 clearPanel 
        //MapClearZone과 충도하면 MapClear True로 바꾸고 playerDie true로 바꾸기 

        if (DataManager.Instance.playerDie == true) {

            //endpenel 띄우기
            if (DataManager.Instance.stageClear ==false)
            {
                EndPanel.SetActive(true);

            }
            else if(DataManager.Instance.stageClear == true) //cle ar panel 띄우기 
            {
                stageClear.SetActive(true);
            }
            
        }
           

    }
    public void RestartButton() { //다시시작 버튼 
        DataManager.Instance.score = 0;
        DataManager.Instance.map = 0;
        DataManager.Instance.mapView = 0;
        DataManager.Instance.playerDie = false;
        DataManager.Instance.playerTimeCurrent = DataManager.Instance.playImeMax;
        //소리 어떻게 해결하지?

        

        SceneManager.LoadScene("Stage_0");
    }
    public void GoMapButton()
    { //맵으로 돌아가는 버튼
        SceneManager.LoadScene("InGame");
    }
}
