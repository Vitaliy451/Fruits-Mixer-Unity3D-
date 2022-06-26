using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MixColors : MonoBehaviour
{
    [SerializeField]
    private GameObject cylinder;
    [SerializeField]
    private Renderer cylinderRenderer;
    [SerializeField]
    GameObject apple;
    [SerializeField]
    GameObject banana;
    [SerializeField]
    GameObject tomato;
    [SerializeField]
    GameObject orange;
    [SerializeField]
    GameObject cherries;
    [SerializeField]
    GameObject eggplant;
    [SerializeField]
    GameObject cucumber;
    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject losePanel;

    Color[] aColors = { new Color(1f, 1f, 0f), new Color(0.3f, 0.9f, 0f),
                    new Color(1f, 0.7f, 0f), new Color(1f, 0f, 0f),
                    new Color(0.7f,0f,0f), new Color(0.5f, 0f, 0.9f),
                    new Color(0f, 0.3f, 0f)};
    public Color resultColor;
    public Color referenceOne = new Color(0.8f, 1.4f, 0);
    public Color referenceTwo = new Color(0.43f, 0.749f, 0);
    public Color referenceThree;
    bool flag = false;

    public MenuControl Open;
    public MenuControl Close;

    Rigidbody rigidBody;
    AudioSource blenderNoise;
    
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cylinderRenderer = cylinder.GetComponent<Renderer>();
        blenderNoise = GetComponent<AudioSource>();

        //int index;
        Open = GameObject.FindGameObjectWithTag("Controller").GetComponent<MenuControl>();
        Close = GameObject.FindGameObjectWithTag("Controller").GetComponent<MenuControl>();
        //index = SceneManager.GetActiveScene().buildIndex;

    }

    void BlenderPlay()
    {
        if (!blenderNoise.isPlaying)
            blenderNoise.Play();
        else
            return;
    }

    public void Compare(Color resultColor, Color referenceOne)
    {
        int index;
        index = SceneManager.GetActiveScene().buildIndex;
        switch (index)
        {
            case 1:
                if (resultColor.r == 0.8f &&
                    resultColor.g == 1.4f &&
                    resultColor.b == 0f)
                {
                    print(resultColor);
                    winPanel.SetActive(true);
                    losePanel.SetActive(false);
                }
                else if(apple.activeSelf == false 
                    && banana.activeSelf == false 
                    && cherries.activeSelf == false)
                {
                    losePanel.SetActive(true);
                    winPanel.SetActive(false);
                }
                break;
            case 2:
                if (resultColor == referenceTwo)
                {
                    Open.OpenMenuPanel();
                }

                break;
            case 3:
                if (resultColor == referenceThree)
                {
                    Open.OpenMenuPanel();
                }

                break;
            default:
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {

            case "Banana":
                if (flag == false)
                {
                    resultColor = aColors[0];
                    flag = true;

                }
                else
                {
                    resultColor += aColors[0] / 2;
                }
                cylinderRenderer.material.SetColor("_Color", resultColor);
                print("Yellow");
                banana.SetActive(false);
                BlenderPlay();
                Compare(resultColor, referenceOne);


                print(CompareColors(resultColor,referenceOne));
                break;
            case "Apple":
                if (flag == false)
                {
                    resultColor = aColors[1];
                    flag = true;
                }
                else
                {
                    resultColor += aColors[1] / 2;
                }
                cylinderRenderer.material.SetColor("_Color", resultColor);
                print("Green");
                apple.SetActive(false);
                BlenderPlay();
                Compare(resultColor, referenceOne);
                break;

            case "Orange":
                if (flag == false)
                {
                    resultColor = aColors[2];
                }
                else
                {
                    resultColor += aColors[2] / 2;
                }
                cylinderRenderer.material.SetColor("_Color", resultColor);
                print("Orange");
                orange.SetActive(false);
                BlenderPlay();
                print(CompareColors(resultColor, referenceOne));
                break;
            case "Tomato":
                if (flag == false)
                {
                    resultColor = aColors[3];
                    flag = true;

                }
                else
                {
                    resultColor += aColors[3] / 2;
                }
                cylinderRenderer.material.SetColor("_Color", resultColor);
                print("Red1");
                tomato.SetActive(false);
                BlenderPlay();
                print(CompareColors(resultColor, referenceOne));
                break;
            case "Cherries":
                if (flag == false)
                {
                    resultColor = aColors[4];
                    flag = true;
                }
                else
                {
                    resultColor += aColors[4] / 2;
                }
                cylinderRenderer.material.SetColor("_Color", resultColor);
                print("Red2");
                cherries.SetActive(false);
                BlenderPlay();
                print(CompareColors(resultColor, referenceOne));
                break;
            case "Eggplant":
                if (flag == false)
                {
                    resultColor = aColors[5];
                    flag = true;
                }
                else
                {
                    resultColor += aColors[5] / 2;
                }
                cylinderRenderer.material.SetColor("_Color", resultColor);
                print("Purple");
                eggplant.SetActive(false);
                BlenderPlay();
                print(CompareColors(resultColor, referenceOne));
                break;
            case "Cucamber":
                if (flag == false)
                {
                    resultColor = aColors[6];
                    flag = true;
                }
                else
                {
                    resultColor += aColors[6] / 2;
                }
                cylinderRenderer.material.SetColor("_Color", resultColor);
                print("Dark Green");
                cucumber.SetActive(false);
                BlenderPlay();
                print(CompareColors(resultColor, referenceOne));
                break;

            default:
                break;

        }
    }
    

    public float CompareColors(Color resultColor, Color referenceOne)
    {
        var calculation = Mathf.Abs((Mathf.Abs(Mathf.Abs(Mathf.Abs(resultColor.r) - Mathf.Abs(referenceOne.r)) +
            Mathf.Abs(Mathf.Abs(resultColor.g) - Mathf.Abs(referenceOne.g)) +
            Mathf.Abs(Mathf.Abs(resultColor.b) - Mathf.Abs(referenceOne.b))) / 3) - 1);
        return calculation;
    }

} 
