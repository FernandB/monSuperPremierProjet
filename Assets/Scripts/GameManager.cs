using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private int lifes = 3;
    private int ennemiLifes = 3;
    [SerializeField]
    private Text textLifes;
    [SerializeField]
    private Text textEnnemiLifes;

    private const string TEXT_LIFES= "Lifes : ";

	// Use this for initialization
	void Start () {
        textLifes.text = TEXT_LIFES + lifes;
        textEnnemiLifes.text = TEXT_LIFES + ennemiLifes;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayerDie()
    {
        lifes--;
        if (lifes <= 0)
        {
            SceneManager.LoadScene("DieMenu");
        }
        else
        {
            textLifes.text = TEXT_LIFES + lifes;
        }
        
    }
    public void EnnemiDie()
    {
        ennemiLifes--;
        if (ennemiLifes<=0)
        {
            SceneManager.LoadScene("WinMenu");
        }
        else
        {
            textEnnemiLifes.text = TEXT_LIFES + lifes;
        }

    }
}
