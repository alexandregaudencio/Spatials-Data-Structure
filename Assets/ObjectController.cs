using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private int velocity;
    private Vector3 direction;
    private SphereCollider sphereCollider;
    private float sphereRadius => sphereCollider.radius;
    private void Start()
    {
        sphereCollider = gameObject.AddComponent<SphereCollider>();
        //randomize on start
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        
    }
    private void FixedUpdate()
    {
        OutsideBoundary(transform.position);
        transform.position +=  direction * velocity * Time.fixedDeltaTime;
        DetectCollisionObject();
    }


    private void OutsideBoundary(Vector3 targetPosition)
    {
        Vector3 boundarySimulationVector = Vector3.one * SimulationManager.instance.maxBoundary;

        if (targetPosition.x + sphereRadius > boundarySimulationVector.x) direction.x *= -1; 
        if( targetPosition.y + sphereRadius > boundarySimulationVector.y) direction.y *= -1;
        if (targetPosition.z + sphereRadius > boundarySimulationVector.z) direction.z *= -1;
        if (targetPosition.x + -sphereRadius < -boundarySimulationVector.x) direction.x *= -1;
        if (targetPosition.y + -sphereRadius < -boundarySimulationVector.y ) direction.y *= -1;
        if (targetPosition.z + -sphereRadius < -boundarySimulationVector.z) direction.z *= -1;
    }

    private void DetectCollisionObject()
    {
        if (SimulationManager.instance.SphereControllers == null) return;
        foreach (ObjectController objControl in SimulationManager.instance.SphereControllers)
        {
            foreach (ObjectController otherObjControl in SimulationManager.instance.SphereControllers)
            {
                if(objControl != otherObjControl)
                {
                    Vector3 distance = objControl.transform.position - otherObjControl.transform.position;
                    float module = (float)Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y + distance.z * distance.z);
                    if(module < objControl.sphereRadius+otherObjControl.sphereRadius)
                    {
                        Vector3 reflectedDirection = objControl.transform.position - otherObjControl.transform.position;
                        //float diferenceX = otherObjControl.transform.position.x - objControl.transform.position.x;
                        //float diferenceY = otherObjControl.transform.position.y - objControl.transform.position.y;
                        //float diferenceZ = otherObjControl.transform.position.z - objControl.transform.position.z;
                        objControl.direction = reflectedDirection.normalized;
                        //circle.vely = -diferenceY / maxRadius;
                    }
                }
            }
        }
    }

}
