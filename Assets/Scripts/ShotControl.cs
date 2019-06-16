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
    private float       speed = 400.0f;
    public float        cooldownTime = 2.5f;
    public GameObject   projectile;
    private Vector2     velocity;

    private float cooldown;

    void Start()
    {
        cooldown = 0.0f;
    }

    void FixedUpdate()
    {
        cooldown -= Time.fixedDeltaTime;
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
        Quaternion rotation = transform.rotation;
        GameObject arrow = Instantiate(projectile, transform.position, rotation);
        Rigidbody2D arrowRB = arrow.GetComponent<Rigidbody2D>();
        arrowRB.velocity = transform.rotation * Vector2.right * speed;

        cooldown = cooldownTime;
    }

}
