using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    public AudioSource soundFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            soundFX.Play();
        }
    }
}
