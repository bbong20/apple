using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject gTimerText;   // 타이머 텍스트를 표시하는 TextMeshPro 오브젝트
    GameObject gPointText;   // 점수 텍스트를 표시하는 TextMeshPro 오브젝트
    GameObject gGenerator;   // 아이템 생성기를 제어할 오브젝트

    float fTimer = 60.0f;    // 총 게임 시간 (초 단위)
    int nPoint = 0;          // 현재 점수
    bool bStopped = false;   // StopGenerating 및 씬 전환 중복 방지를 위한 플래그

    string sDifficulty = "Easy"; // 현재 난이도 설정값 (기본은 Easy)

    void Start()
    {
        // 이름으로 UI와 오브젝트들을 찾아서 연결
        gTimerText = GameObject.Find("Timer");
        gPointText = GameObject.Find("Point");
        gGenerator = GameObject.Find("ItemGenerator");

        // 이전 씬에서 저장된 난이도 값을 가져옴 (없으면 기본값 "Easy")
        sDifficulty = PlayerPrefs.GetString("Difficulty", "Easy");
    }

    void Update()
    {
        // 매 프레임마다 타이머 감소
        fTimer -= Time.deltaTime;

        // 타이머가 0 이하일 때
        if (fTimer <= 0.0f && !bStopped)
        {
            fTimer = 0.0f;

            // 아이템 생성 중단
            gGenerator.GetComponent<ItemGenerator>().StopGenerating();

            // 씬 전환 방지 플래그 설정
            bStopped = true;

            // 결과 씬으로 전환
            SceneManager.LoadScene("ResultScene");
        }

        // 남은 시간을 0~1 사이의 정규화된 값으로 계산
        float fNormalizedTime = fTimer / 60.0f;

        // 현재 난이도가 Easy일 경우
        if (sDifficulty == "Easy")
        {
            // Easy 모드일 땐 변화량이 작고 속도도 느림
            float fInterval = Mathf.Lerp(1.2f, 0.8f, 1 - fNormalizedTime);          // 생성 간격
            float fSpeed = Mathf.Lerp(-0.03f, -0.05f, 1 - fNormalizedTime);         // 낙하 속도
            int iRadioItem = Mathf.RoundToInt(Mathf.Lerp(2, 4, 1 - fNormalizedTime)); // 폭탄 확률 기준값

            // 아이템 생성기 파라미터 적용
            gGenerator.GetComponent<ItemGenerator>().SetParameter(fInterval, fSpeed, iRadioItem);
        }
        else // Hard 모드일 경우
        {
            // Hard 모드일 땐 아이템이 빠르게 떨어지고, 간격도 짧으며, 폭탄 확률도 높음
            float fInterval = Mathf.Lerp(1.0f, 0.2f, 1 - fNormalizedTime);          // 생성 간격이 점점 줄어듦
            float fSpeed = Mathf.Lerp(-0.04f, -0.12f, 1 - fNormalizedTime);         // 낙하 속도 빨라짐
            int iRadioItem = Mathf.RoundToInt(Mathf.Lerp(4, 8, 1 - fNormalizedTime)); // 폭탄 확률 기준값 증가

            // 설정 적용
            gGenerator.GetComponent<ItemGenerator>().SetParameter(fInterval, fSpeed, iRadioItem);
        }

        // 텍스트 UI에 타이머와 점수 반영
        gTimerText.GetComponent<TextMeshProUGUI>().text = fTimer.ToString("F1");
        gPointText.GetComponent<TextMeshProUGUI>().text = nPoint.ToString() + " point";
    }

    // 사과를 획득했을 때 호출되는 함수 (점수 +10)
    public void GetApple()
    {
        nPoint += 10;
    }

    // 폭탄을 획득했을 때 호출되는 함수 (점수 절반으로 감소)
    public void GetBomb()
    {
        nPoint /= 2;
    }
}
