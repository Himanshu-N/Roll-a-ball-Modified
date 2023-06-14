using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI YourTimeText;
    public TextMeshProUGUI BestTimeText;
    public GameObject YouWin;
    Rigidbody PlayerRB;
    int countCollectibles; float Timer; float movementX; float movementY;
    bool flag; // to stop counting time once the count reaches 8 and so the appropriate messages can be shown
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        countCollectibles = 0;
        flag = true;
        YouWin.SetActive(false);
    }
    void OnMove(InputValue movementValue) // movement script
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void FixedUpdate()
    {
        Vector3 movementVector3 = new Vector3(movementX, 0.0f, movementY);
        PlayerRB.AddForce(movementVector3 * speed);
    }

    void Update()
    {
        if (flag)
        {
            Timer += Time.deltaTime;
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        TimeText.text = "Time : " + Timer.ToString("0.0");
        if (countCollectibles == 8)
        {
            flag = false;

            if (Timer < PlayerPrefs.GetFloat("BestScoreInPref", 9999.99f))
            {
                PlayerPrefs.SetFloat("BestScoreInPref", Timer);
            }
            YourTimeText.text = "Your time : " + Timer.ToString("0.0");
            BestTimeText.text = "Best time : " + PlayerPrefs.GetFloat("BestScoreInPref").ToString("0.0");
            YouWin.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectibles"))
        {
            other.gameObject.SetActive(false);
            countCollectibles++;
        }
    }


}
