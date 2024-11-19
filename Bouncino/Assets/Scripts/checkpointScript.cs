using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    public Transform startPoint;
    public Transform checkPoint;
    private BoxCollider2D checkPointCollider;   

    void Awake(){
        checkPointCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            startPoint.transform.position = checkPoint.transform.position;
            checkPointCollider.enabled = false;
        }
    }
}
