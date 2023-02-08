using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    //スコア
    int score;

    //スコアtext
    [SerializeField]
    Text Textcore;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //スコアの表示
    void ScoreDisplay(int totalScore)
    {
        score += totalScore;
        Textcore.text = score.ToString();
    }
}
