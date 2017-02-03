using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject mini;
    public int scoreValue;
    private GameController gameController;
    private PlayerController p;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (gameControllerObject!=null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (playerObject != null)
        {
            p = playerObject.GetComponent<PlayerController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot Find 'GameController' script");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " " + tag + " collided with " + other.name + " " + other.tag);
        // need to restructure with nested if checks

        
        if (tag.CompareTo("PickUpW") == 0)
        {
            // player picks it up
            if(other.tag == "Player")
            {
                Debug.Log("Pick Up Here");
                int i = p.weaponLv;
                if (i < 3)
                {
                    p.weaponLv++;
                    Debug.Log("Picked it Up");
                }
            Destroy(gameObject);   
            return;
            }
            if (other.tag.CompareTo("bolt") == 0) { Destroy(other.gameObject); }
            // Enemy, boss, EnemyBolt should not destroy it  
            return;
        }
        else if (tag.CompareTo("BadPickUpW") == 0)
        {
            // player picks it up
            if(other.tag == "Player")
            {
                Debug.Log("Pick Up Here");
                int i = p.weaponLv;
                if (i < 3)
                {
                    p.weaponLv--;
                    Debug.Log("Picked Up Bad item");
                }
            Destroy(gameObject);
            return;
            }
            if (other.tag.CompareTo("bolt") == 0) { Destroy(other.gameObject); }
             // Enemy, boss, EnemyBolt should not destroy it  
            return;
        }
        /*
        else if (tag.CompareTo("PickUpSp") == 0)
        {
            // player picks it up

            // Enemy, boss, EnemyBolt should not destroy it  

        }
        else if (tag.CompareTo("BadPickUpSp") == 0)
        {
            // player picks it up

            // Enemy, boss, EnemyBolt should not destroy it  

        }
        else if (tag.CompareTo("PickUpI") == 0)
        {
            // player picks it up

            // Enemy, boss, EnemyBolt should not destroy it  

        }
        else if (tag.CompareTo("BadPickUpI") == 0)
        {
            // player picks it up

            // Enemy, boss, EnemyBolt should not destroy it  

        }
        else if (tag.CompareTo("PickUpSh") == 0)
        {
            // player picks it up

            // Enemy, boss, EnemyBolt should not destroy it  

        }
        else if (tag.CompareTo("BadPickUpSh") == 0)
        {
            // player picks it up

            // Enemy, boss, EnemyBolt should not destroy it  

        }
        else if (tag.CompareTo("Player") == 0)
        {
            //dont think this will ever occur
        }
        
        
        
        
        else if (tag.CompareTo("Enemy") == 0)
        {
            // should only be destroyed if hit with bolt
            if(other.tag.CompareTo("bolt")==0){Destroy(gameObject);}
        // should destroy player if collides
            if(other.tag.CompareTo("Player")==0)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }

        }
        else if (tag.CompareTo("EnemyBolt") == 0)
        {
            // destroy on contact with everything but Boundary
            if(other.tag.CompareTo("Player")==0)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
        }
        else if (tag.CompareTo("bolt") == 0)
        {
            // not sure i need this either
            Destroy(other.gameObject);
        }
        else if (tag.CompareTo("boss") == 0)
        {
            // should be destroyed when hit with bolt then spawn Minis
            if(other.tag.CompareTo("bolt")==0)
        {
            Debug.Log(name + " " + tag + " and " + other.name + " " + other.tag + " got destroyed");
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Instantiate(mini, other.transform.position - new Vector3(1.25f, 0.0f, 0.0f), other.transform.rotation);
            Instantiate(mini, other.transform.position + new Vector3(0.0f, 0.0f, 1), other.transform.rotation);
            Instantiate(mini, other.transform.position + new Vector3(1.25f, 0.0f, 0.0f), other.transform.rotation);
        }
        else if (tag.CompareTo("Boundary") == 0)
        {
            // i think do nothing
            return;
        }
        else { }
        
        if (explosion != null)
        {
            Debug.Log(name + " exploded");
            Instantiate(explosion, transform.position, transform.rotation);
        }
        */



        /* if (tag == "PickUpW" && other.tag == "Player")
         {
             Debug.Log("Pick Up Here");
             int i = p.weaponLv;
             if (i < 3)
             {
                 p.weaponLv++;
                 Debug.Log("Picked it Up");
             }
             Destroy(gameObject);
             return;
         }

         if (tag == "BadPickUp" && other.tag == "Player")
         {
             Debug.Log("Pick Up Here");
             int i = p.weaponLv;
             if (i < 3)
             {
                 p.weaponLv--;
                 Debug.Log("Bad Pick Up");
             }
             Destroy(gameObject);
             return;
         }
         if (tag == "EnemyBolt" && other.tag == "BadPickUp")
         {
             Destroy(gameObject);
             return;
         }
         if ((tag == "PickUpW" || tag == "BadPickUp") && (other.tag == "bolt" || other.tag == "EnemyBolt"))
         {
             Debug.Log("returned");
             Destroy(other.gameObject);
             return;
         }*/

        if (tag == "Enemy" && other.tag == "Enemy")
        {
            Debug.Log("returned");
            return;
        }

        if (tag == "EnemyBolt" && other.tag == "Boundary")
        {
            Debug.Log("shot hit the edge and kept going---------------------------------------");
            return;
        }

        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            Debug.Log("Return");
            return;
        }
        
        if (tag == "Enemy" && other.tag == "EnemyBolt")
        {
            Debug.Log("returned");
            return;
        }

        if (tag == "boss" && other.tag == "EnemyBolt")
        {
            Debug.Log("returned");
            return;
        }

        if (tag == "boss" && other.tag == "BadPickUp")
        {
            Debug.Log("returned");
            return;
        }

        if (tag == "boss" && other.tag != "boss")
        {
            Debug.Log(name + " " + tag + " and " + other.name + " " + other.tag + " got destroyed");
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
            Debug.Log("returned");
            return;
        }

        if (explosion != null)
        {
            Debug.Log(name + " exploded");
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
