using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        // �� ��ũ��Ʈ�� �پ��ִ� ���� ������Ʈ�� ���� ��ǥ���� �������� ��� �������ش�.
        this.gameObject.transform.position = new Vector3(this.transform.position.x - moveSpeed * Time.deltaTime,
                                                         this.transform.position.y,
                                                         this.transform.position.z);
        if (this.gameObject.transform.position.x < -5f) // �� ���� ������Ʈ�� ��ǥ�� -5���� �۰ų� ������
        {
            Destroy(this.gameObject); // �� ���� ������Ʈ�� ����
        }
    }
}
