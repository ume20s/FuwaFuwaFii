using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuwafuwa : MonoBehaviour
{
    Rigidbody2D rb;
    float vForce = 20.0f;
    float maxSpeed = 10.0f;
    float threshold = 0.1f;

    GameObject dt;

    // 効果音関連
    AudioSource audioSource;
    public AudioClip[] vSe = new AudioClip[7];

    // Start is called before the first frame update
    void Start()
    {
        // リジッドボディのコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();

        // 効果音のコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int xx = 0;
        int yy = 0;
        Vector2 v;

        if (Input.acceleration.x > threshold) xx = 1;
        if (Input.acceleration.x < -threshold) xx = -1;
        if (Input.acceleration.y > threshold) yy = 1;
        if (Input.acceleration.y < -threshold) yy = -1;

        v.x = xx * vForce;
        v.y = yy * vForce;
        rb.AddForce(v);
        float speed = Mathf.Abs(rb.velocity.magnitude);
        if (speed > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x / 1.1f, rb.velocity.y / 1.1f);
        }
    }

    // 壁に衝突したとき
    void OnCollisionEnter2D(Collision2D collisio)
    {
        audioSource.PlayOneShot(vSe[Random.Range(0, 7)]);
    }
}
