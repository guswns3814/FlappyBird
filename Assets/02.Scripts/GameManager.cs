using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;




public class GameManager : MonoBehaviour
{
    // 다양한 게임 오브젝트 들의 정보를 갖고 있으면서 게임을 manage하는 스크립트

    //기타 변수 관련
    public static GameManager Instance; // 게임매니저를 이 프로젝트 어디에서든지 접근하게 하기위해서 static으로 전환
    public bool isDead = false; // 게임이 끝났나 알아보기 위해 처음엔 죽지 않았으니 false
    public bool isReady = true; // 처음 시작 시에 게임이 시작되지 않고 준비 화면을 보이게 하기위해서 처음엔 준비 중이니 true
    public int mainScore = 0; // 게임 화면의 중앙에 보이는 스코어 점수
    public float pipeCreate = 1.5f; // 파이프가 생성될때 텀이 되는시간

    // 게임 오브젝트 관련
    public GameObject Pipe; // 파이프 프리펩
    public GameObject Title_Penal; // 처음 타이틀 이미지 패널
    public GameObject GameOver_Penal; // 끝났을때 윈도우 이미지 패널

    // 사운드 관련
    public AudioClip PassSound; // 통과했을때 사운드
    public AudioClip DeadSound; // 죽었을때 사운드

    // 텍스트 관련
    public TextMeshProUGUI mainScore_text; // 게임 화면의 가운데 텍스트
    public TextMeshProUGUI FinalScore_text; // 게임이 끝났을때 스코어
    public TextMeshProUGUI BestScore_text; // 나의 역대 최고점수


    void Start()
    {
        Instance = this; // 매니저의 이 컴포넌트가 붙은 오브젝트를 가리키게 해놓고
        GameOver_Penal.SetActive(false); // 게임오버도 죽어야만 보여져야 한다
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isReady.Equals(true))
        {
            InvokeRepeating("MakePipe", 1f, pipeCreate); // MakePipe라는 함수를 실행한다

            Title_Penal.SetActive(false);
            isReady = false;
            Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true; // 새의 중력을 활성화 시켜준다
        }
    }

    void MakePipe()
    {
        // 오브젝트 파이프를 y값 랜덤에게 회전값 없이 생성시킨다
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
