using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    // 武器のデータ（ScriptableObject）を参照
    public WeaponData data;

    // 現在の耐久値
    protected int currentDurability;

    protected virtual void Start()
    {
        // 武器生成時に、データに設定されている耐久値を現在耐久値として設定
        currentDurability = data.durability;
    }

    public virtual void Attack()
    {
        // 攻撃するたびに耐久値を1減らす
        currentDurability--;

        // 耐久値が0以下になったら武器を壊す
        if (currentDurability <= 0)
        {
            BreakWeapon();
        }
    }

    // 武器が壊れたときの処理
    void BreakWeapon()
    {
        // コンソールにログを表示
        Debug.Log("武器が壊れた");

        // 武器オブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}
