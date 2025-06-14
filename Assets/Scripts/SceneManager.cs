using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public GameObject tutorialimage; // Ʃ�丮�� �̹��� ������Ʈ
    public GameObject tutorialquit; // Ʃ�丮�� ���� ��ư ������Ʈ

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
        SceneManager.LoadScene("TitleScene"); // Ÿ��Ʋ ������ �̵�
        Debug.Log("Ÿ��Ʋ ������ �̵�"); // ����� �α� ���
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene"); // �޴� ������ �̵�
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene"); // ���� ������ �̵�
    }

    public void GoToResult()
    {
        SceneManager.LoadScene("ResultScene"); // ��� ������ �̵�
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ShowTutorial()
    {
        tutorialimage.SetActive(true); // Ʃ�丮�� �̹��� Ȱ��ȭ
        tutorialquit.SetActive(true); // Ʃ�丮�� ���� ��ư Ȱ��ȭ
    }

    public void HideTutorial()
    {
        tutorialimage.SetActive(false); // Ʃ�丮�� �̹��� ��Ȱ��ȭ
        tutorialquit.SetActive(false); // Ʃ�丮�� ���� ��ư ��Ȱ��ȭ
    }
}
