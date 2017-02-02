using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    
    public float speed;
    private Rigidbody rb;
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
	}
    private void Update()
    {
        if (rb.position.z > 30) {
            Debug.Log("Out of bounds should delete now-----------------");
            Destroy(gameObject);
        }
    }
}
