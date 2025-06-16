using UnityEngine;                                       // Unity 관련 클래스 사용
using TMPro;                                             // TextMeshPro를 사용하기 위해 필요
using UnityEngine.SceneManagement;                       // 씬 전환을 위해 필요

public class GameDirector : MonoBehaviour                // GameDirector 클래스는 MonoBehaviour 상속
{
    GameObject gTimerText;                               // 남은 시간을 표시할 텍스트 오브젝트
    GameObject gPointText;                               // 현재 점수를 표시할 텍스트 오브젝트
    GameObject gGenerator;                               // 아이템을 생성하는 오브젝트

    float fTimer = 10.0f;                                // 현재 남은 시간 (초)
    float fGameTime = 10.0f;                             // 전체 게임 시간 (정규화 기준)
    int nPoint = 0;                                      // 현재 점수
    bool bStopped = false;                               // 중복 실행 방지를 위한 플래그

    public static int nFinalPoint = 0;                   // 결과 씬에 전달할 점수를 저장하는 static 변수

    void Start()                                         // 게임이 시작될 때 한 번 호출되는 함수
    {
        this.gTimerText = GameObject.Find("Timer");      // "Timer" 오브젝트를 찾아서 변수에 저장
        this.gPointText = GameObject.Find("Point");      // "Point" 오브젝트를 찾아서 변수에 저장
        this.gGenerator = GameObject.Find("ItemGenerator"); // "ItemGenerator" 오브젝트를 저장
    }

    void Update()                                        // 매 프레임마다 호출되는 함수
    {
        fTimer -= Time.deltaTime;                        // 시간 감소 (프레임 시간만큼)

        if (fTimer <= 0.0f)                               // 시간이 0 이하가 되면
        {
            fTimer = 0.0f;                                // 타이머를 0으로 고정

            if (!bStopped)                                // 중복 실행 방지를 위해
            {
                gGenerator.GetComponent<ItemGenerator>().StopGenerating(); // 아이템 생성 중지
                bStopped = true;                          // 중복 방지 플래그 설정

                nFinalPoint = nPoint;                     // 최종 점수를 static 변수에 저장
                Debug.Log(nFinalPoint);
                SceneManager.LoadScene("ResultScene");    // 결과 씬으로 전환
                Debug.Log("타이머 끝! 씬 전환 시도");      // 디버그 메시지 출력
            }
        }

        float fNormalizedTime = fTimer / fGameTime;       // 현재 시간 비율 계산 (0 ~ 1)

        float fInterval = Mathf.Lerp(0.2f, 1.2f, fNormalizedTime);  // 시간 감소에 따라 생성 간격 줄어듦
        float fSpeed = Mathf.Lerp(-0.1f, -0.02f, fNormalizedTime);  // 시간 감소에 따라 낙하 속도 증가
        int iRadioItem = Mathf.RoundToInt(Mathf.Lerp(8, 2, 1 - fNormalizedTime)); // 폭탄 등장 확률 증가

        gGenerator.GetComponent<ItemGenerator>().SetParameter(fInterval, fSpeed, iRadioItem); // 아이템 설정 전달

        gTimerText.GetComponent<TextMeshProUGUI>().text = fTimer.ToString("F1"); // 남은 시간 텍스트로 표시
        gPointText.GetComponent<TextMeshProUGUI>().text = nPoint.ToString() + " point"; // 점수 텍스트로 표시
    }

    public void GetApple()                               // 사과를 먹었을 때 점수 증가 함수
    {
        this.nPoint += 10;                               // 점수 10점 증가
    }

    public void GetBomb()                                // 폭탄을 먹었을 때 점수 감소 함수
    {
        this.nPoint /= 2;                                // 점수 절반 감소
    }

    public void GetGoldApple()
    {
        this.nPoint += 50;
    }
}
