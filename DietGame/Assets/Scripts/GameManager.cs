using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //FoodGenerate.cs
    [SerializeField]
    FoodGenerate foodGenerate;

    //押している時引数
    [SerializeField]
    bool dragging;

    //リスト
    [SerializeField]
    List<FoodID> removeFoods = new List<FoodID>();

    //現在触っている食べ物か
    FoodID nowDraggingFood;

    //初期スコア
    public static int score;

    //スコアtext
    [SerializeField]
    Text scoreText;

    //
    [SerializeField]
    Text lastScore;

    //タイマー格納用
    [SerializeField]
    Text timerText;

    //タイマーカウント用
    [SerializeField]
    int timerCount;

    //リザルド
    [SerializeField]
    GameObject scorePanel;

    int OutFoods;




    void Awake()
    {
        //生成用コルーチン移動(40= count40回)
        StartCoroutine(foodGenerate.GenerateFood(60));
    }

    void Start()
    {
        score = 0;
        AddScore(0);

        timerCount = 30;

        StartCoroutine(CountDown());
    }

    void Update()
    {

        Mousedetection();
    }



    //マウスを検知
    void Mousedetection()
    {
        //押した時
        if(Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }
        //離した時
        else if(Input.GetMouseButtonUp(0))
        {
            EndDragging();
        }

        //押している時
        else if(dragging)
        {
            NowDragging();
        }
    }

    //押した時の処理内容
    void StartDrag()
    {
        //Rayを飛ばす
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        //Rayがボールにヒットしたら
        if(hit && hit.collider.GetComponent<FoodID>())
        {
            //removeFoods(リスト)へ追加
            FoodID food = hit.collider.GetComponent<FoodID>();

            //removeFoods.Add(food);
            NotList(food);

            dragging = true;
        }
    }

    //押している時の処理内容
    void NowDragging()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if(hit && hit.collider.GetComponent<FoodID>())
        {
            FoodID food = hit.collider.GetComponent<FoodID>();

        //触っている種類が同じで距離が近かったら
        if(food.id == nowDraggingFood.id)
            {
                float shortDistance = Vector2.Distance(food.transform.position,nowDraggingFood.transform.position);
                if(shortDistance < 2.0)
                {
                    //リストへ追加
                    NotList(food);
                }
            }
        }
    }

    //離した時の処理内容
    void EndDragging()
    {
        OutFoods = removeFoods.Count;

        //3つ以上続けて触っていたら消去
        if(OutFoods >= 3)
        {
            for(int i = 0; i < OutFoods; i++)
            {
                Destroy(removeFoods[i].gameObject);
            }
                //スコア加算
                ScorePlus();

            //消した数分新たに追加
            StartCoroutine(foodGenerate.GenerateFood(OutFoods));
        }

        //リスト要素全消去
        removeFoods.Clear();

        //離したら効果きれる
        dragging = false;

    }


    //リストにない場合のみ追加する(既にある場合はスルー)
    void NotList(FoodID food)
    {
        //リストのボールは現在触っている食べ物か
        nowDraggingFood = food;

        if(removeFoods.Contains(food) == false)
        {
            removeFoods.Add(food);
        }
    }

    //スコア用
    void AddScore(int scorecount)
    {
        score += scorecount;
        scoreText.text = score.ToString();
    }

    //タイマー
    IEnumerator CountDown()
    {
        //0秒まで繰り返す
        while(timerCount > 0)
        {
            yield return new WaitForSeconds(1);
            timerCount --;

            //時間表示
            timerText.text = timerCount.ToString();
        }
            //パネルの表示
        SceneManager.LoadScene("TotalScore");
    }

    //スコア加算
    void ScorePlus()
    {
        AddScore(OutFoods * 100);
    }

    //スコア共有
    public static int GetScore()
    {
        return score;
    }

}
