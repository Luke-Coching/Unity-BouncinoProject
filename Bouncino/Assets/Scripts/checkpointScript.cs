using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    private respawnScript respawn;

    void Awake(){
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<respawnScript>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            respawn.respawnPoint = this.gameObject;
        }
    }
}
