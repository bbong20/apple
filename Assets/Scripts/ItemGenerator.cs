using UnityEngine; // Unity ���� ��� ����� ���� ���ӽ����̽� ����

public class ItemGenerator : MonoBehaviour // ItemGenerator Ŭ������ MonoBehaviour�� ��ӹ޾� ����Ƽ���� ��� ����
{
    public GameObject pApplePrefab;           // ��� ������ (������ ������ ����)
    public GameObject pBombPrefab;            // ��ź ������ (���� ���)
    public GameObject pGoldApplePrefab;       // Ȳ�� ��� ������ (Ư���� ���ʽ� ������)

    float fSpawnTime = 1.0f;                  // �������� �����Ǵ� ���� (�� ����)
    float fSpawnTimer = 0.0f;                 // ��� �ð��� �����ϴ� Ÿ�̸�
    int iRadioItem = 2;                       // ������ ���� Ȯ�� ���ذ� (2 �����̸� ��ź ����)
    int nGoldApple = 10;                      // Ȳ�� ����� ������ �ֻ��� �� (10�� �� ����)
    float fSpeed = -0.03f;                    // ������ ���� �ӵ� (�����ϼ��� ����)

    bool bCanGenerate = true;                 // ������ ���� ���� ���θ� �����ϴ� �÷���

    public int nRangeX = 1;                   // X�� ���� ���� ���� (��: 1�̸� -1~1)
    public int nRangeZ = 1;                   // Z�� ���� ���� ����

    void Start()                              // ���� ���� �� ȣ��Ǵ� �ʱ�ȭ �Լ�
    {
        string sSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name; // ���� �� �̸��� ������

        if (sSceneName == "EasyGameScene")    // �ϵ� ��� ���� ���
        {
            nRangeX = 1;                      // -3 ~ 3 (7ĭ) ������ ����
            nRangeZ = 1;
        }
        else                                  // ���� ��� �Ǵ� �⺻ ����� ���
        {
            nRangeX = 3;                      // -1 ~ 1 (3ĭ) ������ ����
            nRangeZ = 3;
        }
    }

    void Update()                             // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    {
        if (!bCanGenerate) return;            // ������ ��Ȱ��ȭ�Ǿ� ������ ��� ����

        fSpawnTimer += Time.deltaTime;        // Ÿ�̸ӿ� ��� �ð� �߰�

        if (fSpawnTimer >= fSpawnTime)        // ���� �ֱⰡ �������� ���
        {
            fSpawnTimer = 0.0f;               // Ÿ�̸� �ʱ�ȭ

            float fDropX = Random.Range(-nRangeX, nRangeX + 1); // X�� ��ġ�� ���� ������ ���� ����
            float fDropZ = Random.Range(-nRangeZ, nRangeZ + 1); // Z�� ��ġ�� ���� ������ ���� ����

            GameObject gItem;                 // ������ ������ ������Ʈ ����
            int nDice = Random.Range(1, 11);  // 1���� 10 ������ ���� ���� ����

            if (nDice == nGoldApple)          // �ֻ��� ���� 10�̸� Ȳ�� ��� ����
            {
                gItem = Instantiate(pGoldApplePrefab); // Ȳ�� ��� �������� �ν��Ͻ�ȭ
            }
            else if (nDice > iRadioItem)      // ���ذ����� ũ�� �Ϲ� ��� ����
            {
                gItem = Instantiate(pApplePrefab);     // ��� �������� �ν��Ͻ�ȭ
            }
            else                              // �� �ܿ��� ��ź ����
            {
                gItem = Instantiate(pBombPrefab);      // ��ź �������� �ν��Ͻ�ȭ
            }

            gItem.transform.position = new Vector3(fDropX, 4, fDropZ); // ������ �������� ��ġ�� ����
            gItem.GetComponent<ItemController>().fItemDropSpeed = this.fSpeed; // �ش� �������� ���� �ӵ��� ����
        }
    }

    public void SetParameter(float fSpawnTime, float fSpeed, int iRadioItem) // �ܺο��� ���̵��� ���� �������� ���޹޴� �Լ�
    {
        this.fSpawnTime = fSpawnTime;     // ���� �ֱ� ����
        this.fSpeed = fSpeed;             // ���� �ӵ� ����
        this.iRadioItem = iRadioItem;     // Ȯ�� ���ذ� ����
    }

    public void StopGenerating()          // ������ ������ �ߴ��ϴ� �Լ�
    {
        this.bCanGenerate = false;        // ���� ���� ���θ� false�� ����
    }
}
