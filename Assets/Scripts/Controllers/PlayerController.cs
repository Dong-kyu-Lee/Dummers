using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float runSpeed;
    SpriteRenderer sr;
    Animator anim;
    float currentSpeed = 0;
    float maxDistance = 15.0f;
    Vector3 prePosition;
    Vector2 mousePos;

    PlayerState player;

    void Awake()
    {
        // InputManager�� keyAction�� ����Ǹ� Move�� ����.
        GameManager.Input.keyAction -= Move;
        GameManager.Input.keyAction += Move;
        GameManager.Input.mouseAction -= OnMouseClicked;
        GameManager.Input.mouseAction += OnMouseClicked;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerState>();
        prePosition = transform.position;
    }

    void Update()
    {
        //Idle - Move Animation
        if (transform.position != prePosition) anim.SetBool("isMove", true);
        else anim.SetBool("isMove", false);
        prePosition = transform.position;
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h > 0) sr.flipX = true;
        else if (h < 0) sr.flipX = false;

        if (Input.GetKey(KeyCode.LeftShift)) currentSpeed = runSpeed;
        else currentSpeed = speed;
        transform.position += new Vector3(h, v, 0).normalized * currentSpeed * Time.deltaTime;

        /*if (transform.position != prePosition) anim.SetBool("isMove", true);
        else anim.SetBool("isMove", false); 
        ������ ���� Move ����, �ƴϸ� ���� �ȵǼ� "�������� ���� �� Idle�� �ٲٱ�"�� �� �Լ� �ȿ����� �ȵ�.
        prePosition = transform.position;*/
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click) return;

        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, maxDistance);
        if(hit)
        {
            Debug.Log("Shoot");
            //player.currentWaepon.Attack();
        }
    }
}
