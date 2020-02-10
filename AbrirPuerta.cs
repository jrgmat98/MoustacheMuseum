using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{

    private GameObject[] go;
    private int nCuadros;
    private int completos = 0;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindGameObjectsWithTag("Cuadro");
        nCuadros = go.Length;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (completos == nCuadros)
        {
            anim.SetTrigger("abierto");
        }

    }

    public void incrementar()
    {
        completos++;
    }
}
