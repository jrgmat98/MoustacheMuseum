using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera camera;
    public Image image;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }


    public void BarraProgreso(float tiempoAcual, float maxTime)
    {
        image.enabled = true;
        image.fillAmount = tiempoAcual / maxTime;

    }

    public void Desactivar()
    {
        image.enabled = false;
    }
}
