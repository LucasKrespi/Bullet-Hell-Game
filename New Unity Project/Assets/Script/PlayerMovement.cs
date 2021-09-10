using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 m_MousePos;
    Vector2 m_Movement;
    Rigidbody2D m_ShipRB;
    private float m_speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        m_ShipRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
        moveShip();
    }

    private void FixedUpdate()
    {
        m_ShipRB.MovePosition(m_ShipRB.position + m_Movement * m_speed * Time.fixedDeltaTime);
    }
    void faceMouse()
    {
        m_MousePos = Input.mousePosition;
        m_MousePos = Camera.main.ScreenToWorldPoint(m_MousePos);

        Vector2 characterDirection = new Vector2(m_MousePos.x - transform.position.x, m_MousePos.y - transform.position.y);

        transform.up = characterDirection;
    }

    void moveShip()
    {
        m_Movement.x = Input.GetAxisRaw("Horizontal");
        m_Movement.y = Input.GetAxisRaw("Vertical");
    }
}
