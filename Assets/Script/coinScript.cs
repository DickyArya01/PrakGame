using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    [SerializeField]
    private gameProgress pr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
           // sama methodnya dari gameProgress
           pr.coinCollected(); 
           Destroy(gameObject);
        }    
    }
}
