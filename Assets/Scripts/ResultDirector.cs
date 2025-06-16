using UnityEngine;                                                 // Unity 기본 API 사용
using TMPro;                                                       // TextMeshPro 컴포넌트 사용을 위해 추가

public class ResultDirector : MonoBehaviour                        // ResultDirector 클래스는 MonoBehaviour를 상속
{
    void Start()                                                   // 씬이 시작될 때 한 번 실행됨
    {
        GameObject gResultText = GameObject.Find("ResultPoint");   // 이름이 "ResultPoint"인 오브젝트를 찾음
        Debug.Log(GameDirector.nFinalPoint);
        gResultText.GetComponent<TextMeshProUGUI>().text =         // 해당 오브젝트에 연결된 텍스트 컴포넌트에 접근해서
            GameDirector.nFinalPoint.ToString() + " point";        // GameDirector에서 전달된 점수를 문자열로 표시
    }



// Update is called once per frame
void Update()
    {
        
    }
}
