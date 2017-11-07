using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    [SerializeField]
    GameObject gameManagerPrefab;
    GameManager gameManager;
    [SerializeField]
    GameObject parentGameObject;
    // Use this for initialization
    void Start () {
         gameManager = (GameManager)gameManagerPrefab.GetComponent(typeof(GameManager));
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "player"&&parentGameObject.name.Equals("Ennemi"))
            {
            gameManager.PlayerDie();
            
        }
        else
            {
            if (collision.gameObject.tag == "ennemi" && parentGameObject.name.Equals("Player"))
                gameManager.EnnemiDie();
        }

        
    }

}
