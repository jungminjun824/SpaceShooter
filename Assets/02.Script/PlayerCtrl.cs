using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    private Animation anim;

    public float moveSpeed = 10.0f;
    public float turnSpeed = 80f;

    private readonly float initHP = 100.0f;
    public float currHP;

    public delegate void PlayerDieHander();
    public static event PlayerDieHander OnPlayerDie;
    IEnumerator Start()
    {
        currHP = initHP;

        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");

        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = 80.0f;
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(이동 방향 + 속력 + Time.deltaTime)
        tr.Translate(moveDir * moveSpeed * Time.deltaTime);

        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

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

    private void OnTriggerEnter(Collider collider)
    {
        if(currHP >= 0.0f && collider.CompareTag("Punch"))
        {
            currHP -= 10.0f;
            Debug.Log($"Player hp = {currHP / initHP}");

            if (currHP <= 0.0f){
                PlayerDie();
            }
        }
    }

    private void PlayerDie()
    {
        Debug.Log("Player Die !");
        //GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

        //foreach(GameObject monster in monsters)
        //{
        //    monster.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        //}
        OnPlayerDie();
    }
}
