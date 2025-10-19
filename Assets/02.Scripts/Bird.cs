using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird bird;
    public float birdJumpForce = 400.0f; // 새가 점프 하는 힘

    public Vector3 lookDirection; // 새가 어디를 봐야하는지 정해주기 위해서
    public GameObject birdimg;    // 움직일 새 이미지(어디를 봐야할지)

    void Start()
    {
        bird = this;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.transform.position.y <= 5f) // y값이 5보다 작고 마우스가 눌렸으면
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); // 속도룰 0으로 놓고
            this.gameObject.GetComponent<Rigidbody>().AddForce(0f, birdJumpForce, 0f); // 가속을 birdjump만큼 시킨다
            GetComponent<AudioSource>().Play(); // 소리를 낸다
        }

        // y축의 속도가 증가하면 y값이 되서 위를 보고,반대가 되면 y값이 -가 되어 아래를본다
        lookDirection.z = GetComponent<Rigidbody>().velocity.y * 10f + 20f;

        Quaternion R = Quaternion.Euler(lookDirection); // z축 중심으로 z축 회전값을 반환
        birdimg.transform.rotation = Quaternion.RotateTowards(birdimg.transform.rotation, R, 5f);
    }
}
