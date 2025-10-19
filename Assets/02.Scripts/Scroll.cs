using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float mapSpeed; // 맵이 돌아가는 스피드
    private float mapOffset; // offset을 조정 할 값

    void Update()
    {
        if (GameManager.Instance.isDead.Equals(false))
        { 
        // mapoffset의 값에 내가 설정한 mapspeed를 시간의 흐름에 따라 곱해서 더한다
        mapOffset += Time.deltaTime * mapSpeed;

        // 이 스크립트가 붙은 게임 오브젝트의 오프셋 값에 x를 조정한다
        this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(mapOffset, 0);
        }
    }
}
