using UnityEngine;
using System.Collections;

public class CameraController2 : MonoBehaviour
{

    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offsetPosition;

    [SerializeField] private Space offsetPositionSpace = Space.Self;

    [SerializeField] private bool lookAt = true;

    private void Update()
    {
        gameObject.transform.position =
            new Vector3(gameObject.transform.position.x, 196, gameObject.transform.position.z);
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);
            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
