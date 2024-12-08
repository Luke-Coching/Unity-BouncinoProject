using System.Drawing;
using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject spawnPoint;
    public AudioSource deathSound;
    public GameObject PointA;
    public GameObject PointB;
    private BoxCollider2D enemyCollider;
    private Rigidbody2D rb;
    private Transform currentPos;
    private Animator spikeAttack;
    int count = 0;
    int secondCount = 0;
    public float speed;

    void Awake(){
        enemyCollider = GetComponent<BoxCollider2D>();
    }

    void Start(){
        spikeAttack = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentPos = PointB.transform;
    }

    void Update(){
        //Attack Sequence
        count++;

        if(count == 250){
            secondCount ++;
            count = 0;
        }

        if(secondCount > 2){
            spikeAttack.SetInteger("AttackCount", secondCount);
        } else {
            spikeAttack.SetInteger("AttackCount", secondCount);
        }

        if(secondCount == 7){
            secondCount = 0;
        }
        //////////////////////

        //Movement Sequence
        Vector2 point = currentPos.transform.position - transform.position;
        if(currentPos == PointB.transform){
            rb.linearVelocityX = speed;
        } else {
            rb.linearVelocityX = -speed;
        }

        if(Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == PointB.transform){
            currentPos = PointA.transform;
        }
        
        if(Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == PointA.transform){
            currentPos = PointB.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && secondCount < 3){
            Destroy(enemy);
            enemyCollider.enabled = false;
        } else if(other.gameObject.CompareTag("Player") && secondCount >= 3) {
            player.transform.position = spawnPoint.transform.position;
            deathSound.Play();
        }
    }
   
}
