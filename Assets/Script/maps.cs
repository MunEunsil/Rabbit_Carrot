using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maps : MonoBehaviour
{
    public GameObject ground;
    public GameObject ball;
    private int[] mapArray = { 1, 1, 1, 1 };
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            GameObject tempGround = Instantiate(ground, new Vector3(-6 + i * 2.5f, -2, -5), Quaternion.identity);
            tempGround.transform.parent = transform;
        }

        for (int i = 0; i < 4; i++)
        {
            GameObject tempGround = Instantiate(ground, new Vector3(3f + i*2, i*2, -5), Quaternion.identity);
            tempGround.transform.parent = transform;
        }
        GameObject tempball = Instantiate(ball, new Vector3(0, 0, -5), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
