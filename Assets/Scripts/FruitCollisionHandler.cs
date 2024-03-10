using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollisionHandler : MonoBehaviour
{
    public GameObject fruitPrefabs;

    // 衝突した際の処理
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == collision.gameObject.name)
        {
            // currentFruitにアタッチされたFruitsIDスクリプトのIDにFruitsID[randomIndex]を代入
            FruitsID fruitsIDScript = gameObject.GetComponent<FruitsID>();
            FruitsID otherfruitsIDScript = collision.gameObject.GetComponent<FruitsID>();
            Debug.Log("フルーツの"+fruitsIDScript.ID);
            Debug.Log("他フルーツの"+fruitsIDScript.ID);
            if ( fruitsIDScript.ID > otherfruitsIDScript.ID ) {

                // 果物を破棄
                Destroy(gameObject);
                
                // 果物に変更
                GameObject newFruit = Instantiate(fruitPrefabs, transform.position, Quaternion.identity);

            }else{
                // 果物を破棄
                Destroy(gameObject);                
            }


        }
    }
}
