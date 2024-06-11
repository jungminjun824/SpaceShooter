using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float turnSpeed = 80f;

    private Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    private void Start()
    {
        anim.Play("Idle");
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(이동 방향 + 속력 + Time.deltaTime)
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

        _PlayerAnim(h, v);

    }
    private void _PlayerAnim(float h, float v)
    {
        if (v >= 0.1f)
            anim.CrossFade("RunF", 0.25f);
        else if (v <= -0.1f)
            anim.CrossFade("RunB", 0.25f);
        else if (h >= 0.1)
            anim.CrossFade("RunR", 0.25f);
        else if (h <= -0.1)
            anim.CrossFade("RunL", 0.25f);
        else
            anim.CrossFade("Idle", 0.25f);
    }
}
