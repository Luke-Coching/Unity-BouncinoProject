using UnityEngine;

public class respawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    public AudioSource deathSound;

    private void OnTriggerEnter2D(Collider2D other){
            player.transform.position = respawnPoint.transform.position;
            deathSound.Play();
    }
}
