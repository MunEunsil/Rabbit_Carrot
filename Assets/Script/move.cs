using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    int MAX_X = 6;
    float VECLOCITY_X = 2f;
    float VECLOCITY_Y = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        Rigidbody2D curRigid = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            curRigid.velocity = new Vector3(-VECLOCITY_X, curRigid.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            curRigid.velocity = new Vector3(VECLOCITY_X, curRigid.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.Space) && curRigid.velocity.y == 0)
        {
            curRigid.velocity = new Vector3(curRigid.velocity.x, VECLOCITY_Y, 0);
        }
    }
}
