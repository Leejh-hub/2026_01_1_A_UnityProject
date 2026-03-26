using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5.0f; // 이동 속도 변수
    public float jumpForce = 5.0f; // 점프 힘 값 선언

    public Rigidbody rb; // 플레이어 강체 선언

    public bool isGrounded = true; // 땅 위에 있는지 체크 하는 변수

    public int coinCount = 0; // 코인 획득 변수



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //움직임 입력
        float moveHorizontal = Input.GetAxis("Horizontal"); // 수평이동 (키값을 받아온다 , -1 ~ -1)
        float moveVertical = Input.GetAxis("Vertical"); // 수직이동 (키값을 받아온다 , -1  ~ -1)

        //강체에 속도의 값을 변경해서 캐릭터를 이동시킨다
        rb.linearVelocity = new Vector3(moveHorizontal * movespeed, rb.linearVelocity.y, moveVertical * movespeed);

        //점프 입력
        if (Input.GetButtonDown("Jump") && isGrounded) // && 두 값을 만족할 때 -> (스페이스 버튼을 눌렀을때와 땅 위에 있을때)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 위쪽 방향으로 설정한 힘 수치만큼 힘을 가함
            isGrounded = false; // 점프를 하는 순간 땅에서 떨어졌기 때문에 false
        }
    }
    void OnCollisionEnter(Collision collision) // 유니티에서 지원하는 충돌 체크 함수
    {
        if (collision.gameObject.tag == "Ground") // 충돌한 물체의 Tag가 Ground 일 경우
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) // Tag가 Coin 일 경우
        {
            coinCount++;   // 코인 변수를 1 올린다
            Destroy(other.gameObject); //코인 오브젝트를 파괴한다.
        }
    }
}
