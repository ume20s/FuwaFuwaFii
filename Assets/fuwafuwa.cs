using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuwafuwa : MonoBehaviour
{
    // �������Z�֘A
    Rigidbody2D rigidBody;
    float vForce = 20.0f;
    float maxSpeed = 10.0f;
    float threshold = 0.1f;

    // ���ʉ��֘A
    AudioSource audioSource;
    public AudioClip[] vSe = new AudioClip[7];

    // Start is called before the first frame update
    void Start()
    {
        // �e��R���|�[�l���g���擾
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ��������m�p�t���O
        int xx = 0;
        int yy = 0;
        Vector2 v;

        // �X�}�z�̌X�������m
        if (Input.acceleration.x > threshold) xx = 1;
        if (Input.acceleration.x < -threshold) xx = -1;
        if (Input.acceleration.y > threshold) yy = 1;
        if (Input.acceleration.y < -threshold) yy = -1;

        // �������u�I
        v.x = xx * vForce;
        v.y = yy * vForce;
        rigidBody.AddForce(v);

        // �X�s�[�h���~�b�^�[
        float speed = Mathf.Abs(rigidBody.velocity.magnitude);
        if (speed > maxSpeed)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x / 1.1f, rigidBody.velocity.y / 1.1f);
        }
    }

    // �ǂɏՓ˂�������ʉ�
    void OnCollisionEnter2D(Collision2D collisio)
    {
        audioSource.PlayOneShot(vSe[Random.Range(0, 7)]);
    }
}
