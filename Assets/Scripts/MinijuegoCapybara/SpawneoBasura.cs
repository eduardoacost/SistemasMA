using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawneoBasura : MonoBehaviour
{
    public GameObject juegoCapybara;
    public GameObject imagePrefab;  // Arrastra tu prefab de imagen aquí en el Inspector de Unity
    public GameObject padreInstanciasBasura;

    public GameObject instruccionesJuego;
    public int minInstances = 5;
    public int maxInstances = 10;
    public int instances;

    void Start()
    {
        juegoCapybara.gameObject.SetActive(false);
        
        
    }

   void Update()
    {
        if (GameManagerCapybara.Instance.seCompletoElJuego == true)
        {
            juegoCapybara.gameObject.SetActive(false);
        }
    }

    void SpawnImages()
    {
        
        instances = Random.Range(minInstances, maxInstances + 1);
        for (int i = 0; i < instances; i++)
        {
            float randomX = Random.Range(50f, 1400f);
            float randomY = Random.Range(50f, 350f);
            float randomZRotation = Random.Range(-110f, 110f);

            Vector3 position = new Vector3(randomX, randomY, 0f);
            Quaternion rotation = Quaternion.Euler(0f, 0f, randomZRotation);

            GameObject newImage = Instantiate(imagePrefab, position, rotation);
            newImage.transform.SetParent(padreInstanciasBasura.transform);
        }
        GameManagerCapybara.Instance.inicioJuego();
    }

    IEnumerator DeactivateAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        instruccionesJuego.SetActive(false);
        SpawnImages();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            juegoCapybara.gameObject.SetActive(true);
            StartCoroutine(DeactivateAfterSeconds(3.5f));
            

        }
    }




}
