using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TotalScore : MonoBehaviour
{
    public Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameManager.GetScore();
        scoreText.text = string.Format("{0}cal", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //シーン読み込み
    public void RePlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

}
