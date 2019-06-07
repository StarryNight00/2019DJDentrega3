using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //OBJECT ARROW. STATES MOVEMENT AND CONTROLS COLIDER
    [Header ("Arrow")]

    [SerializeField] Collider2D collider;
    Rigidbody2D                 rigidBody;
    ShotControl                 shotCtrl;

    private float       speed = 400.0f;
    private float       timer;

    
    private Vector3     startPos;
    private Vector3     hVector;
    public Transform    hitPos;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        shotCtrl = GetComponent<ShotControl>();

        startPos = shotCtrl.transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 directionVel = rigidBody.velocity;
        hVector.y = startPos.y;
        timer += Time.fixedDeltaTime;

        transform.position = hVector * speed * directionVel;
    }

    private void Update()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.ClearLayerMask();
        contactFilter.SetLayerMask(LayerMask.GetMask("Enemy"));

        Collider2D[] results = new Collider2D[6];

        int nCollisions = Physics2D.OverlapCollider(collider, contactFilter, results);

        if (nCollisions > 0)
        {
            for (int i = 0; i < nCollisions; i++)
            {
                collider = results[i];

                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.GetNumb();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(hitPos.position, 2.0f);
    }

}
