using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class personaje2 : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private Animator anim;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    private int Health = 5;

    public GameObject pies;



    public Text bala1;
    public int bala2 = 0;


    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        anim = GetComponent<Animator>();
        int.TryParse(bala1.ToString(), out bala2);
    }

    private void Update()
    {
        
       

        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-0.4803436f, 0.4803436f, 0.4803436f);
            anim.SetBool("estaCorriendo", true);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(0.4803436f, 0.4803436f, 0.4803436f);
            anim.SetBool("estaCorriendo", true);
        }else
        {
            anim.SetBool("estaCorriendo", false);
        }

        //Animator.SetBool("running", Horizontal != 0.0f);


        RaycastHit2D col = Physics2D.Raycast(new Vector2(pies.transform.position.x, pies.transform.position.y), new Vector2(0, -1), 0.08f);

        // Detectar Suelo
        Debug.DrawRay(pies.transform.position, Vector3.down * 0.1f, Color.red);
        //piso = Physics2D.Raycast(transform.position, Vector3.down, 0.1f);
        if (Physics2D.Raycast(pies.transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
            anim.SetBool("estaSuelo", true);
        }
        else
        {
            Grounded = false;
            anim.SetBool("estaSuelo", false);
        }


        // Salto

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        // Disparar
        if (Input.GetKey(KeyCode.C) && Time.time > LastShoot + 0.25f)
        {
            if (bala2 > 0)
            {
                Shoot();
                LastShoot = Time.time;
                bala2 = bala2 - 1;
                bala1.text = bala2.ToString();
                anim.SetBool("golpe2", true);
            }
            
        }
        else
        {
            anim.SetBool("golpe2", false);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        //rb2d.AddForce(Vector2.up * fuerzadesalto, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.4803436f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<bullets>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zanaoria"))
        {
            Destroy(collision.gameObject);
            bala2 = 1 + bala2;
            bala1.text = bala2.ToString();
        }
    }
}