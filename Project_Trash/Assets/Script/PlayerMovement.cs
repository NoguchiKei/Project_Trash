using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // プレイヤーの物理挙動を制御する Rigidbody
    private Rigidbody2D rb;

    // プレイヤーのスプライト表示を管理
    private SpriteRenderer spriteRenderer;

    // プレイヤーの移動速度
    [SerializeField,Header("移動速度")]
    private float speed;

    // 入力された移動方向を保存
    private Vector2 moveInput;

    void Start()
    {
        // 同じオブジェクトについている Rigidbody2D を取得
        rb = GetComponent<Rigidbody2D>();

        // 同じオブジェクトについている SpriteRenderer を取得
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // キーボードの左右入力を取得（A,Dキー / ←→）
        float dx = Input.GetAxis("Horizontal");

        // キーボードの上下入力を取得（W,Sキー / ↑↓）
        float dy = Input.GetAxis("Vertical");

        // 入力方向をベクトルとして保存（normalizedで斜め移動の速度を一定にする）
        moveInput = new Vector2(dx, dy).normalized;

        // 移動方向に応じてキャラクターの向きを変更
        if (dx > 0)
            spriteRenderer.flipX = true;   // 右向き
        else if (dx < 0)
            spriteRenderer.flipX = false;  // 左向き
    }

    void FixedUpdate()
    {
        // Rigidbody を使ってプレイヤーを移動させる（物理更新タイミング）
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}