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
    private gameProgress pr; // inisiasi script dengan nama kelas gameProgress yang mana ada di GO Body pada Player

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
    // merubah posisi rb sesuai sumbu z menggunakan fungsi transform.forward
    private void FixedUpdate()
    {
        // maju searah sumbu z (karena transform.forward)
        move = transform.forward * Time.deltaTime * enemySpeed;
        // ubah posisi player berdasar rb dengan var move (supaya maju rek)
        rb.position += move;
        
    }

    // ketika ada GO lain yang collide dengan GO ini, other = GO lain
    private void OnCollisionEnter(Collision other)
    {
        // jika collide dengan GO tag Player
        if (other.gameObject.tag == "Player")
        {
            // nyawa berkurang
            // method diambil dari kelas gameProgress
            // males jelasin, harus nya kalau lulus PBO sama SD pasti ngerti lah ya
            pr.liveDecrease();
        }

        // jika collide dengan GO tag Bullet
        if (other.gameObject.tag == "Bullet")
        {
            // males jelasin, harus nya kalau lulus PBO sama SD pasti ngerti lah ya
            live--;
            Destroy(other.gameObject);
            if (live == 0)
            {
                Destroy(gameObject);   
            }
        }
    }

    // ini merupakan method OnTriggerEnter yang mana ketika Collider GO ini collide dengan GO dengan 
    // Collider yang isTrigger nya di centang, maka method ini akan dijalankan
    private void OnTriggerEnter(Collider other)
    {
        // supaya puter balik
        // males jelasin, harus nya kalau lulus PBO sama SD pasti ngerti lah ya
        enemySpeed = enemySpeed * -1;
    }
}
