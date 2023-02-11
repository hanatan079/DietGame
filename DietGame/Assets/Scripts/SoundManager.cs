using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //シングルトン
    public static SoundManager single;

    //BGM格納
    public AudioSource bgm;

    //AudioClip格納
    public AudioClip[] bgmClip;



    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //再生(1.スタートリザルド　2.プレイ中)
    public void PlayBGM(int x)
    {
        bgm.clip = bgmClip[x];
        bgm.Play();
    }
}
