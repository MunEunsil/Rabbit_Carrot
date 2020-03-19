using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class CarrotMove : MonoBehaviour
{
    public float Speed = 5f; //당근 속도
    public float xMove = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("BadCarrot");
        
        if (collision.gameObject.tag.CompareTo("player") == 0)
        {

            gameObject.SetActive(false);
            DataManager.Instance.score -= 5;

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
