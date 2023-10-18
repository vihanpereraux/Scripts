using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Script : MonoBehaviour
{
    public TextMeshProUGUI inputField;
    public GameObject firstScreen;
    public GameObject secondScreen;
    public GameObject thirdScreen;
    public string name;
    public TextMeshProUGUI usernameDispaly;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void confirmButtonClicked()
    {
        name = inputField.GetComponent<TextMeshProUGUI>().text;
        Debug.Log(name);

        secondScreen.SetActive(true);
        usernameDispaly.GetComponent<TextMeshProUGUI>().text = name + " !";
    }

    public void getWeatherInfoButtonClicked()
    {
        Debug.Log("Button Clicked");
        firstScreen.SetActive(false);
        secondScreen.SetActive(false);
        thirdScreen.SetActive(true);
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://www.my-server.com");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}
