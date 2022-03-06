using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoxControl : MonoBehaviour
{
    [SerializeField] private float vel = 0.2f, limiteVel = 2.5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public static bool gameOver = false;
    [SerializeField] private int moedasNum = 0;
    [SerializeField] private Text txtMoedas;
    [SerializeField] private GameObject chaoInicio;
    [SerializeField] private Vector3 currentEulerAngles;
    [SerializeField] private Text txtBtn, txtGO;
    [SerializeField] private Image imgBtn, imgFundo;
    [SerializeField] private bool show;

    private void Awake()
    {
        SceneManager.sceneLoaded += Carrega;
    }
    private void Carrega(Scene cena, LoadSceneMode modo)
    {
        gameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {       
        txtMoedas.text = moedasNum.ToString();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, vel);
        txtGO = GameObject.FindWithTag("txtgo").GetComponent<Text>();
        txtBtn = GameObject.FindWithTag("txtbtn").GetComponent<Text>();
        imgBtn = GameObject.FindWithTag("imgbtn").GetComponent<Image>();
        imgFundo = GameObject.FindWithTag("imgfundo").GetComponent<Image>();
        show = true;
        txtBtn.enabled = false;
        txtGO.enabled = false;
        imgBtn.enabled = false;
        imgFundo.enabled = false; 
        
        StartCoroutine(AjustaVel());
    }
    // Update is called once per frame
    void Update()
    {
        if (moedasNum >= 1)
        {
            Destroy(chaoInicio);
        }     
        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            gameOver = true;
            rb.useGravity = true;
        }
        if (gameOver && show)
        {
            PlayerPrefs.SetInt("MoedasGame", moedasNum);
            print("CAINDO");
            txtBtn.enabled = true;
            txtGO.enabled = true;
            imgBtn.enabled = true;
            imgFundo.enabled = true;
            show = false;
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
    }
    void Playermove()
    {        
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, vel);
            currentEulerAngles = new Vector3(0, -45, 0);
            transform.eulerAngles = currentEulerAngles;
        }
        else if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(vel, 0, 0);
            currentEulerAngles = new Vector3(0, 45, 0);
            transform.eulerAngles = currentEulerAngles;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Moeda"))
        {
            Destroy(col.gameObject);
            moedasNum++;
            txtMoedas.text = moedasNum.ToString();
        }
    }
    IEnumerator AjustaVel()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(10);
            if (vel <= limiteVel)
            {
                vel += 0.2f;
            }
        }
    }
    public void Novamente()
    {
        SceneManager.LoadScene(0);
    }
    public void MoveFox()
    {
        Playermove();
    }
}