using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 offset;
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
