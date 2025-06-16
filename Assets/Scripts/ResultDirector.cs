using UnityEngine;                                                 // Unity �⺻ API ���
using TMPro;                                                       // TextMeshPro ������Ʈ ����� ���� �߰�

public class ResultDirector : MonoBehaviour                        // ResultDirector Ŭ������ MonoBehaviour�� ���
{
    void Start() // ���� ���۵� �� �� �� �����
    {
        GameObject gResultText = GameObject.Find("ResultPoint"); // ��� ������ ǥ���� �ؽ�Ʈ ������Ʈ ã��
        gResultText.GetComponent<TextMeshProUGUI>().text = GameDirector.nFinalPoint.ToString() + " point"; // ���� ���� ���

        string difficulty = PlayerPrefs.GetString("Difficulty", "Easy"); // ����� ���̵� �� �ҷ�����
        string key = difficulty + "_HighScore"; // ���̵��� ���� Ű ����
        int highScore = PlayerPrefs.GetInt(key, 0); // ����� �ְ� ���� �ҷ�����

        GameObject gHighScoreText = GameObject.Find("HighScoreText"); // �ְ� ���� ��¿� �ؽ�Ʈ ������Ʈ ã��
        gHighScoreText.GetComponent<TextMeshProUGUI>().text = "High Score (" + difficulty + "): " + highScore + " point"; // �ְ� ���� ���
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
