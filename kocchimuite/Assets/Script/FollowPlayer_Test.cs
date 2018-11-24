using UnityEngine;
using System.Collections;

public class FollowPlayer_Test : MonoBehaviour {

    // ターゲットへの参照
    public Transform target;
    void Update()
    {
        //自分の座標にtargetの座標を代入する
        GetComponent<Transform>().position = target.position;

		
	}
}
