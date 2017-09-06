using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	(1)宣告委派型別。你需要使用關鍵字 delegate 來定義委派型別的名稱，以及傳入參數和傳回值。
	(2)定義一個符合委派型別的 signature 的方法（可為 instance method 或 static method），這裡簡稱為委派方法。
	(3)建立 delegate 實體並指向 SecretMethod。註冊SecretMethod為GetSecretIngredient類型(delegate)
	(4)透過委派物件執行委派方法。
 */
public class DelegateTest : MonoBehaviour
{

    //(1)這個 delegate 可被用來建立變數，指向任何「接受一個 int 參數並且回傳 string」的方法。
    public delegate string myDelegate(int amount);

    //(2)
    public string SecretMethod1(int amount) { Debug.Log("Suzanne's method1 " + (amount + 1)); return "Down1"; }

    //(2)
    public string SecretMethod2(int amount) { Debug.Log("Suzanne's method2 " + (amount + 2)); return "Down2"; }

    void Start()
    {

        //(3) 1.0寫法
        //myDelegate MyMethod = new myDelegate(SecretMethod1);	
        myDelegate MyMethodA = SecretMethod1;     //簡化
        MyMethodA += SecretMethod2;

        //(3) 2.0寫法
        myDelegate MyMethodB  = delegate (int k) { return "num1: " + (k + 1).ToString(); };
                            MyMethodB += delegate (int k) { return "num2: " + (k + 2).ToString(); };
                            MyMethodB += delegate (int k) { return "num3: " + (k + 3).ToString(); };

        //(3) 3.0寫法 容器 = 傳入參數 => return值，也可解讀為：將左邊參數傳入右邊匿名方法
        //myDelegate MyMethodC = (int k) => { return "num5: " + (k + 1).ToString(); };	
        //myDelegate MyMethodC = (k)     => { return "num5: " + (k + 1).ToString(); };		//簡化
          myDelegate MyMethodC = (k)     => "num5: " + (k + 1).ToString();                  //簡化


        //(4)
        Debug.Log("MyMethodA: " + MyMethodA(8));
        Debug.Log("MyMethodB: " + MyMethodB(8));
        Debug.Log("MyMethodC: " + MyMethodC(8));

		/* 
            result:

			Suzanne's method1 9
			Suzanne's method2 10
			MyMethodA: Down2

			MyMethodB: num3: 11

			MyMethodC: num5: 9
		 */
    }






}
