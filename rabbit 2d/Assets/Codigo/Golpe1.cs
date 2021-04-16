using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe1 : MonoBehaviour
{
    private Animator anim;
    public GameObject pies;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("v");
            anim.SetTrigger("golpe1");
        }
        procesar_movimiento();




    }

    void procesar_movimiento()
    {



    }




}
