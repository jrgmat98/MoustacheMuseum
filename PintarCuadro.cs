using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintarCuadro : MonoBehaviour
{
    
    public Cuadro cuadro;
    private float _Time = 0;
    private float _MaxTime;
    private bool inside = false;
    private float offsetMax;
    public ProgressBar progressBar;
    public ParticleSystem particles;
    public AudioSource paintEffect;
    private bool audioPlaying=false;

    private void Start()
    {
        _MaxTime = cuadro.tiempo;
        offsetMax = cuadro.GetOffSetPintado();
    }

    void Update()
    {
        
       if (_Time < _MaxTime && inside)
        {
            if (Input.GetButton("Accion"))
            {
                progressBar.BarraProgreso(_Time, _MaxTime);
                if (!audioPlaying)
                {
                    paintEffect.Play();
                    audioPlaying = true;
                }
                particles.Play();
                _Time += Time.deltaTime;
                float x = ((_Time * offsetMax) / _MaxTime) ;
                cuadro.Pintando(x);
                if (_Time >= _MaxTime)
                {
                    cuadro.setPintado();
                }
            }
            else {
                progressBar.Desactivar();
                particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                paintEffect.Stop();
            }

        }
        else
        {
            progressBar.Desactivar();
            particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            paintEffect.Stop();
            audioPlaying = false;
        }
    }
    private void OnTriggerEnter(Collider collision) {  
        if (collision.transform.CompareTag("Player"))
        {
            inside = true;

        }
    }
   
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            inside = false;

        }
    }
}
