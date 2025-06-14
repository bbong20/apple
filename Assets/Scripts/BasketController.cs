using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;       // 사과 획득 사운드
    public AudioClip bombSE;        // 폭탄 획득 사운드
    AudioSource aud;                // 오디오 소스 컴포넌트
    GameObject gDirector; // 게임 디렉터 오브젝트


    void Start()
    {
        Application.targetFrameRate = 60; // 프레임을 60으로 고정
        this.aud = GetComponent<AudioSource>(); // 오디오 소스 컴포넌트 가져오기
        this.gDirector = GameObject.Find("GameDirector"); // "GameDirector"라는 이름의 게임 오브젝트 찾기
    }

    void OnTriggerEnter(Collider other) // 충돌 감지
    {
        if (other.gameObject.tag == "Apple") // 충돌한 오브젝트가 사과라면
        {
            this.aud.PlayOneShot(this.appleSE); // 사과 획득 사운드 재생
            this.gDirector.GetComponent<GameDirector>().GetApple(); // GameDirector의 GetApple 메소드 호출
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE); // 폭탄 획득 사운드 재생
            this.gDirector.GetComponent<GameDirector>().GetBomb(); // GameDirector의 GetBomb 메소드 호출
        }
        Destroy(other.gameObject); // 아이템 제거
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 위치를 기준으로 Ray 생성
            RaycastHit hit; // Ray가 충돌한 오브젝트 정보를 담을 변수
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // Ray가 충돌한 오브젝트가 있다면
            {
                float fHitX = Mathf.Round(hit.point.x); // 충돌 지점의 x좌표를 반올림
                float fHitZ = Mathf.Round(hit.point.z); // 충돌 지점의 z좌표를 반올림
                transform.position = new Vector3(fHitX, 0, fHitZ); // 위치 변경
            }
        }
    }


}