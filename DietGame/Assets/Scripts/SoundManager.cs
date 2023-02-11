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


    //singleをからにする
    private void Awake()
    {
        if(single == null)
        {
            single = this;
        }
        else if(single != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    //何のBGMか
    public enum BGM
    {
        Start,
        Main,
    }


    //再生(1.スタートリザルド　2.プレイ中)
    public void PlayBGM(BGM bgm)
    {
        audioSource.clip = bgmClip[(int)bgm];
        audioSource.Play();
    }
}
