using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TeamFriend Type", menuName = "PlayerType")]
public class TeamFriendType : ScriptableObject
{

    public float playerSpeed = 5;
    public float playerLeftSpeed = 8;
    public Vector3 leftRightMove;

    public string typeName = "type";


}
