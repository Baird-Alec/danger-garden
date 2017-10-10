using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject collidedWith = collider.gameObject;
        if (!collidedWith.GetComponent<Defender>())
        {
            return;
            //Return nothing, Finish method
        }

        if (collidedWith.GetComponent<Stone>())
        {
            Debug.Log("JUMP");
            anim.SetTrigger("jumpTrigger");
        }

        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(collidedWith);
        }
    }
}
