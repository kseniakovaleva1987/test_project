using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketG0 = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketG0.transform.position = pos;
            basketList.Add(tBasketG0);
        }

    }
    public void AppleDestroyed()
    {
        // Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);

        }
        // Удалить одну корзину 
        // Получить индекс последней корзины в basketList
        int basketIndex = basketList.Count - 1;
        // Получить ссылку на этот игровой объект Basket
        GameObject tBasketG0 = basketList[basketIndex];
        // Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketG0);
        // Если корзин не осталось^ перезапустить игру
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0" );
            }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
