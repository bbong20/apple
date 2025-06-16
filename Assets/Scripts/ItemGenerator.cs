using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject pApplePrefab; // ��� ������
    public GameObject pBombPrefab;  // ��ź ������
    public GameObject pGoldApplePrefab; //Ȳ�ݻ�� ������

    float fSpawnTime = 1.0f;  // ������ ���� ����
    float fSpawnTimer = 0.0f; // ���� ������ �����ϴ� Ÿ�̸�
    int iRadioItem = 2;       // ������ ���� Ȯ�� ���ذ�
    int nGoldApple = 10;        //Ȳ�ݻ�� ��������
    float fSpeed = -0.03f;    // ������ ���� �ӵ�

    bool bCanGenerate = true; // ������ ���� ���� ���θ� �Ǵ��ϴ� �÷���

    void Update()
    {
        if (!bCanGenerate) return; // ������ ��Ȱ��ȭ�� ��� �Լ� �ߴ�

        this.fSpawnTimer += Time.deltaTime; // Ÿ�̸� ��� �ð� ����

        if (this.fSpawnTimer >= this.fSpawnTime) // ������ ���� ������ ������
        {
            this.fSpawnTimer = 0.0f; // Ÿ�̸� �ʱ�ȭ

            float fDropX = Random.Range(-1, 2); // X�� ���� ��ġ (-1, 0, 1 �� �ϳ�)
            float fDropZ = Random.Range(-1, 2); // Z�� ���� ��ġ (-1, 0, 1 �� �ϳ�)

            GameObject gItem;
            int nDice = Random.Range(1, 11); // 1~10 ������ ���� ���� ����

            if (nDice == nGoldApple)
            {
                gItem = Instantiate(pGoldApplePrefab);  //Ȳ�� ��� ������ ����
            }
            else if (nDice > iRadioItem) // ������ ���غ��� ũ�� ��� ����
            {
                gItem = Instantiate(pApplePrefab); // ��� ������ ����
            }
            
            else // ���� ������ ��� ��ź ����
            {
                gItem = Instantiate(pBombPrefab); // ��ź ������ ����
            }

            gItem.transform.position = new Vector3(fDropX, 4, fDropZ); // ������ ��ġ ����
            gItem.GetComponent<ItemController>().fItemDropSpeed = this.fSpeed; // ������ ���� �ӵ� ����
        }
    }

    public void SetParameter(float fSpawnTime, float fSpeed, int iRadioItem)
    {
        this.fSpawnTime = fSpawnTime;   // ���� ���� ����
        this.fSpeed = fSpeed;           // ���� �ӵ� ����
        this.iRadioItem = iRadioItem;   // ������ ���� Ȯ�� ���� ����
    }

    public void StopGenerating()
    {
        this.bCanGenerate = false; // ���� �÷��׸� false�� �����Ͽ� ���� ����
    }
}
