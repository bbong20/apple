using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float fItemDropSpeed = -0.03f; // 아이템 낙하 속도

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, this.fItemDropSpeed, 0); // 아이템 낙하
        if (transform.position.y < -1.0f) // 아이템이 화면 밖으로 나가면
        {
            Destroy(gameObject); // 아이템 제거
        }
    }
}