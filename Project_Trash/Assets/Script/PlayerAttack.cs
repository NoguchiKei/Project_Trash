using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    // 武器オブジェクトを管理するオブジェクトプール
    public ObjectPool weaponPool;

    // 武器を出現させる位置（プレイヤーの手元など）
    public Transform attackPoint;

    // 次の攻撃ができるまでの待ち時間
    public float attackCooldown = 0.3f;

    // クールタイム計測用タイマー
    private float attackTimer = 0f;

    void Update()
    {
        // 毎フレーム時間を加算
        attackTimer += Time.deltaTime;

        // Aキーが押されて、かつクールタイムが終了していたら攻撃
        if (Input.GetKeyDown(KeyCode.A) && attackTimer >= attackCooldown)
        {
            Attack();

            // タイマーをリセット
            attackTimer = 0f;
        }
    }

    void Attack()
    {
        // プールから武器オブジェクトを取得（生成ではなく再利用）
        GameObject weapon = weaponPool.GetObject();

        // 武器を攻撃位置に配置
        weapon.transform.position = attackPoint.position;

        // 武器の向きを攻撃位置の回転に合わせる
        weapon.transform.rotation = attackPoint.rotation;
    }
}
