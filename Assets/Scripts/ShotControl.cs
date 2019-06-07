using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ShotControl : MonoBehaviour
{
    //CONTROLS THE SHOT ABILITY. INSTATIATES THE ARROW

    Player              player;
    PlayerController    playerCtrl;
    Jacob               pJacob;

    private bool        arrowShot;

    public float        cooldownTime = 2.5f;
    public GameObject   projectile;
    //private Rigidbody2D rigidBody;
    private Vector3     pos;
    private Vector2     velocity;

    float cooldown;

    void Start()
    {  
        //pJacob = GetComponent<Jacob>();
        //pJacob.rigidBody.velocity = rigidBody.velocity;
        cooldown = 0.0f;
    }

    void FixedUpdate()
    {
        pos = transform.position;

        cooldown -= Time.fixedDeltaTime;
        if (player is Emma) return;
        if (cooldown < 0.0f)
        {
            arrowShot = Input.GetButton("Fire1");

            if (arrowShot)
            {
                Shot();
            }
        }
    }

    void Shot()
    {
        //Vector2 velocity = rigidBody.velocity;
        Quaternion rotation = transform.rotation;

        if (((velocity.x * transform.right.x) < 0.0f) && (velocity.x < 0.0f)) transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (((velocity.x * transform.right.x) < 0.0f) && (velocity.x > 0.0f)) transform.rotation = Quaternion.Euler(0, 0, 0);

        GameObject arrow = Instantiate(projectile, pos, rotation);
        cooldown = cooldownTime;
    }

}
