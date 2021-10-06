using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform Player;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Player.position,0.1f);
    }
}
