using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FameCurrency : MonoBehaviour
{
    public int count;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        count = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeFame(10);
            PlayerPrefs.SetInt("amount", count);
        }

        text.text = "Fame: " + count;

       /* if (count <= 0)
        {
            SceneManager.LoadScene("You Lose");
        }

        if (count > 40)
        {
            SceneManager.LoadScene("You Win");
        }*/
    }

    public void ChangeFame(int adjustment)
    {
        count += adjustment;
    }
}
