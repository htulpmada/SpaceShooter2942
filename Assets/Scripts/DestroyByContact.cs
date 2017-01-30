﻿using System.Collections;
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
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        if (tag == "boss")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Instantiate(mini, other.transform.position, other.transform.rotation);
            Instantiate(mini, other.transform.position, other.transform.rotation);
            Instantiate(mini, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            Destroy(gameObject);
            return;
        }
        Debug.Log(other.name);
        
        gameController.addScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
