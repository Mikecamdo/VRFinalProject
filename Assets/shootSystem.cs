using UnityEngine;

public class shootSystem: MonoBehaviour
{
    public GameObject Revolver_Bullet;
    //public GameObject Revolver_Bullet;
    public Transform muzzlePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Revolver_Bullet, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = muzzlePoint.forward * bulletSpeed;
        }
        // You can add additional logic here such as bullet damage, effects, etc.
    }
}
