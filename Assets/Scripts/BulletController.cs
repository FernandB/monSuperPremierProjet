using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    [SerializeField]
    GameObject gameManagerPrefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gameManager = gameManagerPrefab.GetComponentInParent<GameManager>();

        if (collision.tag == "player")
            {
            gameManager.PlayerDie();
            }
            else
            {
                if(collision.tag == "ennemi")
               gameManager.EnnemiDie();
            }
    }

}
