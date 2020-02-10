using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour
{
    private Transform player;
    private PlayerMovement playerGO;
    private Transform[] points;
    private NavMeshAgent agent;
    private int last = -1;
    private int last2 = -1;
    private bool follow = false;
    private EndLevelLose end;
    private bool ray;
    private StatePlayer playerState;

    public float maxDist;
    public float maxAngle;
    public float maxDistSigilo;
    public float maxAngleSigilo;
    public float maxDistCorrer;
    public float maxAngleCorrer;
    public AudioSource audioMain;
    public AudioSource audioLose;

    public UI ui;
    public LayerMask layersToAffect;
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = playerGO.GetComponent<Transform>();
        List<Transform> aux2 = new List<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GameObject[] aux = GameObject.FindGameObjectsWithTag("point");
        foreach (GameObject i in aux)
        {
            aux2.Add( i.GetComponent<Transform>());
        }
        points = aux2.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = player.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        float distance = targetDir.magnitude;
        RaycastHit _hit;
        ray = Physics.Raycast(transform.position, player.position, out _hit, distance, layersToAffect);

        playerState = (StatePlayer)playerGO.GetPlayerState();

        

        switch (playerState)
        {
            case StatePlayer.Andar:
                if (angle < maxAngle && distance < maxDist && !ray)
                    follow = true;
                break;
            case StatePlayer.Correr:
                if (angle < maxAngleCorrer && distance < maxDistCorrer && !ray)
                    follow = true;
                break;
            case StatePlayer.Sigilo:
                if (angle < maxAngleSigilo && distance < maxDistSigilo && !ray)
                    follow = true;
                break;

        }

        if (agent.remainingDistance < 0.5f )
        {
            GoToNextPoint();
        } else if(follow)
        {
            Follow();
        }

        Debug.DrawRay(transform.position, targetDir, Color.red);


        

    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        
        int x = Random.Range(0, points.Length);
        if (x==last || x == last2)
        {
            while(x==last || x == last2)
            {
               x = Random.Range(0, points.Length-1);
            }
        }

        agent.destination = points[x].position;
        last2 = last;
        last = x;

    }

    public void Follow()
    {
        agent.destination = player.position;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            ui.Lose();
            audioMain.Stop();
            audioLose.Play();
        }
    }
}
