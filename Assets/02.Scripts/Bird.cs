using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird bird;
    public float birdJumpForce = 400.0f; // ���� ���� �ϴ� ��

    public Vector3 lookDirection; // ���� ��� �����ϴ��� �����ֱ� ���ؼ�
    public GameObject birdimg;    // ������ �� �̹���(��� ��������)

    void Start()
    {
        bird = this;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.transform.position.y <= 5f) // y���� 5���� �۰� ���콺�� ��������
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); // �ӵ��� 0���� ����
            this.gameObject.GetComponent<Rigidbody>().AddForce(0f, birdJumpForce, 0f); // ������ birdjump��ŭ ��Ų��
            GetComponent<AudioSource>().Play(); // �Ҹ��� ����
        }

        // y���� �ӵ��� �����ϸ� y���� �Ǽ� ���� ����,�ݴ밡 �Ǹ� y���� -�� �Ǿ� �Ʒ�������
        lookDirection.z = GetComponent<Rigidbody>().velocity.y * 10f + 20f;

        Quaternion R = Quaternion.Euler(lookDirection); // z�� �߽����� z�� ȸ������ ��ȯ
        birdimg.transform.rotation = Quaternion.RotateTowards(birdimg.transform.rotation, R, 5f);
    }
}
