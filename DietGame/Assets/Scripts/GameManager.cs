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
    



    void Start()
    {
        //生成用コルーチン移動(40= count40回)
        StartCoroutine(foodGenerate.GenerateFood(40));

    }

    void Update()
    {
        
    }

    //マウスを検知
    void Mousedetection()
    {
        //押した時
        if(Input.GetMouseButtonDown(0))
        {

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
}
