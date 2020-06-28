using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class CarrotMove : MonoBehaviour
{
    public float Speed = 5f; //당근 속도
    public float xMove = 0;

    private GameObject Carrot;
    Animator animator;
    //당근 애니메이션 
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
          Carrot = GameObject.FindGameObjectWithTag("BadCarrot");
          //Carrot.GetComponent<Animator>().SetBool("Rabbit_Run_State", true);
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("BadCarrot");
        
        if (collision.gameObject.tag.CompareTo("player") == 0)
        {

            gameObject.SetActive(false);
            DataManager.Instance.playerDie = true;
            //DataManager.Instance.score -= 5;

        }

    }

    // Update is called once per frame
    void Update()
    {
        xMove = 0;

        xMove = Speed * Time.deltaTime;


        this.transform.Translate(new Vector3(-xMove, 0, 0));

    }

}
