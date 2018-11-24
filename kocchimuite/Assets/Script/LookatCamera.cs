using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCamera : MonoBehaviour {
    //顔ボーン
    [SerializeField]
    private Transform Charactor1_Head = null;

    /// キャッシュ用カメラ Transform
    private Transform camra;

    //初期処理
    public void Start()
    {
        this.camra = Camera.main.transform;
    }

    //毎フレーム処理
    public void FixedUpdate()
    {
        var cameraPosition = this.camra.position;

        //目の高さにあわせる
        cameraPosition.y = 0.3f;

        //顔を上げ下げ
        this.transform.LookAt(cameraPosition);
        var angle = this.transform.rotation.eulerAngles.x;
        angle = angle > 180f ? angle - 360f : angle;
        this.Charactor1_Head.localRotation = Quaternion.Euler(90f + Mathf.Clamp(angle, -30f, 30f), 0f, 0f);

        //身体をまわす
        cameraPosition.y = this.transform.position.y;
        this.transform.LookAt(cameraPosition);

    }

}
//Charactor1_Head