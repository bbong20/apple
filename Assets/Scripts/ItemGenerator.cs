using UnityEngine; // Unity 관련 기능 사용을 위한 네임스페이스 포함

public class ItemGenerator : MonoBehaviour // ItemGenerator 클래스는 MonoBehaviour를 상속받아 유니티에서 사용 가능
{
    public GameObject pApplePrefab;           // 사과 프리팹 (아이템 생성에 사용됨)
    public GameObject pBombPrefab;            // 폭탄 프리팹 (위험 요소)
    public GameObject pGoldApplePrefab;       // 황금 사과 프리팹 (특별한 보너스 아이템)

    float fSpawnTime = 1.0f;                  // 아이템이 생성되는 간격 (초 단위)
    float fSpawnTimer = 0.0f;                 // 경과 시간을 저장하는 타이머
    int iRadioItem = 2;                       // 아이템 생성 확률 기준값 (2 이하이면 폭탄 생성)
    int nGoldApple = 10;                      // 황금 사과가 나오는 주사위 값 (10일 때 생성)
    float fSpeed = -0.03f;                    // 아이템 낙하 속도 (음수일수록 빠름)

    bool bCanGenerate = true;                 // 아이템 생성 가능 여부를 제어하는 플래그

    public int nRangeX = 1;                   // X축 생성 범위 절반 (예: 1이면 -1~1)
    public int nRangeZ = 1;                   // Z축 생성 범위 절반

    void Start()                              // 게임 시작 시 호출되는 초기화 함수
    {
        string sSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name; // 현재 씬 이름을 가져옴

        if (sSceneName == "EasyGameScene")    // 하드 모드 씬일 경우
        {
            nRangeX = 1;                      // -3 ~ 3 (7칸) 범위로 설정
            nRangeZ = 1;
        }
        else                                  // 이지 모드 또는 기본 모드일 경우
        {
            nRangeX = 3;                      // -1 ~ 1 (3칸) 범위로 설정
            nRangeZ = 3;
        }
    }

    void Update()                             // 매 프레임마다 호출되는 함수
    {
        if (!bCanGenerate) return;            // 생성이 비활성화되어 있으면 즉시 리턴

        fSpawnTimer += Time.deltaTime;        // 타이머에 경과 시간 추가

        if (fSpawnTimer >= fSpawnTime)        // 생성 주기가 도달했을 경우
        {
            fSpawnTimer = 0.0f;               // 타이머 초기화

            float fDropX = Random.Range(-nRangeX, nRangeX + 1); // X축 위치를 범위 내에서 랜덤 설정
            float fDropZ = Random.Range(-nRangeZ, nRangeZ + 1); // Z축 위치를 범위 내에서 랜덤 설정

            GameObject gItem;                 // 생성할 아이템 오브젝트 선언
            int nDice = Random.Range(1, 11);  // 1부터 10 사이의 정수 랜덤 생성

            if (nDice == nGoldApple)          // 주사위 값이 10이면 황금 사과 생성
            {
                gItem = Instantiate(pGoldApplePrefab); // 황금 사과 프리팹을 인스턴스화
            }
            else if (nDice > iRadioItem)      // 기준값보다 크면 일반 사과 생성
            {
                gItem = Instantiate(pApplePrefab);     // 사과 프리팹을 인스턴스화
            }
            else                              // 그 외에는 폭탄 생성
            {
                gItem = Instantiate(pBombPrefab);      // 폭탄 프리팹을 인스턴스화
            }

            gItem.transform.position = new Vector3(fDropX, 4, fDropZ); // 생성된 아이템의 위치를 설정
            gItem.GetComponent<ItemController>().fItemDropSpeed = this.fSpeed; // 해당 아이템의 낙하 속도를 설정
        }
    }

    public void SetParameter(float fSpawnTime, float fSpeed, int iRadioItem) // 외부에서 난이도에 따라 설정값을 전달받는 함수
    {
        this.fSpawnTime = fSpawnTime;     // 생성 주기 설정
        this.fSpeed = fSpeed;             // 낙하 속도 설정
        this.iRadioItem = iRadioItem;     // 확률 기준값 설정
    }

    public void StopGenerating()          // 아이템 생성을 중단하는 함수
    {
        this.bCanGenerate = false;        // 생성 가능 여부를 false로 설정
    }
}
