using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    



    void Start()
    {
        //生成用コルーチン移動(40= count40回)
        StartCoroutine(foodGenerate.GenerateFood(40));

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
        //押している時
        else if(dragging)
        {

        }
        //離した時
        else if(Input.GetMouseButtonUp(0))
        {

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
            Debug.Log("tuika");
            FoodID food = hit.collider.GetComponent<FoodID>();
            removeFoods.Add(food);

            dragging = true;
        }
    }

    //押している時の処理内容
    void NowDragging()
    {

    }

    //離した時の処理内容
    void EndDragging()
    {
        
    }

}
