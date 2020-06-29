using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        
    }
    private void Update()
    {
        Vector3 playerPos = player.transform.position;

        transform.position = new Vector3(playerPos.x+3.78f, transform.position.y, transform.position.z); 

    }

}
