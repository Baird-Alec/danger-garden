using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float healthPoints = 100;

    public void DealDamage(float damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            DestroyTarget();
        }
    }
    public void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
