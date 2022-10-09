using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMechanic : MonoBehaviour
{

    Rigidbody rb; //inisiasi komponen CharacterController pada GameObject Capsule 

    /* 
    umumnya kita bisa menginisialisasi variable menggunakan enkapsulasi public
    namun penggunaan public dianggap 'kurang aman' karena variable tersebut dapat kita akses dari mana saja
    untuk itu disini kita dapat menggunakan enkapsulasi private
    agar dapat berfungsi seperti public (parameter inisiasi variable muncul pada komponen di inspector)
    disini kita bisa beri [SerializeField] ~ 
    */

    [SerializeField]
    private float speed;

    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private float jumpForce;

    private bool isGrounded;

    [SerializeField]
    private GameObject secondCamera;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private gameProgress pr;
    
    //Metode urut berdasarkan waktu eksekusinya ketika game di play, Awake > Start > Update

    // Method Awake dijalankan ketika script di load
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //mengambil komponen Rigidvbody pada GO untuk diinisasi ke rb
        
    }

    // Method Start dijalankan ketika frame pertama kali diupdate
    void Start()
    {
    }


    // Method dijalankan tiap frame 
    void Update()
    {
        if (pr.playerLive == 0)
        {
            Destroy(gameObject);
            secondCamera.SetActive(true);   

        }
    }

    // method ini dijalankan setiap framerate tetap frame, best digunakan jika programnya berhubungan dengan fisika (jalan, lompat, dll)
    // hal ini karena bisa jadi pada game kita framerate nya bisa turun, program yang dijalankan dalam method fixed update akan bekerja menyesuaikan frameratenya
    private void FixedUpdate()
    {
        movement();
        fire();
    }

    /// OnCollisionStay dipanggil ketika collider tetap menempel pada collider lain 
    private void OnCollisionStay(Collision other)
    {
        //jika collider yang tetap di sentuh merupakan GO dengan tag Ground
        if (other.gameObject.tag == "Ground")
        {
            //sedang berada di tanah (benar)
            isGrounded = true;
            
        }
    }

    //movement player
    private void movement() {
        // https://docs.unity3d.com/ScriptReference/Transform-forward.html
        // transform.forward berfungsi agar gameObject dapat bergerak kedepan (sumbu Z). berbeda dengan Vector3.forward, pada transform.forward axis arah geral akan berubah jika rotasi GO berubah, sedang Vector3.forward arahnya tidak akan berubah meskipun rotasi berubah 

        // transform.forward
        Vector3 moveWithAxis = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed;
        rb.position += moveWithAxis;
        Vector3 jumping = (transform.up * Input.GetAxis("Jump") * Time.deltaTime * jumpForce) + moveWithAxis;
        
        // Vector3.forward
        // Vector3 moveWithoutAxis = Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed;
        // transform.position += moveWithoutAxis;
        // Vector3 jumping = (transform.up * Input.GetAxis("Jump") * Time.deltaTime * jumpForce) + moveWithoutAxis;
        
        // https://docs.unity3d.com/ScriptReference/Vector3-up.html
        // command untuk merotasi GO, Vector3.up artinya kita akan merotasi berdasarkan sumbu y
        // Vector.up == Vector3 (0, 1, 0) 
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed );


        //jiks nilai axis Jump lebih dari 0 (tombol Jump ditekan) dan sedang berada ditanah (benar)
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            rb.velocity = jumping; //lompat
            isGrounded = false; // sedang berada di tanah (tidak)
        }

    }

    // fire projectile
    private void fire() {
        if (Input.GetButtonDown("Fire1"))
        {
            //Generate prefab bullet
            //parameter instantiate => Instantiate(prefab, letak posisi prefab akan digenerate, rotasi prefab)
            // rb.position => posisi player berdasarkan rigidbodynya Vector3(x,y,z)
            // transform.forward => Vector3(0,0,1)
            // jadi rb.position + transform.forward = Vector3(x,y,z) + Vector3(0,0,1) = Vector3(x+0,y+0,z+1) = Vector3(x,y,1), jadi prefab akan di generate di depan player (z+1)            
            Instantiate(bullet, rb.position + transform.forward, rb.rotation);
        }
    }



}
