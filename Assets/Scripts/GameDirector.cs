using UnityEngine;                                       // Unity ���� Ŭ���� ���
using TMPro;                                             // TextMeshPro�� ����ϱ� ���� �ʿ�
using UnityEngine.SceneManagement;                       // �� ��ȯ�� ���� �ʿ�

public class GameDirector : MonoBehaviour                // GameDirector Ŭ������ MonoBehaviour ���
{
    GameObject gTimerText;                               // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    GameObject gPointText;                               // ���� ������ ǥ���� �ؽ�Ʈ ������Ʈ
    GameObject gGenerator;                               // �������� �����ϴ� ������Ʈ

    float fTimer = 10.0f;                                // ���� ���� �ð� (��)
    float fGameTime = 10.0f;                             // ��ü ���� �ð� (����ȭ ����)
    int nPoint = 0;                                      // ���� ����
    bool bStopped = false;                               // �ߺ� ���� ������ ���� �÷���

    public static int nFinalPoint = 0;                   // ��� ���� ������ ������ �����ϴ� static ����

    void Start()                                         // ������ ���۵� �� �� �� ȣ��Ǵ� �Լ�
    {
        this.gTimerText = GameObject.Find("Timer");      // "Timer" ������Ʈ�� ã�Ƽ� ������ ����
        this.gPointText = GameObject.Find("Point");      // "Point" ������Ʈ�� ã�Ƽ� ������ ����
        this.gGenerator = GameObject.Find("ItemGenerator"); // "ItemGenerator" ������Ʈ�� ����
    }

    void Update()                                        // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    {
        fTimer -= Time.deltaTime;                        // �ð� ���� (������ �ð���ŭ)

        if (fTimer <= 0.0f)                               // �ð��� 0 ���ϰ� �Ǹ�
        {
            fTimer = 0.0f;                                // Ÿ�̸Ӹ� 0���� ����

            if (!bStopped)                                // �ߺ� ���� ������ ����
            {
                gGenerator.GetComponent<ItemGenerator>().StopGenerating(); // ������ ���� ����
                bStopped = true;                          // �ߺ� ���� �÷��� ����

                nFinalPoint = nPoint;                     // ���� ������ static ������ ����
                Debug.Log(nFinalPoint);
                SceneManager.LoadScene("ResultScene");    // ��� ������ ��ȯ
                Debug.Log("Ÿ�̸� ��! �� ��ȯ �õ�");      // ����� �޽��� ���
            }
        }

        float fNormalizedTime = fTimer / fGameTime;       // ���� �ð� ���� ��� (0 ~ 1)

        float fInterval = Mathf.Lerp(0.2f, 1.2f, fNormalizedTime);  // �ð� ���ҿ� ���� ���� ���� �پ��
        float fSpeed = Mathf.Lerp(-0.1f, -0.02f, fNormalizedTime);  // �ð� ���ҿ� ���� ���� �ӵ� ����
        int iRadioItem = Mathf.RoundToInt(Mathf.Lerp(8, 2, 1 - fNormalizedTime)); // ��ź ���� Ȯ�� ����

        gGenerator.GetComponent<ItemGenerator>().SetParameter(fInterval, fSpeed, iRadioItem); // ������ ���� ����

        gTimerText.GetComponent<TextMeshProUGUI>().text = fTimer.ToString("F1"); // ���� �ð� �ؽ�Ʈ�� ǥ��
        gPointText.GetComponent<TextMeshProUGUI>().text = nPoint.ToString() + " point"; // ���� �ؽ�Ʈ�� ǥ��
    }

    public void GetApple()                               // ����� �Ծ��� �� ���� ���� �Լ�
    {
        this.nPoint += 10;                               // ���� 10�� ����
    }

    public void GetBomb()                                // ��ź�� �Ծ��� �� ���� ���� �Լ�
    {
        this.nPoint /= 2;                                // ���� ���� ����
    }

    public void GetGoldApple()
    {
        this.nPoint += 50;
    }
}
