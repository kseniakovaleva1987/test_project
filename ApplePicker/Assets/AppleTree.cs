using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Base for apple creation
    public GameObject applePrefab;

    //Speed of tree movement
    public float speed = 1f;

    //Расстояние, на котором должно изменяться направление движения яблони
    public float leftAndRightEdge = 10f;

    //Вероятность случайного изменения направления движения
    public float chanceToChangeDirections = 0.1f;

    //Частота создания экземпляра яблок
    public float secondsBetweenAppleDrops = 1f;
        
    void Start()
    {
        //Сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
        //Функция Invoke() вызывает функцию, заданную именем, через указанное число секунд. 
        //В данном случае вызывается новая функция DropApple(). Второй параметр, 2f, сообщает методу Invoke(), 
        //что тот должен подождать 2 секунды перед вызовом DropApple().
    }

    void DropApple()//DropApple() — это наша функция. Она создает экземпляр Apple в точке, где находится AppleTree
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        //DropApple() создает экземпляр applePrefab и присваивает его переменной apple типа GameObject
        apple.transform.position = transform.position;
        //Местоположение этого нового игрового объекта apple устанавливается равным местоположению яблони AppleTree.
        Invoke("DropApple", secondsBetweenAppleDrops);
        //Снова вызывается Invoke(). На этот раз он вызовет функцию DropApple() через secondsBetweenAppleDrops секунд 
    }
    void Update()
    {
        //Простое перемещение
        Vector3 pos = transform.position; //объявляение локальной переменной для хранения текущей позиции яблони
        pos.x += speed * Time.deltaTime; //компонент x переменной pos увеличивается на произведение скорости и интервала времени (кол-во секунл после отображения пред.кадра)
        transform.position = pos; //измененной значение pos присваивается обратно, чтобы яблоня переместилась
        //Time.deltaTime сообщает время в секундах, прошедшее с последнего кадра

        //Изменение направления
        if (pos.x < -leftAndRightEdge) //Проверить, не оказалось ли значение pos. х, только что установленное в предыдущих строках, меньше отрицательного значения предела leftAndRightEdge.
        {
            speed = Mathf.Abs(speed); //Если величина pos. х оказалась слишком маленькой, переменной speed присваивается результат вызова Mathf .Abs(speed), который возвращает абсолютное положительное значение speed и тем самым гарантирует, что в следующем кадре начнется перемещение яблони вправо.

        }
        else if (pos.x > leftAndRightEdge) //Если величина pos.x оказалась больше leftAndRightEdge, переменной speed присваивается отрицательное значение результата вызова Mathf .Abs(speed), благодаря чему в следующем кадре AppleTree начнет движение влево.

        {
            speed = -Mathf.Abs(speed);
        }
    }
    void FixedUpdate()
    { 
        if (UnityEngine.Random.value < chanceToChangeDirections) //Random.value возвращает случайное число типа float между 0 и 1 (включая 0 и 1 как возможные значения). Если случайное значение меньше chanceToChangeDirections...

        {
            speed *= -1; // изменить направление движения AppleTree можно, поменяв знак переменной speed на противоположный 
        }
    }
}
