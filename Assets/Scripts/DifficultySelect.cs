using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelect : MonoBehaviour
{
    // Easy ��带 �������� �� ȣ��Ǵ� �Լ�
    public void OnEasyMode()
    {
        // "Difficulty"��� Ű�� "Easy"��� ���ڿ� ���� (PlayerPrefs�� ���� �ٲ� ������)
        PlayerPrefs.SetString("Difficulty", "Easy");

        // GameScene�̶�� �̸��� ������ �̵�
        SceneManager.LoadScene("EasyGameScene");
    }

    // Hard ��带 �������� �� ȣ��Ǵ� �Լ�
    public void OnHardMode()
    {
        // ���̵��� "Hard"�� ����
        PlayerPrefs.SetString("Difficulty", "Hard");

        // GameScene �� �ε�
        SceneManager.LoadScene("GameScene");
    }
}
    