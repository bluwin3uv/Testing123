using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charater : MonoBehaviour
{
    [Header("Character")]
    public float hp = 1f;
    public float damage = 10f;
    public float speed = 20f;

    protected bool CheckDeath()
    {
        return hp <= 0;
    }	
}
