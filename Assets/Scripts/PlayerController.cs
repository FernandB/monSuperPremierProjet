using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Physics")]
    [SerializeField]//Editable dans unity
    private float force = 10;
    private Rigidbody2D rigid;
    [Header("Jump")]
    [SerializeField]
    private Transform positionRaycastJump;
    [SerializeField]
    private float radiusRaycastJump;
    [SerializeField]
    private LayerMask layerMaskJump;
    [SerializeField]
    private float forceJump = 5;

    private Transform spawnTransform;

    [Header("Fire gun supersonic lol boum")]
    [SerializeField]
    private UnityEngine.GameObject bulletPrefab;
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float bulletVelocity = 2;//metres secondes
    [SerializeField]
    private float timeToFire = 2;
    private float lastTimeFire = 0;
    // Use this for initialization
    void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        spawnTransform = UnityEngine.GameObject.Find("Spawn").transform; //demande beaucoup de ressources
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        Jump();
        if(Input.GetAxis("Fire1") > 0)
        {
            fire();
        }
	}

  private  void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 forceDirection = new Vector2(horizontalInput, 0);
        forceDirection *= force;
        rigid.AddForce(forceDirection,ForceMode2D.Force);
    }

    void Jump()
    {
        bool touchFloor = Physics2D.OverlapCircle(positionRaycastJump.position, radiusRaycastJump, layerMaskJump);
        if(Input.GetAxis("Jump")>0&&touchFloor)
        {
            rigid.AddForce(Vector2.up * forceJump,ForceMode2D.Impulse);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="limit")
        {
            transform.position = spawnTransform.position;
        }
    }

    private void fire()
    {
        if (Time.realtimeSinceStartup - lastTimeFire > timeToFire)
        {
            UnityEngine.GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * bulletVelocity;
            Destroy(bullet, 1);
            lastTimeFire = Time.realtimeSinceStartup;
        }
    }
}
