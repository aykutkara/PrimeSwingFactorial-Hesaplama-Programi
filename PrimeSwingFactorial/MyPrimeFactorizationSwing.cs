using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PrimeSwingFactorial
{
    public static class MyPrimeFactorizationSwing
    {
        public static BigInteger PrimeSwing(int value)  //burda Prime Swing Algoritmasına göre faktöriyel hesabı yapıyor.
        {
            BigInteger factorial = new BigInteger();
            BigInteger factorial2 = new BigInteger();
            BigInteger result = new BigInteger();


            factorial = Factorial(value);
            factorial2 = Factorial(value / 2) * Factorial(value / 2);

            result = factorial / factorial2;

            return result;


        }
        public static BigInteger Factorial(int value)   //bu metod factoriyeli hesaplama işlemi yapıyor.
        {
            BigInteger result = new BigInteger(1);
            int baslangicNumarasi = value;
            if (value % 2 == 1)
            {
                result = value;
                baslangicNumarasi = value - 1;
            }
            
            int kalanSayi = baslangicNumarasi - 2; //kalansayi aynı zamanda artış miktarı anlamına da geliyor.
            while (kalanSayi >= 0)
            {
                result *= baslangicNumarasi;
                baslangicNumarasi += kalanSayi;
                kalanSayi -= 2;                    //burda aslında iki sayıyı çarptığımız için kalan sayı 2 azalıyor
            }

            return result;

        }

        internal static BigInteger Run(BigInteger output) //burası form1.cs sınıfından çağırdığımızda program çalışsın diye yaptığım metod
        {
            return PrimeSwing((int)output);
        }

        
       
    }
}
