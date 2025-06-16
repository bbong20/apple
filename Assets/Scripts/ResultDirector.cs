using UnityEngine;                                                 // Unity 기본 API 사용
using TMPro;                                                       // TextMeshPro 컴포넌트 사용을 위해 추가

public class ResultDirector : MonoBehaviour                        // ResultDirector 클래스는 MonoBehaviour를 상속
{
    void Start() // 씬이 시작될 때 한 번 실행됨
    {
        GameObject gResultText = GameObject.Find("ResultPoint"); // 결과 점수를 표시할 텍스트 오브젝트 찾기
        gResultText.GetComponent<TextMeshProUGUI>().text = GameDirector.nFinalPoint.ToString() + " point"; // 최종 점수 출력

        string difficulty = PlayerPrefs.GetString("Difficulty", "Easy"); // 저장된 난이도 값 불러오기
        string key = difficulty + "_HighScore"; // 난이도에 따라 키 생성
        int highScore = PlayerPrefs.GetInt(key, 0); // 저장된 최고 점수 불러오기

        GameObject gHighScoreText = GameObject.Find("HighScoreText"); // 최고 점수 출력용 텍스트 오브젝트 찾기
        gHighScoreText.GetComponent<TextMeshProUGUI>().text = "High Score (" + difficulty + "): " + highScore + " point"; // 최고 점수 출력
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
