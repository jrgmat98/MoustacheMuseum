using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuadro : MonoBehaviour
{
    public float tiempo;
    bool estado = false;
    private Renderer rend;

    public AbrirPuerta[] abrir;

    public float offSetPintado;


    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    private void Update()
    {
        
    }
    public void setPintado()
    {
        estado = true;



        rend.material.SetTextureOffset("_SplashTex", new Vector2(offSetPintado, 0));
        for (int i =0; i < abrir.Length;i++) {
            abrir[i].incrementar();
        }
        
    }

    public void Pintando(float offSet)
    {
        rend.material.SetTextureOffset("_SplashTex", new Vector2(offSet, 0));
    }

    public float GetTiempo()
    {
        return tiempo;
    }

    public float GetOffSetPintado()
    {
        return offSetPintado;
    }
}
