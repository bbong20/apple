using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public GameObject tutorialimage; // 튜토리얼 이미지 오브젝트
    public GameObject tutorialquit; // 튜토리얼 종료 버튼 오브젝트

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene"); // 타이틀 씬으로 이동
        Debug.Log("타이틀 씬으로 이동"); // 디버그 로그 출력
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene"); // 메뉴 씬으로 이동
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene"); // 게임 씬으로 이동
    }

    public void GoToResult()
    {
        SceneManager.LoadScene("ResultScene"); // 결과 씬으로 이동
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ShowTutorial()
    {
        tutorialimage.SetActive(true); // 튜토리얼 이미지 활성화
        tutorialquit.SetActive(true); // 튜토리얼 종료 버튼 활성화
    }

    public void HideTutorial()
    {
        tutorialimage.SetActive(false); // 튜토리얼 이미지 비활성화
        tutorialquit.SetActive(false); // 튜토리얼 종료 버튼 비활성화
    }
}
