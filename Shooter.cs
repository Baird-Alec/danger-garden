using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject gun;
    private GameObject projectileParent;
    private Animator anim;
    private Spawner myLaneSpawner;

    private void Start()
    {
        anim = GameObject.FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        //Creates parent if necessary
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        
        SetMyLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerAhead())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    bool IsAttackerAhead()
    {
        if(myLaneSpawner.transform.childCount == 0)
            {
            return false;
            }
        //Are attackers ahead in lane
        foreach(Transform attackers in myLaneSpawner.transform)
        {
            if (attackers.transform.position.x > transform.position.x)
            {
                //Attacker is ahead
                return true;
            }
        }
        return false;
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(projectile) as GameObject;
        bullet.transform.parent = projectileParent.transform;
        bullet.transform.position = gun.transform.position;
    }

    private void SetMyLaneSpawner ()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }

        }
        Debug.LogError("Can't find spawner in lane");
    }
}
