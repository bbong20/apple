using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float fItemDropSpeed = -0.03f; // ������ ���� �ӵ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, this.fItemDropSpeed, 0); // ������ ����
        if (transform.position.y < -1.0f) // �������� ȭ�� ������ ������
        {
            Destroy(gameObject); // ������ ����
        }
    }
}