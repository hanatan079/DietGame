using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerate : MonoBehaviour
{
    //フードプレファブ用
    [SerializeField]
    private  GameObject foodPrefab;

    //複数ボール格納用
    [SerializeField]
    Sprite[] foodSprites;

    //新しい食べ物格納
    public GameObject food;


    void Start()
    {
        //StartCoroutine(GenerateFood(40));
    }

    void Update()
    {
        
    }


    //ボールの生成
    public IEnumerator GenerateFood(int count)
    {
        for(int i=0; i < count; i++)
        {
            //生成する場所指定
            Vector3 posY = new Vector3(Random.Range(-1.5f,1.5f),10f,-10f);
            food = Instantiate(foodPrefab, posY, Quaternion.identity);

            //親オブジェクトを変更する
            food.transform.SetParent(transform);


            RandomFoods();
            
            yield return new WaitForSeconds(0.2f);
        }
    }

    //ランダムな食べ物を取得する
    public void RandomFoods()
    {
        int foodID = Random.Range(0,foodSprites.Length);
        food.GetComponent<SpriteRenderer>().sprite = foodSprites[foodID];

        //ID取得(foodID.cs)
        food.GetComponent<FoodID>().id = foodID;
    }
}
