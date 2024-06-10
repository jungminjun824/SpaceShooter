using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10.0f;

    [SerializeField] private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �����¿� �̵� ���� ���� ���
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(�̵� ���� + �ӷ� + Time.deltaTime)
        _transform.Translate(moveDir * moveSpeed * Time.deltaTime);

    }
}
