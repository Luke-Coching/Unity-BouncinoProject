using Unity.VisualScripting;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject spawnPoint;
    public AudioSource deathSound;
    public GameObject PointA;
    public GameObject PointB;
    public dragAndShoot launchMechanic;
    public PolygonCollider2D enemyCollider;
    public finalLevel levelComplete;
    private Rigidbody2D rb;
    private Transform currentPos;
    private Animator spikeAttack;
    int count = 0;
    int secondCount = 0;
    int bossHealth = 5;
    public float speed;

    void Awake(){
        enemyCollider = GetComponent<PolygonCollider2D>();
    }

    void Start(){
        spikeAttack = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentPos = PointB.transform;
    }

    void Update(){
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

        //Attack Sequence
        count++;

        if(count == 200){
            secondCount ++;
            count = 0;
        }

            spikeAttack.SetInteger("SpikeAttack", secondCount);

        if(secondCount == 7){
            secondCount = 0;
        }
        //////////////////////

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && secondCount < 3){
            bossHealth -= 1;
            launchMechanic.knockbackCount = launchMechanic.knockbackTotTime;

            if(other.transform.position.x <= transform.position.x){
                launchMechanic.hitRight = true;
            } else if (other.transform.position.x > transform.position.x){
                launchMechanic.hitRight = false;
            }

            if(bossHealth == 0){
                Destroy(enemy);
                enemyCollider.enabled = false;
                levelComplete.bossDefeated = true;
            }
        } else if(other.gameObject.CompareTag("Player") && secondCount >= 3) {
            player.transform.position = spawnPoint.transform.position;
            deathSound.Play();
        }
    }

}
