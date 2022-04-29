using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed;
    public float r_Speed;
    public AudioSource engineSound;
    public AudioSource bgSound;
    public AudioSource scoreSound;
    public AudioSource damageSound;
    public AudioSource loseSound;
    public AudioSource winSound;

    private int damageCount;
    private int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI countDamageText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject startButtonObject;


    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        count = 0;
        damageCount = 0;
        engineSound = GetComponent<AudioSource>();
        engineSound.Stop();
        bgSound.Play();


        setCountDamageText();
        setCountText();
        winTextObject.SetActive(false);
        startButtonObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.forward * m_Speed;
            if (!engineSound.isPlaying)
            {
                engineSound.Play();
            }
        }

        if (!Input.GetKey(KeyCode.UpArrow))
        {
            m_Rigidbody.velocity = m_Rigidbody.velocity * .9f;
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            if (engineSound.isPlaying)
            {
                engineSound.Pause();
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        { 
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = m_Rigidbody.velocity * .9f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * r_Speed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * r_Speed, Space.World);
        }

        if (!Input.anyKeyDown)
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = m_Rigidbody.velocity * .9999f;
        }

    }

    void setCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count == 13)
        {
            winSound.Play();
            winTextObject.SetActive(true);
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            startButtonObject.SetActive(true);
        }
    }

    void setCountDamageText()
    {
        countDamageText.text = "Damage: " + damageCount.ToString() + "%";
        if (damageCount == 100)
        {
            loseSound.Play();
            loseTextObject.SetActive(true);
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            startButtonObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            scoreSound.Play();
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            damageSound.Play();
            other.gameObject.SetActive(false);
            damageCount = damageCount + 10;
            setCountDamageText();
        }
    }


}
