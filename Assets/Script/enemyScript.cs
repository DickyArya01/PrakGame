using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField]
    private float live = 3;

    [SerializeField]
    private float enemySpeed = 10;

    [SerializeField]
    private gameProgress pr;

    private Rigidbody rb;

    private Vector3 move;

    /// Awake is called when the script instance is being loaded.
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    private void FixedUpdate()
    {
        move = transform.forward * Time.deltaTime * enemySpeed;

        rb.position += move;
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            pr.liveDecrease();
        }

        if (other.gameObject.tag == "Bullet")
        {
            live--;
            Destroy(other.gameObject);
            if (live == 0)
            {
                Destroy(gameObject);   
            }
        }
    }

    // / OnTriggerEnter is called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        enemySpeed = enemySpeed * -1;
    }
}
