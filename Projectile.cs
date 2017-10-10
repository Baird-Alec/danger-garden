using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    private Attacker atk;
    public float speed;
    public float damage;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker atk = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();
        if (atk && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
