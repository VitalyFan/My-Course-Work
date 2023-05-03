using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Script : MonoBehaviour
{
    public float speed_Move;
    float z_Move;
    float x_Move;
    CharacterController player;
    Vector3 move_Direction;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        x_Move = Input.GetAxis("Horizontal");
        z_Move = Input.GetAxis("Vertical");

        
        move_Direction = new Vector3(x_Move, 0f, z_Move);
        move_Direction = transform.TransformDirection(move_Direction);
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            player.height = 0.1f;
            move_Direction.y -= 1f;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            move_Direction.y += 1;
            player.height = 5f;
        }
        
        player.Move(move_Direction * Time.deltaTime * speed_Move);
    }
}
