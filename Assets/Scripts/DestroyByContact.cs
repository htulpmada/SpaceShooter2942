using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject mini;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject!=null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot Find 'GameController' script");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " " + tag + " collided with " + other.name + " " + other.tag);

        if (tag == "Enemy" && other.tag == "Enemy")
        {
            //Debug.Log("returned");
            return;
        }

        if (tag == "EnemyBolt" && other.tag == "Boundary")
        {
            //Debug.Log("shot hit the edge and kept going---------------------------------------");
            return;
        }

        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            //Debug.Log("Return");
            return;
        }
        
        if (tag == "Enemy" && other.tag == "EnemyBolt")
        {
            //Debug.Log("returned");
            return;
        }

        if (tag == "boss" && other.tag == "EnemyBolt")
        {
            //Debug.Log("returned");
            return;
        }

        if (tag == "boss" && other.tag != "boss")
        {
           // Debug.Log(name + " " + tag + " and " + other.name + " " + other.tag + " got destroyed");
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Instantiate(mini, other.transform.position - new Vector3(1.25f, 0.0f, 0.0f), other.transform.rotation);
            Instantiate(mini, other.transform.position + new Vector3(0.0f, 0.0f, 1), other.transform.rotation);
            Instantiate(mini, other.transform.position + new Vector3(1.25f, 0.0f, 0.0f), other.transform.rotation);
            return;
        }

        if (other.tag == "boss")
        {
            //Debug.Log("returned");
            return;
        }

        if (explosion != null)
        {
            //Debug.Log(name + " exploded");
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
              
        Debug.Log(name + " " + tag + " and " + other.name + " " + other.tag + " got destroyed");
        gameController.addScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
       
    }
}
