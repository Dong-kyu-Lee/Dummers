using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int hp;
    public int HP { get => hp; set => hp = value; }
    [SerializeField] private float sp;
    public float SP { get => sp; set => sp = value; }
    public Weapon currentWaepon;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
