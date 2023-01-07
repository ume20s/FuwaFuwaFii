using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuwafuwa : MonoBehaviour
{
    // 物理演算関連
    Rigidbody2D rigidBody;
    float vForce = 20.0f;
    float maxSpeed = 10.0f;
    float threshold = 0.1f;

    // 効果音関連
    AudioSource audioSource;
    public AudioClip[] vSe = new AudioClip[7];

    // Start is called before the first frame update
    void Start()
    {
        // 各種コンポーネントを取得
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動方向感知用フラグ
        int xx = 0;
        int yy = 0;
        Vector2 v;

        // スマホの傾きを感知
        if (Input.acceleration.x > threshold) xx = 1;
        if (Input.acceleration.x < -threshold) xx = -1;
        if (Input.acceleration.y > threshold) yy = 1;
        if (Input.acceleration.y < -threshold) yy = -1;

        // 加速装置！
        v.x = xx * vForce;
        v.y = yy * vForce;
        rigidBody.AddForce(v);

        // スピードリミッター
        float speed = Mathf.Abs(rigidBody.velocity.magnitude);
        if (speed > maxSpeed)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x / 1.1f, rigidBody.velocity.y / 1.1f);
        }
    }

    // 壁に衝突したら効果音
    void OnCollisionEnter2D(Collision2D collisio)
    {
        audioSource.PlayOneShot(vSe[Random.Range(0, 7)]);
    }
}
