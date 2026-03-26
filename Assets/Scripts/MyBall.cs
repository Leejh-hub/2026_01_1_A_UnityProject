using UnityEngine;

public class MyBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) // 유니티에서 지원하는 충돌 체크 함수
    {
        Debug.Log(collision.gameObject.name + " 와 충돌함"); // 충돌체의 이름 기록

        if (collision.gameObject.tag == "Ground") // 충돌한 물체의 Tag가 Ground 일 경우
        {
            Debug.Log("땅과 충돌");        // 로그 기록
        }
    }

    void OnTriggerEnter(Collider other) // 캐릭터가 특정 지역을 들어갈때(충돌 범위) 체크 함수
    {
        Debug.Log("트리거 안으로 들어옴"); // 로그 기록
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("트리거를 빠져나감"); // 로그 기록
    }

    //void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("트리거 속에 존재");
    //}
}
