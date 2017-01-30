using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary 
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float fireRate;
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public GameObject shot1;
    public GameObject shot2;
    public GameObject shot3;
    public GameObject shot4;
    public Transform shotSpawn;
    public SimpleTouchPad touchPad;
    public SimpleTouchAreaButton areaButton;
    public int weaponLv;

    private Quaternion calibrationQuaternion;
    private AudioSource audioSource;
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
      //  weaponLv = 0;
    }

    private void Update()
    {
        if (areaButton.CanFire() && Time.time > nextFire)
        {
            switch (weaponLv)
            {
                case 0:
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    break;
                case 1:
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    Instantiate(shot, shotSpawn.position - new Vector3(0.0f, 0.0f, 2), shotSpawn.rotation);
                    break;
                case 2:
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    Instantiate(shot1, shotSpawn.position, shot1.transform.rotation);
                    Instantiate(shot2, shotSpawn.position, shot2.transform.rotation);
                    break;
                case 3:
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    Instantiate(shot1, shotSpawn.position, shot1.transform.rotation);
                    Instantiate(shot2, shotSpawn.position, shot2.transform.rotation);
                    Instantiate(shot3, shotSpawn.position, shot3.transform.rotation);
                    Instantiate(shot4, shotSpawn.position, shot4.transform.rotation);
                    break;

            }
            audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = touchPad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);
        rb.velocity = movement * speed;
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x * - tilt);
    }

}
