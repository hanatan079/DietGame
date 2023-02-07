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
        StartCoroutine(GenerateFood(20));
    }

    void Update()
    {
        
    }


    //ボールの生成
    public IEnumerator GenerateFood(int count)
    {
        for(int i=0; i < count; i++)
        {
            Vector3 posY = new Vector3(Random.Range(-1.5f,1.5f),10f,-10f);
            food = Instantiate(foodPrefab, posY, Quaternion.identity);

            yield return new WaitForSeconds(0.4f);
        }
    }

}
