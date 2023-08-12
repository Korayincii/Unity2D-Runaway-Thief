using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public Transform rangeAttackPosition;


    public void RangedAttack()
    {
        Instantiate(bullet, rangeAttackPosition.position, Quaternion.identity);
    }
}
