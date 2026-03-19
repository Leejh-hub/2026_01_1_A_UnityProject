using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MyJump : MonoBehaviour
{
    public Rigidbody rigidbody; // 강체 (형태와 크기가 고정된 고체) 물리 현상이 동작 가능 하게 해주는 컴포넌트
    public float power = 200f; // 점프 힘을 선언 함
    public Text timeUI; // 시간 UI를 생성
    public float TImer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        TImer = TImer + Time.deltaTime;
        timeUI.text = TImer.ToString();


        if (Input.GetKeyDown(KeyCode.Space)) // space 누르면
        {
            power = power + Random.Range(-100, 200); // power의 랜덤 값을 더해서 변형 시킨다. (-100 ~ 200 ) 사이의 값을 더 한다
            rigidbody.AddForce(transform.up * power); // power의 힘 값으로 위쪽(transform.up)으로 힘을 준다.
        }
        if (this.gameObject.transform.position.y > 5 || this.gameObject.transform.position.y < -3)
        {
            // 이 오브젝트의 y 좌표점 위치가 5보다 크거나 -3보다 작을 경우
            Destroy(this.gameObject);  // 오브젝트를 파괴
        }
        
    }
}
