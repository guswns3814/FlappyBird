using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float mapSpeed; // ���� ���ư��� ���ǵ�
    private float mapOffset; // offset�� ���� �� ��

    void Update()
    {
        if (GameManager.Instance.isDead.Equals(false))
        { 
        // mapoffset�� ���� ���� ������ mapspeed�� �ð��� �帧�� ���� ���ؼ� ���Ѵ�
        mapOffset += Time.deltaTime * mapSpeed;

        // �� ��ũ��Ʈ�� ���� ���� ������Ʈ�� ������ ���� x�� �����Ѵ�
        this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(mapOffset, 0);
        }
    }
}
