using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeteccion : MonoBehaviour
{
    public Patrulla enemigo;
    // Start is called before the first frame update
  

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag=="Player")
        enemigo.Follow();
    }
}
