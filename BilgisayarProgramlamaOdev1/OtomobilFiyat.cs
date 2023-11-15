public class OtomobilFiyat
{
    static void Main()
    {
        Console.WriteLine("Motor tipini giriniz (içten yanmalı veya elektrikli): ");
        string motorTipi = Console.ReadLine();

        Console.WriteLine("Silindir hacmini cm³ cinsinden giriniz: ");
        double silindirHacmi = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Vergisiz satış tutarını TL cinsinden giriniz: ");
        double vergisizTutar = Convert.ToDouble(Console.ReadLine());

        double sonuc = HesaplaOtomobilFiyati(motorTipi, silindirHacmi, vergisizTutar);

        if (sonuc != -1)
        {
            Console.WriteLine($"Otomobil satış fiyatı: {sonuc:F2} TL");
        }
        else
        {
            Console.WriteLine("Geçersiz motor tipi!");
        }
    }

    static double HesaplaOtomobilFiyati(string motorTipi, double silindirHacmi, double vergisizTutar)
    {
        double otv = 0.0;
        double kdv = 0.20;

        if (motorTipi == "içten yanmalı")
        {
            if (silindirHacmi <= 1600)
            {
                if (vergisizTutar <= 184000) otv = 0.45;
                else if (184000 < vergisizTutar && vergisizTutar <= 220000) otv = 0.50;
                else if (220000 < vergisizTutar && vergisizTutar <= 250000) otv = 0.60;
                else if (250000 < vergisizTutar && vergisizTutar <= 280000) otv = 0.70;
                else otv = 0.80;
            }
            else if (1600 < silindirHacmi && silindirHacmi <= 2000)
            {
                otv = (vergisizTutar <= 170000) ? 1.30 : 1.50;
            }
            else
            {
                otv = 2.20;
            }
        }
        else if (motorTipi == "elektrikli")
        {
            if (silindirHacmi <= 160)
            {
                otv = (vergisizTutar <= 700000) ? 0.10 : 0.40;
            }
            else
            {
                otv = (vergisizTutar <= 750000) ? 0.50 : 0.60;
            }
        }
        else
        {
            return -1; 
        }

        double otvliTutar = vergisizTutar * (1 + otv);
        return otvliTutar * (1 + kdv);
    }
}