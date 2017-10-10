using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    public float spawnEverySeconds;
    private GameObject currentTarget;
    private Health health;
    private Animator anim;
    private GameObject parent;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
	}

    public void SetSpeed (float speed)
    {
        currentSpeed = speed;
    }

    //Called from animator to do damage
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            health = currentTarget.GetComponent<Health>();

            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    //Sets transition to Attacking
    public void Attack(GameObject def)
    {
        currentTarget = def;
    }
}
