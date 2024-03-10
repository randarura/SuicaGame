using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs; // 果物のプレハブの配列
    public Transform fruitSpawnPoint; // 果物の生成位置
    public float moveSpeed = 5f; // 果物の移動速度

    private GameObject currentFruit; // 現在の果物

    public int[] FruitsID = new int[10]; // 0から9までの数を保持する配列

    void Start()
    {
        // 果物ID
        for (int i = 0; i < FruitsID.Length; i++)
        {
            FruitsID[i] = 0;
        }

        // 最初の果物を生成
        SpawnNextFruit();

        Debug.Log(FruitsID.Length);

    }

    void Update()
    {
        if (currentFruit != null)
    {
        Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = false;
        }
        // マウスの位置に応じて移動
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = 4f; // y軸は固定

        // 移動範囲を制限
        float clampedX = Mathf.Clamp(mousePosition.x, -4f, 4f);
        mousePosition.x = clampedX;

        // 果物の移動
        if (currentFruit != null)
        {
            mousePosition.z = 0f; // z軸は固定
            currentFruit.transform.position = Vector3.Lerp(currentFruit.transform.position, mousePosition, Time.deltaTime * moveSpeed);
        }

        // クリックしたら果物を生成
        if (Input.GetMouseButtonDown(0))
        {
            rb.simulated = true;
            SpawnNextFruit();
        }
    }

    }

    // 次の果物を生成するメソッド
    void SpawnNextFruit()
    {
        // ランダムな果物を選択
        int randomIndex = Random.Range(0, fruitPrefabs.Length);
        Debug.Log(randomIndex);
        GameObject nextFruit = fruitPrefabs[randomIndex];

        // 果物のIDをインクリメント
        FruitsID[randomIndex]++;

        // 果物を生成
        currentFruit = Instantiate(nextFruit, fruitSpawnPoint.position, Quaternion.identity);

        // // currentFruitにアタッチされたFruitsIDスクリプトのIDにFruitsID[randomIndex]を代入
        FruitsID fruitsIDScript = currentFruit.GetComponent<FruitsID>();

        if (fruitsIDScript != null)
        {
            fruitsIDScript.ID = FruitsID[randomIndex];
        }
        else
        {
            Debug.LogError("FruitsIDスクリプトがアタッチされていません");
        }

    }
}
