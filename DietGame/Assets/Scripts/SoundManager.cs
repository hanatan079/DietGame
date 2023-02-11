using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //シングルトン
    public static SoundManager single;

    //BGM格納
    public AudioSource audioSource;

    //AudioClip格納
    public AudioClip[] bgmClip;



    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(BGM.Start);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //何のBGMか
    public enum BGM
    {
        Start,
        Main,
        Total
    }


    //再生(1.スタートリザルド　2.プレイ中)
    public void PlayBGM(BGM bgm)
    {
        audioSource.clip = bgmClip[(int)bgm];
        audioSource.Play();
    }
}
