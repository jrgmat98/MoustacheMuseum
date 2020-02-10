using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;



public enum StatePlayer { Andar, Correr, Sigilo, Iddle };
[RequireComponent(typeof(CharacterController))]


public class PlayerMovement : MonoBehaviour
{

    public enum StatePlayer { Andar, Correr, Sigilo, Iddle };
    [Header("Input")]
    public string inputHorizontal = "Horizontal";
    public string inputVertical = "Vertical";
    private bool escena_cargada = false;


    public float movementSpeed;
    public float movementSpeedSigilo;
    public float movementSpeedCorrer;
    public Animator animator;

    private bool pintando = false;
    private CharacterController _charController;

    public UI ui;

    public Camera camara;
    private StatePlayer estado = StatePlayer.Andar;



    private bool playerState;
    private Vector3 _previousPosition;
    public AudioSource audioMain;
    public AudioSource audioWin;

    // Start is called before the first frame update
    void Start()
    {

        _charController = GetComponent<CharacterController>();
        _previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis(inputHorizontal);

        float inputY = Input.GetAxis(inputVertical);
       
        if (Input.GetButton("Sigilo") && !Input.GetButton("Correr") && (inputX != 0 || inputY != 0))
        {
            estado = StatePlayer.Sigilo;
        }
        else if (!Input.GetButton("Sigilo") && Input.GetButton("Correr") && (inputX != 0 || inputY != 0))
        {
            estado = StatePlayer.Correr;
        }
        else if (inputX == 0 && inputY == 0)
        {
            estado = StatePlayer.Iddle;
        }
        else
        {
            estado = StatePlayer.Andar;
        }



       

        if (!LoaderManager.gameOver)
        {
            playerState = true;
            movementSpeed = 5;
            Vector3 movement = inputX * camara.transform.forward + inputY * camara.transform.right;
            if (movement.sqrMagnitude > 1 && !pintando)
            {
                movement.Normalize();
            }

            switch (estado)
            {
                case StatePlayer.Andar:
                    _charController.SimpleMove((movementSpeed * movement));
                    break;
                case StatePlayer.Correr:
                    _charController.SimpleMove((movementSpeedCorrer * movement));
                    break;

                case StatePlayer.Sigilo:
                    _charController.SimpleMove((movementSpeedSigilo * movement));
                    break;

            }

            _charController.SimpleMove((movementSpeed * movement));

            if (inputX != 0 || inputY != 0)
            {
                _charController.transform.LookAt(transform.position + (transform.position - _previousPosition));
            }
            _previousPosition = transform.position;
            
            animator.SetInteger("estado", (int)estado);
            animator.SetBool("pintando", pintando);
        }


    }


    public StatePlayer GetPlayerState()
    {
        return estado;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Win"))
        {
            ui.Win();
            audioMain.Stop();
            audioWin.Play();
        }
    }
}

