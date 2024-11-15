using UnityEngine;

public class dragAndShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D body;
    public Transform prop;
   
    public Vector2 minPower;
    public Vector2 maxPower;
    DragLine dl;

    Camera cam;
    Vector2 force;
    Vector3 start;
    Vector3 end;

    private void Start(){
        cam = Camera.main;
        dl = GetComponent<DragLine>();
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            start = cam.ScreenToWorldPoint(Input.mousePosition);
            start.z = 15;
        }

        if(Input.GetMouseButton(0)){
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            dl.renderLine(start, currentPoint);
        }

        if(Input.GetMouseButtonUp(0)){
            end = cam.ScreenToWorldPoint(Input.mousePosition);
            end.z = 15;

            force = new Vector2(Mathf.Clamp(start.x - end.x, minPower.x, maxPower.x), Mathf.Clamp(start.y - end.y, minPower.y, maxPower.y));
            body.AddForce(force * power, ForceMode2D.Impulse);
            dl.endLine();
        }
    }
}
