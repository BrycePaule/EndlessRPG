using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private GameObject Player;

    private void LateUpdate()
    {
        transform.position = Player.transform.position;
    }

}
