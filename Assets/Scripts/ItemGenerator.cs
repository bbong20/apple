using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject pApplePrefab; // 사과 프리팹
    public GameObject pBombPrefab;  // 폭탄 프리팹
    public GameObject pGoldApplePrefab; //황금사과 프리팹

    float fSpawnTime = 1.0f;  // 아이템 생성 간격
    float fSpawnTimer = 0.0f; // 생성 간격을 측정하는 타이머
    int iRadioItem = 2;       // 아이템 생성 확률 기준값
    int nGoldApple = 10;        //황금사과 생성조건
    float fSpeed = -0.03f;    // 아이템 낙하 속도

    bool bCanGenerate = true; // 아이템 생성 가능 여부를 판단하는 플래그

    void Update()
    {
        if (!bCanGenerate) return; // 생성이 비활성화된 경우 함수 중단

        this.fSpawnTimer += Time.deltaTime; // 타이머 경과 시간 누적

        if (this.fSpawnTimer >= this.fSpawnTime) // 설정된 생성 간격이 지나면
        {
            this.fSpawnTimer = 0.0f; // 타이머 초기화

            float fDropX = Random.Range(-1, 2); // X축 랜덤 위치 (-1, 0, 1 중 하나)
            float fDropZ = Random.Range(-1, 2); // Z축 랜덤 위치 (-1, 0, 1 중 하나)

            GameObject gItem;
            int nDice = Random.Range(1, 11); // 1~10 사이의 랜덤 숫자 생성

            if (nDice == nGoldApple)
            {
                gItem = Instantiate(pGoldApplePrefab);  //황금 사과 프리팹 생성
            }
            else if (nDice > iRadioItem) // 설정된 기준보다 크면 사과 생성
            {
                gItem = Instantiate(pApplePrefab); // 사과 프리팹 생성
            }
            
            else // 기준 이하일 경우 폭탄 생성
            {
                gItem = Instantiate(pBombPrefab); // 폭탄 프리팹 생성
            }

            gItem.transform.position = new Vector3(fDropX, 4, fDropZ); // 아이템 위치 설정
            gItem.GetComponent<ItemController>().fItemDropSpeed = this.fSpeed; // 아이템 낙하 속도 설정
        }
    }

    public void SetParameter(float fSpawnTime, float fSpeed, int iRadioItem)
    {
        this.fSpawnTime = fSpawnTime;   // 생성 간격 설정
        this.fSpeed = fSpeed;           // 낙하 속도 설정
        this.iRadioItem = iRadioItem;   // 아이템 생성 확률 기준 설정
    }

    public void StopGenerating()
    {
        this.bCanGenerate = false; // 생성 플래그를 false로 설정하여 생성 중지
    }
}
