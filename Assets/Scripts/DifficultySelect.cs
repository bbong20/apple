using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelect : MonoBehaviour
{
    // Easy 모드를 선택했을 때 호출되는 함수
    public void OnEasyMode()
    {
        // "Difficulty"라는 키에 "Easy"라는 문자열 저장 (PlayerPrefs는 씬이 바뀌어도 유지됨)
        PlayerPrefs.SetString("Difficulty", "Easy");

        // GameScene이라는 이름의 씬으로 이동
        SceneManager.LoadScene("EasyGameScene");
    }

    // Hard 모드를 선택했을 때 호출되는 함수
    public void OnHardMode()
    {
        // 난이도를 "Hard"로 저장
        PlayerPrefs.SetString("Difficulty", "Hard");

        // GameScene 씬 로드
        SceneManager.LoadScene("GameScene");
    }
}
    