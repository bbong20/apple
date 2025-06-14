using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;       // ��� ȹ�� ����
    public AudioClip bombSE;        // ��ź ȹ�� ����
    AudioSource aud;                // ����� �ҽ� ������Ʈ
    GameObject gDirector; // ���� ���� ������Ʈ


    void Start()
    {
        Application.targetFrameRate = 60; // �������� 60���� ����
        this.aud = GetComponent<AudioSource>(); // ����� �ҽ� ������Ʈ ��������
        this.gDirector = GameObject.Find("GameDirector"); // "GameDirector"��� �̸��� ���� ������Ʈ ã��
    }

    void OnTriggerEnter(Collider other) // �浹 ����
    {
        if (other.gameObject.tag == "Apple") // �浹�� ������Ʈ�� ������
        {
            this.aud.PlayOneShot(this.appleSE); // ��� ȹ�� ���� ���
            this.gDirector.GetComponent<GameDirector>().GetApple(); // GameDirector�� GetApple �޼ҵ� ȣ��
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE); // ��ź ȹ�� ���� ���
            this.gDirector.GetComponent<GameDirector>().GetBomb(); // GameDirector�� GetBomb �޼ҵ� ȣ��
        }
        Destroy(other.gameObject); // ������ ����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 ��ġ�� �������� Ray ����
            RaycastHit hit; // Ray�� �浹�� ������Ʈ ������ ���� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // Ray�� �浹�� ������Ʈ�� �ִٸ�
            {
                float fHitX = Mathf.Round(hit.point.x); // �浹 ������ x��ǥ�� �ݿø�
                float fHitZ = Mathf.Round(hit.point.z); // �浹 ������ z��ǥ�� �ݿø�
                transform.position = new Vector3(fHitX, 0, fHitZ); // ��ġ ����
            }
        }
    }


}