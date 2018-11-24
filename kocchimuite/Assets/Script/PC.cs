using UnityEngine;
using System.Collections;

public class PC : MonoBehaviour
{
    //speedを調整する
    public float speed = 10;

    void FixedUpdate()
    {
        //入力をｘとｙに代入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //同一のGameObjectが持つRigidbodyコンポーネントを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        //rigidbodyのx軸とz軸に力を加える
        rigidbody.AddForce(x * speed, 0, z * speed);
    }
}