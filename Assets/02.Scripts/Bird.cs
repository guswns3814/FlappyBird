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
        if (GameManager.Instance.isDead.Equals(false))
        {
            if (Input.GetMouseButtonDown(0) && this.transform.position.y <= 5f) // y���� 5���� �۰� ���콺�� ��������
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); // �ӵ��� 0���� ����
                this.gameObject.GetComponent<Rigidbody>().AddForce(0f, birdJumpForce, 0f); // ������ birdjump��ŭ ��Ų��
                GetComponent<AudioSource>().Play(); // �Ҹ��� ����
            }

            if (GameManager.Instance.isReady.Equals(false))
            {
                lookDirection.z = GetComponent<Rigidbody>().velocity.y * 10f + 20f;
            }

            // y���� �ӵ��� �����ϸ� y���� �Ǽ� ���� ����,�ݴ밡 �Ǹ� y���� -�� �Ǿ� �Ʒ�������
            lookDirection.z = GetComponent<Rigidbody>().velocity.y * 10f + 20f;
        }
        Quaternion R = Quaternion.Euler(lookDirection); // z�� �߽����� z�� ȸ������ ��ȯ
        birdimg.transform.rotation = Quaternion.RotateTowards(birdimg.transform.rotation, R, 5f);
    }

    private void OnTriggerEnter(Collider Target)
    {
        if (Target.CompareTag("Die") && GameManager.Instance.isDead.Equals(false))
        {
            GameManager.Instance.GameOver();
            GetComponent<Rigidbody>().velocity = new Vector3(0, -3, 0);
            lookDirection = new Vector3(0, 0, -90f);
        }

        if (Target.CompareTag("Point") && GameManager.Instance.isDead.Equals(false))
        {
            GameManager.Instance.GetScore();
        }
    }

}
