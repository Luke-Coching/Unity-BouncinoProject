using UnityEngine;

public class respawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D other){
            player.transform.position = respawnPoint.transform.position;
    }
}
