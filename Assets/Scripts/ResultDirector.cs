using UnityEngine;                                                 // Unity �⺻ API ���
using TMPro;                                                       // TextMeshPro ������Ʈ ����� ���� �߰�

public class ResultDirector : MonoBehaviour                        // ResultDirector Ŭ������ MonoBehaviour�� ���
{
    void Start()                                                   // ���� ���۵� �� �� �� �����
    {
        GameObject gResultText = GameObject.Find("ResultPoint");   // �̸��� "ResultPoint"�� ������Ʈ�� ã��
        Debug.Log(GameDirector.nFinalPoint);
        gResultText.GetComponent<TextMeshProUGUI>().text =         // �ش� ������Ʈ�� ����� �ؽ�Ʈ ������Ʈ�� �����ؼ�
            GameDirector.nFinalPoint.ToString() + " point";        // GameDirector���� ���޵� ������ ���ڿ��� ǥ��
    }



// Update is called once per frame
void Update()
    {
        
    }
}
