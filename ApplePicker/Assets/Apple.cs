using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    //объявляет и определяет статическую переменную с именем bottomY

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            //Функция Destroy() удаляет указанный объект из игры и может использоваться для удаления компонентов и игровых объектов. 
            //Во всех сценариях ссылка this указывает на текущий экземпляр класса С#, выполняющий вызов (в этом листинге this ссылается на экземпляр компонента Apple (Script)), а не на сам игровой объект. Всякий раз, когда требуется удалить игровой объект целиком из подключенного к нему класса компонента, следует использовать вызов Destroy( this.gameObject ).

            // Получить ссылку на компонент ApplePicker главной камеры Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Вызвать общедоступный метод AppleDestroyed() из apScript
            apScript.AppleDestroyed();
        }
    }
}
