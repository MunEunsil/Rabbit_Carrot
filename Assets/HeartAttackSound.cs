using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAttackSound : MonoBehaviour
{
    public AudioClip soundExplosion;
    AudioSource myAudio;
    public static HeartAttackSound instance;

    private void Awake()
    {
        if (HeartAttackSound.instance == null)
            HeartAttackSound.instance = this;
    }
    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundExplosion); 
        //myAudio의 playOneshot 함수를쓰면 사운드 재생됨 
    }

}
