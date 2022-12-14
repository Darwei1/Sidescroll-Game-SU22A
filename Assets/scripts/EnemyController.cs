using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Variables")]
    public float enemyHealth = 100f;
    public float enemySpeed = 10;
    public float enemyDamage = Random.Range(2, 9);

    public void Awake()
    {
        


    }
}
