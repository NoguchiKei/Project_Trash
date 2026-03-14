using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // プールで管理するオブジェクトのPrefab
    public GameObject prefab;

    // 最初に生成しておくオブジェクト数
    public int poolSize = 10;

    // 非アクティブ状態のオブジェクトを保存するキュー
    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        // 指定された数だけオブジェクトを生成してプールに入れる
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);

            // ★追加：武器にプールを教える
            obj.GetComponent<WeaponAttack>().SetPool(this);

            // 最初は非表示にしておく
            obj.SetActive(false);

            // プールに追加
            pool.Enqueue(obj);
        }
    }

    // プールからオブジェクトを取得
    public GameObject GetObject()
    {
        // プールにオブジェクトが残っている場合
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();

            obj.SetActive(true);

            return obj;
        }

        // プールが空の場合は新しく生成
        GameObject newObj = Instantiate(prefab);

        // ★追加：ここでもプール登録
        newObj.GetComponent<WeaponAttack>().SetPool(this);

        return newObj;
    }

    // 使用が終わったオブジェクトをプールに戻す
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);

        pool.Enqueue(obj);
    }
}