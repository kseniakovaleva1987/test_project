using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System.ComponentModel;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text ScoreGT;

    void Start()
    {
        //Получить ссылку на игровой объект ScoreCounter
        GameObject scoreG0 = GameObject.Find("ScoreCounter");
        // Получить компонент Text этого игрового объекта
        ScoreGT = scoreG0.GetComponent<Text>();
        // Установить начальное число очков равным 0
        ScoreGT.text = "0";

    }

    void Update()
    {
        //Получаем текущее координаты указателя мыши
        Vector3 mousePos2D = Input.mousePosition;
        //Как далеко в трехмерном пространстве находитс указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;
        //Преобразовываем точку из двухмерной в трехмерную
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //перемещаем корзину вдоль оси
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    //}
    //метод будет вызываться всегда, когда объект будет сталкиваться с корзиной
    //проверяет, какой объект столкнулся
    //если это яблоко, оно уничтожается
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            return;
        }

        Destroy(collidedWith);
        // Преобразовать текст в scoreGT в целое число
        {
            int score = int.Parse(ScoreGT.text);
            // Добавить очки за пойманное яблоко
            score += 100;
            // Преобразовать число очков обратно в строку и вывести ее на экран
            ScoreGT.text = score.ToString();

            // Запомнить высшее достижение
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }

    
}

