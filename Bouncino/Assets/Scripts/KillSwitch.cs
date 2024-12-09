using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    public AudioSource deathSound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.transform.position = respawnPoint.transform.position;
            deathSound.Play();
        }
    }
}
