using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    public Transform startPoint;
    public Transform checkPoint;
    private BoxCollider2D checkPointCollider;
    private Animator checkpointCaptured;

    void Awake(){
        checkPointCollider = GetComponent<BoxCollider2D>();
    }

    void Start(){
        checkpointCaptured = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            startPoint.transform.position = checkPoint.transform.position;
            checkPointCollider.enabled = false;
            checkpointCaptured.SetBool("Captured", true);
        }
    }
}
