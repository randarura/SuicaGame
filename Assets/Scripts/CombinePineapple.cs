using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinePineapple : FruitCollisionHandler
{
    // 衝突した際の処理
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other); // 親クラスの処理を実行
    }
}
