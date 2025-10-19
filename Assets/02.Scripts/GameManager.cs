using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;




public class GameManager : MonoBehaviour
{
    // �پ��� ���� ������Ʈ ���� ������ ���� �����鼭 ������ manage�ϴ� ��ũ��Ʈ

    //��Ÿ ���� ����
    public static GameManager Instance; // ���ӸŴ����� �� ������Ʈ ��𿡼����� �����ϰ� �ϱ����ؼ� static���� ��ȯ
    public bool isDead = false; // ������ ������ �˾ƺ��� ���� ó���� ���� �ʾ����� false
    public bool isReady = true; // ó�� ���� �ÿ� ������ ���۵��� �ʰ� �غ� ȭ���� ���̰� �ϱ����ؼ� ó���� �غ� ���̴� true
    public int mainScore = 0; // ���� ȭ���� �߾ӿ� ���̴� ���ھ� ����
    public float pipeCreate = 1.5f; // �������� �����ɶ� ���� �Ǵ½ð�

    // ���� ������Ʈ ����
    public GameObject Pipe; // ������ ������
    public GameObject Title_Penal; // ó�� Ÿ��Ʋ �̹��� �г�
    public GameObject GameOver_Penal; // �������� ������ �̹��� �г�

    // ���� ����
    public AudioClip PassSound; // ��������� ����
    public AudioClip DeadSound; // �׾����� ����

    // �ؽ�Ʈ ����
    public TextMeshProUGUI mainScore_text; // ���� ȭ���� ��� �ؽ�Ʈ
    public TextMeshProUGUI FinalScore_text; // ������ �������� ���ھ�
    public TextMeshProUGUI BestScore_text; // ���� ���� �ְ�����


    void Start()
    {
        Instance = this; // �Ŵ����� �� ������Ʈ�� ���� ������Ʈ�� ����Ű�� �س���
        GameOver_Penal.SetActive(false); // ���ӿ����� �׾�߸� �������� �Ѵ�
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isReady.Equals(true))
        {
            InvokeRepeating("MakePipe", 1f, pipeCreate); // MakePipe��� �Լ��� �����Ѵ�

            Title_Penal.SetActive(false);
            isReady = false;
            Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true; // ���� �߷��� Ȱ��ȭ �����ش�
        }
    }

    void MakePipe()
    {
        // ������Ʈ �������� y�� �������� ȸ���� ���� ������Ų��
        Instantiate(Pipe, new Vector3(6.0f, Random.Range(-1.6f, 0.8f), 0f),Quaternion.identity);
    }

    public void GameOver()
    {
        isDead = true;
        CancelInvoke("MakePipe");
        GetComponent<AudioSource>().clip = DeadSound;
        GetComponent<AudioSource>().Play();

        if(mainScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", mainScore);
        }

        FinalScore_text.text = mainScore.ToString();
        BestScore_text.text = PlayerPrefs.GetInt("BestScore").ToString();

        GameOver_Penal.SetActive(true);
    }

    public void GetScore()
    {
        mainScore += 1;
        mainScore_text.text = mainScore.ToString();
        GetComponent<AudioSource>().clip = PassSound;
        GetComponent<AudioSource>().Play();
    }    

    public void Restart()
    {
        SceneManager.LoadScene("Play");
    }
}
