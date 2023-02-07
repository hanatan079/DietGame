using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //FoodGenerate.cs
    [SerializeField]
    FoodGenerate foodGenerate;


    void Start()
    {
        //生成用コルーチン移動(40= count40回)
        StartCoroutine(foodGenerate.GenerateFood(40));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
