using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDude : BaseUnit
{
    private float direction = 1;

    // Update is called once per frame
    void Update()
    {
        // check if the right side is touching ground and if its not then move left
        if (!IsGrounded(raycastOffsetX))
        {
            direction = -1;
        }

        // check if the left side is touching ground and if its not then move right
        if (!IsGrounded(-raycastOffsetX))
        {
            direction = 1;
        }

        // move
        Move(direction);
    }
}
