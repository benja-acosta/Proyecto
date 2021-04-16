using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntos : MonoBehaviour
{
    public GameObject mano1;
    public GameObject mano2;
    public Text score;
    public int score2=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        procesar_movimiento();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zanaoria"))
        {
            Destroy(collision.gameObject);
            score2 = 1 + score2;
            score.text = score2.ToString();
        }
    }

    void procesar_movimiento()
    {
        //RaycastHit2D col = Physics2D.Raycast(new Vector2(mano1.transform.position.x, mano1.transform.position.y), new Vector2(1, 0), 0.05f);

        //if ( col.collider != null)
        //{

        //    if (col.transform.tag == ("Zanaoria"))
        //    {
        //        Debug.DrawRay(new Vector2(mano1.transform.position.x, mano1.transform.position.y), new Vector2(1f, 0), Color.blue);


        //    }
        //    else
        //    {
        //        Debug.DrawRay(new Vector2(mano1.transform.position.x, mano1.transform.position.y), new Vector2(1f, 0), Color.red);
        //    }
        //}
        //else
        //{
            
            
        //}

    }

}
