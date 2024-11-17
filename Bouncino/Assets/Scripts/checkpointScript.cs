using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    private respawnScript respawn;
    private BoxCollider2D checkPointCollider2D;   

    void Awake(){
        checkPointCollider2D = GetComponent<BoxCollider2D>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<respawnScript>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            respawn.respawnPoint = this.gameObject;
            checkPointCollider2D.enabled = false;
        }
    }
}
