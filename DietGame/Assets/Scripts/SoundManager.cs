using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //シングルトン
    public static SoundManager single;

    //BGM格納
    public AudioSource bgmSource;
    //AudioClip格納
    public AudioClip[] bgmClip;

    //SS格納
    public AudioSource SESource;
    public AudioClip[] SEClip;


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
        bgmSource.clip = bgmClip[(int)bgm];
        bgmSource.Play();
    }


    //SE
    public enum SE
    {
        Tap,
        Destroy,
    }

    //再生(1.触った時2.消える時)
    public void PlaySE(SE se)
    {
        SESource.PlayOneShot(SEClip[(int)se]);
    }

    //SE停止
    public void StopSE(SE se)
    {
        SESource.PlayOneShot(SEClip[(int)se]);
        SESource.Stop();
    }




}
