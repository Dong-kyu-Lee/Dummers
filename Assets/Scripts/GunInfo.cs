using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Gun")]
public class GunInfo : ScriptableObject
{
    public int gunName;
    public float damage;
    public float attackSpeed;
    public float attackRange;
    public int bulletNum;
    public GameObject gunObject;
}
