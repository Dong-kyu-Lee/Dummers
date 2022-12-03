using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float runSpeed;
    float currentSpeed = 0;
    float maxDistance = 15.0f;
    Vector2 mousePos;

    void Start()
    {
        // InputManager에 keyAction이 실행되면 Move를 실행.
        GameManager.Input.keyAction -= Move;
        GameManager.Input.keyAction += Move;
        GameManager.Input.mouseAction -= OnMouseClicked;
        GameManager.Input.mouseAction += OnMouseClicked;
    }

    void Update()
    {

    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)) currentSpeed = runSpeed;
        else currentSpeed = speed;
        transform.position += new Vector3(h, v, 0).normalized * currentSpeed * Time.deltaTime;
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click) return;

        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, maxDistance);
        if(hit)
        {
            hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
