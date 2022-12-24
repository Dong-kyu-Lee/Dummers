using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public abstract void Attack();
}

public class Gun : Weapon
{
    [SerializeField] GunInfo gunInfo;
    
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}