using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float sensorLength = 5.0f;
    public float speed = 10.0f;
    float directionValue = 1.0f;
    float turnValue = 0.0f;
    public float turnSpeed = 50.0f;

    Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = transform.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int flag = 0;

        //right hit sensor
        if (Physics.Raycast(transform.position, transform.right, out hit, (sensorLength + transform.localScale.x)))
        {
            if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }

            turnValue -= 1;
            flag++;
        }

        //left sensor
        if (Physics.Raycast(transform.position, -transform.right, out hit, (sensorLength + transform.localScale.x)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }

            turnValue += 1;
            flag++;

        }

        //front sensor
        if (Physics.Raycast(transform.position, transform.forward, out hit, (sensorLength + transform.localScale.z)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }

            if(directionValue == 1.0f)
            {
                directionValue = -1;
            }
            flag++;


        }

        //back sensor
        if (Physics.Raycast(transform.position, -transform.forward, out hit, (sensorLength + transform.localScale.z)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }

            if (directionValue == -1.0f)
            {
                directionValue = 1;
            }
            flag++;

        }

        if(flag == 0)
        {
            turnValue = 0;
        }

        transform.Rotate(Vector3.up * (turnSpeed * turnValue) * Time.deltaTime);

        transform.position += transform.forward * (speed*directionValue) * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, -transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, transform.right * (sensorLength + transform.localScale.x));
        Gizmos.DrawRay(transform.position, -transform.right * (sensorLength + transform.localScale.x));

    }
}
