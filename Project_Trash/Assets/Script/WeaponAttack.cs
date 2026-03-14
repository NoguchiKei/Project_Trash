using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class WeaponAttack : MonoBehaviour
//{
//    //武器が存在する時間
//    public float lifeTime = 0.3f;

//    //武器の回転速度
//    public float rotateSpeed = 720f;

//    float timer;

//    // この武器を管理するオブジェクトプール
//    ObjectPool pool;

//    // プールを登録
//    public void SetPool(ObjectPool objectPool)
//    {
//        pool = objectPool;
//    }

//    void OnEnable()
//    {
//        // タイマーリセット
//        timer = 0;

//        // 初期角度（構え）
//        transform.localRotation = Quaternion.Euler(0, 0, 90);
//    }

//    void Update()
//    {
//        // 時間計測
//        timer += Time.deltaTime;

//        // 武器を回転させて振る
//        transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);

//        // 攻撃時間が終わったらプールに戻す
//        if (timer >= lifeTime)
//        {
//            pool.ReturnObject(gameObject);
//        }
//    }
//}

public class WeaponAttack : MonoBehaviour
{
    // 攻撃にかかる時間
    public float swingTime = 0.25f;

    // 武器の開始角度（上）
    public float startAngle = 60f;

    // 武器の終了角度（下）
    public float endAngle = -60f;

    // 攻撃タイマー
    float timer;

    // この武器を管理するプール
    ObjectPool pool;

    // プールを登録
    public void SetPool(ObjectPool objectPool)
    {
        pool = objectPool;
    }

    void OnEnable()
    {
        // 攻撃開始時タイマーリセット
        timer = 0;

        // 初期角度（構え）
        transform.localRotation =
            Quaternion.Euler(0, 0, startAngle);
    }

    void Update()
    {
        // 時間を進める
        timer += Time.deltaTime;

        // 0～1に正規化
        float t = timer / swingTime;

        // 半円スイング
        float angle = Mathf.Lerp(startAngle, endAngle, t);

        transform.localRotation =
            Quaternion.Euler(0, 0, angle);

      
        // 攻撃終了
        if (timer >= swingTime)
        {
            pool.ReturnObject(gameObject);
        }
    }
}