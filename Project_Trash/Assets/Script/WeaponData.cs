using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("武器名")]
    public string weaponName;

    [Header("ダメージ")]
    public int damage;
    [Header("耐久値")]
    public int durability;
    [Header("攻撃速度")]
    public float attackSpeed;

    [Header("プレハブ")]
    public GameObject weaponPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
