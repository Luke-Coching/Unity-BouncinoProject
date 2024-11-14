using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DragLine : MonoBehaviour
{
    public LineRenderer line;

    public void Awake(){
        line = GetComponent<LineRenderer>();
    }

    public void renderLine(Vector3 start, Vector3 end){
        line.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = start;
        points[1] = end;
        
        line.SetPositions(points);
    }

    public void endLine(){
        line.positionCount = 0;
    }
}
