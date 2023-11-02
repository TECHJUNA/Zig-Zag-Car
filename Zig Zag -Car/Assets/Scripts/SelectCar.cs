using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCar : MonoBehaviour
{


    [SerializeField] Button prevButton;
    [SerializeField] Button nextButton;
    [SerializeField] Button useButton;

    [SerializeField] GameObject buyPanal;

    int CurrentCar;
    string ownCarIndex;
    Color redColor = new Color(1f, 0.1f, 1f,1f);
    Color greenColor = new Color(0.5f, 1f, 1f,1f);


    int haveStars, havehearts;
    int carValue = 700;

    [Header("Buy Panal")]
    public Text haveStarsText;
    public Text haveHeartText;
    public Button BuyCarButton;
    public Text needMoreStarsText;
    public Button closePanalButton;
   


    private void Awake()
    {
        ChangeCar(0);
    }
 


    private void Start()
    {
        haveStars = PlayerPrefs.GetInt("totalStar");
        havehearts = PlayerPrefs.GetInt("totalHeart");
    }

    private void Update()
    {
    }

   
    void ChooseCar(int _index)
    {
        prevButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            string carNo = "CarNo" + i;

            if (i == 0)
            {
                PlayerPrefs.SetInt(carNo, 1);
            }

          transform.GetChild(i).gameObject.SetActive(i == _index );
        }
    }


    public void ChangeCar(int _change)
    {
        CurrentCar += _change;

        ChooseCar(CurrentCar);

        ownCarIndex = "CarNo" + CurrentCar;
        if (PlayerPrefs.GetInt(ownCarIndex) == 1)
        {
            useButton.GetComponent<Image>().color = greenColor;
            useButton.GetComponentInChildren<Text>().text = "SELECT";
        }
        else
        {
            useButton.GetComponent<Image>().color = redColor;
            useButton.GetComponentInChildren<Text>().text = "BUY";

        }
    }

    public void UseButtonClick()
    {
        if(PlayerPrefs.GetInt(ownCarIndex) == 1) 
        {
            PlayerPrefs.SetInt("SelectCar", CurrentCar);
            SceneManager.LoadScene("GameScene");
        }
        else
        {

            buyPanal.SetActive(true);
            haveStarsText.text =  haveStars.ToString();
            haveHeartText.text =  havehearts.ToString();

            if(haveStars < carValue)
            {
                int needStarsInt = carValue - haveStars;

                BuyCarButton.interactable = false;
                needMoreStarsText.text = needStarsInt.ToString(); 
            }
            else
            {
                BuyCarButton.interactable= true;
                needMoreStarsText.text = carValue.ToString();
            }

            prevButton.interactable = false;
            nextButton.interactable = false;
            useButton.interactable = false;
        }
    }

    public void closePanelClick()
    {
        buyPanal.SetActive(false);
        prevButton.interactable = true;
        nextButton.interactable = true;
        useButton.interactable = true;

    }
   
   
}
