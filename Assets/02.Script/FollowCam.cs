using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform _camTr;

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;

    [Range(0.0f, 10.0f)]
    public float height = 2.0f;


    private void Awake()
    {
        _camTr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        _camTr.position = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);
        _camTr.LookAt(targetTr.position);
    }
}
