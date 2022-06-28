using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D PlayersRigidBody;
    public float MoveSpeed = 5.0f;
    public Vector2 MoveDirection { get; private set; }

    void Update()
    {
        MoveDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        MoveDirection.Normalize();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookVector = mousePosition - PlayersRigidBody.position;
        PlayersRigidBody.rotation = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        PlayersRigidBody.MovePosition(PlayersRigidBody.position + MoveDirection * Time.deltaTime * MoveSpeed);
    }
}
