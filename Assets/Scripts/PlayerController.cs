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
    public Transform shotSpawn;
    public SimpleTouchPad touchPad;
    public SimpleTouchAreaButton areaButton;
    public int weaponLv;
    public int skipValue;
    public float weaponRotation;
    public float weaponSpeed;

    private AudioSource audioSource;
    private float nextFire;
    private float delayFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        delayFire = Time.time + (fireRate * weaponSpeed);

    }

    private void Update()
    {
        if (areaButton.CanFire() && Time.time > nextFire)
        {
            Vector3 rotationVector;
            //Vector3 rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * weaponRotation);
            switch (weaponLv)
            {
                case 0:
                    nextFire = Time.time + (fireRate * weaponSpeed);
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    break;
                case 1:
                    nextFire = Time.time + (fireRate * weaponSpeed);
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * -weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    break;
                case 2:
                    nextFire = Time.time + (fireRate * weaponSpeed);
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * -weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 2 * weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 2 * -weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    break;
                case 3:
                    nextFire = Time.time + (fireRate * weaponSpeed);
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * -weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 3 * weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 3 * -weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    if (Time.time > delayFire)
                    {
                        delayFire = Time.time + (fireRate * weaponSpeed * skipValue);
                        rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 87);
                        Instantiate(shot, shotSpawn.position - new Vector3(0.0f, 0.0f, .15f), Quaternion.Euler(rotationVector));
                        rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * -87);
                        Instantiate(shot, shotSpawn.position - new Vector3(0.0f, 0.0f, .15f), Quaternion.Euler(rotationVector));
                       
                    }
                    break;
                case 4:
                    nextFire = Time.time + (fireRate * weaponSpeed);
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * -weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 5 * weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 5 * -weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 10 * weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 10 * -weaponRotation);
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(rotationVector));
                    if (Time.time > delayFire) {
                        delayFire = Time.time + (fireRate * weaponSpeed * skipValue);
                        rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 87);
                        Instantiate(shot, rb.position - new Vector3(0.0f, 0.0f, .15f), Quaternion.Euler(rotationVector));
                        rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * -87);
                        Instantiate(shot, rb.position - new Vector3(0.0f, 0.0f, .15f), Quaternion.Euler(rotationVector));
                        rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * 45);
                        Instantiate(shot, rb.position, Quaternion.Euler(rotationVector));
                        rotationVector = (new Vector3(0.0f, 1.0f, 0.0f) * -45);
                        Instantiate(shot, rb.position, Quaternion.Euler(rotationVector));
                    }
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
            // adjust boundary of movement here
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x * - tilt);
    }

}
