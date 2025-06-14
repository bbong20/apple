using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject gTimerText;   // Ÿ�̸� �ؽ�Ʈ�� ǥ���ϴ� TextMeshPro ������Ʈ
    GameObject gPointText;   // ���� �ؽ�Ʈ�� ǥ���ϴ� TextMeshPro ������Ʈ
    GameObject gGenerator;   // ������ �����⸦ ������ ������Ʈ

    float fTimer = 60.0f;    // �� ���� �ð� (�� ����)
    int nPoint = 0;          // ���� ����
    bool bStopped = false;   // StopGenerating �� �� ��ȯ �ߺ� ������ ���� �÷���

    string sDifficulty = "Easy"; // ���� ���̵� ������ (�⺻�� Easy)

    void Start()
    {
        // �̸����� UI�� ������Ʈ���� ã�Ƽ� ����
        gTimerText = GameObject.Find("Timer");
        gPointText = GameObject.Find("Point");
        gGenerator = GameObject.Find("ItemGenerator");

        // ���� ������ ����� ���̵� ���� ������ (������ �⺻�� "Easy")
        sDifficulty = PlayerPrefs.GetString("Difficulty", "Easy");
    }

    void Update()
    {
        // �� �����Ӹ��� Ÿ�̸� ����
        fTimer -= Time.deltaTime;

        // Ÿ�̸Ӱ� 0 ������ ��
        if (fTimer <= 0.0f && !bStopped)
        {
            fTimer = 0.0f;

            // ������ ���� �ߴ�
            gGenerator.GetComponent<ItemGenerator>().StopGenerating();

            // �� ��ȯ ���� �÷��� ����
            bStopped = true;

            // ��� ������ ��ȯ
            SceneManager.LoadScene("ResultScene");
        }

        // ���� �ð��� 0~1 ������ ����ȭ�� ������ ���
        float fNormalizedTime = fTimer / 60.0f;

        // ���� ���̵��� Easy�� ���
        if (sDifficulty == "Easy")
        {
            // Easy ����� �� ��ȭ���� �۰� �ӵ��� ����
            float fInterval = Mathf.Lerp(1.2f, 0.8f, 1 - fNormalizedTime);          // ���� ����
            float fSpeed = Mathf.Lerp(-0.03f, -0.05f, 1 - fNormalizedTime);         // ���� �ӵ�
            int iRadioItem = Mathf.RoundToInt(Mathf.Lerp(2, 4, 1 - fNormalizedTime)); // ��ź Ȯ�� ���ذ�

            // ������ ������ �Ķ���� ����
            gGenerator.GetComponent<ItemGenerator>().SetParameter(fInterval, fSpeed, iRadioItem);
        }
        else // Hard ����� ���
        {
            // Hard ����� �� �������� ������ ��������, ���ݵ� ª����, ��ź Ȯ���� ����
            float fInterval = Mathf.Lerp(1.0f, 0.2f, 1 - fNormalizedTime);          // ���� ������ ���� �پ��
            float fSpeed = Mathf.Lerp(-0.04f, -0.12f, 1 - fNormalizedTime);         // ���� �ӵ� ������
            int iRadioItem = Mathf.RoundToInt(Mathf.Lerp(4, 8, 1 - fNormalizedTime)); // ��ź Ȯ�� ���ذ� ����

            // ���� ����
            gGenerator.GetComponent<ItemGenerator>().SetParameter(fInterval, fSpeed, iRadioItem);
        }

        // �ؽ�Ʈ UI�� Ÿ�̸ӿ� ���� �ݿ�
        gTimerText.GetComponent<TextMeshProUGUI>().text = fTimer.ToString("F1");
        gPointText.GetComponent<TextMeshProUGUI>().text = nPoint.ToString() + " point";
    }

    // ����� ȹ������ �� ȣ��Ǵ� �Լ� (���� +10)
    public void GetApple()
    {
        nPoint += 10;
    }

    // ��ź�� ȹ������ �� ȣ��Ǵ� �Լ� (���� �������� ����)
    public void GetBomb()
    {
        nPoint /= 2;
    }
}
