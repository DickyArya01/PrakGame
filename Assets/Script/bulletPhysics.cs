using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPhysics : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

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
        transform.position += transform.forward * Time.deltaTime * bulletSpeed; // harusnya line ini udah paham fungsinya
        Destroy(gameObject, 3); // dalam fungsi destroy kita bisa inisiasi parameter kedua, yakni waktu, dengan menggunakan parameter waktu kita bisa mengatur berapa GO akan hancur terhitung dari ketika play scene (3 detik) 

    }


}
