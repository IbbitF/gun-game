using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject bullet;
    public float velocity = 120f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.linearVelocity = transform.forward * velocity;
        }
    }

}
