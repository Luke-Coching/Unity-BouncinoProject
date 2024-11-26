using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private BoxCollider2D enemyCollider;
    private Animator spikeAttack;
    int count = 0;
    int secondCount = 0;
    void Start(){
        spikeAttack = GetComponent<Animator>();
    }

    void Update(){
        count++;

        if(count == 500){
            secondCount ++;
            count = 0;
        }

        spikeAttack.SetInteger("Attack", secondCount);

        if(secondCount == 7){
            secondCount = 0;
        }
    }

    void Awake(){
        enemyCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Destroy(enemy);
            enemyCollider.enabled = false;
        }
    }
   
}
