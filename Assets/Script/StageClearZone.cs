using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("BadCarrot");

        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            DataManager.Instance.stageClear = true;
            DataManager.Instance.playerDie = true;
        }

    }
}
