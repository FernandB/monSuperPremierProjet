using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiController : MonoBehaviour {
    [SerializeField]
    private Transform[] gunsTransformList;
    [SerializeField]
    private float timeToFire = 2;
    [SerializeField]
    private UnityEngine.GameObject bulletPrefab;
    // Use this for initialization
    void Start () {
        StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Fire()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeToFire);
            foreach(Transform t in gunsTransformList)
            {
                UnityEngine.GameObject bullet = Instantiate(bulletPrefab, t.position, t.rotation);
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().velocity = t.right * 15;
                
            }
        }
    }
}
