using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class typingEffect : MonoBehaviour
{
    public Text tx;

    public string[] m_text; //txt 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(typing());
    }

    IEnumerator typing()
    {
        yield return new WaitForSeconds(1f);
        for (int j=0; j<m_text.Length; j++)
        {
            for (int i = 0; i <= m_text[j].Length; i++) //글자길이만큼 for문
            {
                tx.text = m_text[j].Substring(0, i);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
