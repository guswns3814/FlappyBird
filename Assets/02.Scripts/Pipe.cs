using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        // 이 스크립트가 붙어있는 게임 오브젝트를 현재 좌표에서 왼쪽으로 계속 움직여준다.
        this.gameObject.transform.position = new Vector3(this.transform.position.x - moveSpeed * Time.deltaTime,
                                                         this.transform.position.y,
                                                         this.transform.position.z);
        if (this.gameObject.transform.position.x < -5f) // 이 게임 오브젝트의 좌표가 -5보다 작거나 같으면
        {
            Destroy(this.gameObject); // 이 게임 오브젝트는 삭제
        }
    }
}
