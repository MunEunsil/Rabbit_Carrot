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

    
    private GameObject rabbit;
    public GameObject scoreStar1, scoreStar2, scoreStar3;
    
    public GameObject gomapbutton;
    public GameObject gamecontinue;

    //점수 이미지 
    public GameObject[] NumberImage;
    public Sprite[] Number;
    public GameObject[] EndPanelNumberImg;
    public int NextStageNum;

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
        rabbit = GameObject.FindGameObjectWithTag("player");

        //  gomapbutton = GameObject.FindGameObjectWithTag("GoMapButton");
        //  gamecontinue = GameObject.FindGameObjectWithTag("GameContinueButton");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //점수 띄우기 
        //100의 단위 
        int temp = DataManager.Instance.score / 100;
        NumberImage[0].GetComponent<Image>().sprite = Number[temp];
        //10의 단위 0~99까지 계산 
        int temp2 = DataManager.Instance.score % 100;
        //이걸 다시 0~9까지 
        temp2 = temp2 / 10;
        NumberImage[1].GetComponent<Image>().sprite = Number[temp2];
        //1의 단위 
        int temp3 = DataManager.Instance.score % 10;
        NumberImage[2].GetComponent<Image>().sprite = Number[temp3];
            
  
        //플레이어가 살아있는동안 
        if (!DataManager.Instance.playerDie) {
            rabbit.GetComponent<Animator>().SetBool("Rabbit_Run_State", true);
            //DataManager.Instance.Rabbit_animator.SetBool("Rabbit_Run_State",true);

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
                SoundManager.Instance.StopSound("BG");
                DataManager.Instance.playerDie = true;
            }
            //아이템 효과 
            if (DataManager.Instance.EatBadHeart == true)
            {
                DataManager.Instance.EatBadHeart = false;
                StartCoroutine(BadHeartEffect());
            }


        }
        //코루틴~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

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

            //게임오버or게임클리어 => 애니메이션 멈춤
            rabbit.GetComponent<Animator>().SetBool("Rabbit_Run_State", false);

            //점수표시하기
            EndPanelNumberImg[0].GetComponent<Image>().sprite = Number[temp];
            EndPanelNumberImg[1].GetComponent<Image>().sprite = Number[temp2];
            EndPanelNumberImg[2].GetComponent<Image>().sprite = Number[temp3];

            scoreStar1.SetActive(false);
            scoreStar2.SetActive(false);
            scoreStar3.SetActive(false);

            //endpenel 띄우기
            if (DataManager.Instance.stageClear ==false)
            {
                gomapbutton.SetActive(true); // 맵으로 돌아가기 버튼 true
                EndPanel.SetActive(true);

                if (DataManager.Instance.score >= 79)
                {
                    scoreStar1.SetActive(true);
                    scoreStar2.SetActive(true);
                    scoreStar3.SetActive(true);
                }
                else if (DataManager.Instance.score > 20)
                {
                    scoreStar1.SetActive(true);
                    scoreStar2.SetActive(true);
                }
                else if (DataManager.Instance.score <= 20)
                {
                    scoreStar1.SetActive(true);
                }


            }
            else if(DataManager.Instance.stageClear == true) //위와 다른건 버튼 뿐 
            {
                gamecontinue.SetActive(true);
                EndPanel.SetActive(true);

                if (DataManager.Instance.score >79)
                {
                    scoreStar1.SetActive(true);
                    scoreStar2.SetActive(true);
                    scoreStar3.SetActive(true);
                }
                else if ( DataManager.Instance.score > 20 )
                {
                    scoreStar1.SetActive(true);
                    scoreStar2.SetActive(true);
                }
                else if (DataManager.Instance.score <= 20)
                {
                    scoreStar1.SetActive(true);
                }
            }
            
        }

    }
    public void RestartButton() { //다시시작 버튼 
        DataManager.Instance.score = 0;
        DataManager.Instance.map = 0;
        DataManager.Instance.mapView = 0;
        DataManager.Instance.playerDie = false;
        DataManager.Instance.playerTimeCurrent = DataManager.Instance.playImeMax;

        //DataManager.Instance.Rabbit_animator = GetComponent<Animator>();

        SoundManager.Instance.PlaySound("BG");
        
        // STAGE2 부분에 현 스테이지가 들어가야함!
        SceneManager.LoadScene(
            StageManager.Instance.GetCurrentStage());
    }
    public void GoMapButton()
    { //맵으로 돌아가는 버튼

        SceneManager.LoadScene("InGame");
    }
    
    public void GameCountinue()
    {
        SceneManager.LoadScene(NextStageNum);
    }

}
