using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Personaje : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim;

    public float velocidadMovimiento = 5.0f;
    public float x, y;
    public bool suelo;

    public GameObject pies;
    public GameObject pies2;
    public GameObject pies3;


    Rigidbody2D rb2d;
    SpriteRenderer spRd;


    //para Saltar

    public Rigidbody2D rb;
    public float fuerzadesalto = 5;


    public GameObject bulletprefab;

    public float direccion;

    void Start()
    {
        
        suelo = false;
        //Capturo los componentes Rigidbody2D y Sprite Renderer del Jugador
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }



    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        //Movimiento horizontal
        float movimientoH = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movimientoH * velocidadMovimiento, rb2d.velocity.y);

        //Sentido horizontal
        if (movimientoH > 0.1f)
        {
            spRd.flipX = false;
            anim.SetBool("estaCorriendo",true);
        }
        else if (movimientoH < -0.1f)
        {
            spRd.flipX = true;
            anim.SetBool("estaCorriendo", true);
        }
        else
        {
            anim.SetBool("estaCorriendo", false);
        }


        procesar_movimiento();

        // Comprobar si se ha pulsado espacio
        if (Input.GetKeyDown(KeyCode.Space) && suelo == true)
        {
            rb2d.AddForce(Vector2.up * fuerzadesalto, ForceMode2D.Impulse);
            Debug.Log("Apretado V");
            //rb.AddForce(Vector2.up * fuerzadesalto);

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Apretado C");
            Shoot();
        }

        direccion = transform.localScale.z;
    }






        // Update is called once per frame
        void Update()
    {
        

    }


    void procesar_movimiento()
    {
        RaycastHit2D col = Physics2D.Raycast(new Vector2(pies.transform.position.x, pies.transform.position.y), new Vector2(0, -1), 0.08f);
        
        if ( col.collider != null)
        {
            if (col.transform.tag == ("Suelo"))
            {
                
                anim.SetBool("estaSuelo", true);
                suelo = true;
            }
            
        }
        else
        {
            
            anim.SetBool("estaSuelo", false);
            suelo = false;
        }

    }

    private void Shoot()
    {
        Vector3 direction;
        float movimientoH = Input.GetAxisRaw("Horizontal");

        if (movimientoH > 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
        GameObject bullet = Instantiate(bulletprefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<bullets>().SetDirection(direction);





    }


}
