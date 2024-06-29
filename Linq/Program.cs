void Linq1() //#1
{
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    var sorgu = from number in numbers //numbers dizisindeki elemanları number değişkenine ata ve number değişkeni üzerinde işlem yap
                where number % 2 == 0
                select number; // number değişkenini seç

    foreach (var item in sorgu)
    {
        Console.WriteLine(item);
    }
}
void Linq2() //#2
{

    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    var sorgu = (from number in numbers
                 select number * number).ToList(); // number değişkenini seç ve number değişkeninin karesini al

    foreach (var item in sorgu)
    {
        Console.WriteLine(item);
    }
}


void Linq3() //#3
{
    List<string> sehirler = new List<string> { "Ankara", "İstanbul", "İzmir", "Bursa", "Adana" };

    var sorgu = (from sehir in sehirler //sehirler herbir elemanını sehir değişkenine ata ve sehir değişkeni üzerinde işlem yap
                where sehir.Length > 5
                select new { sehir, uzunluk = sehir.Length }).ToList();// her bir sehir değişkenini seç ve uzunluğunu al

    foreach (var item in sorgu)
    {
        Console.WriteLine(item);
    }

    // Linq query syntax ile aynı işlemi yapar
    List<object> newSehirler = new List<object>();
    foreach (var sehir in sehirler)//from sehir in sehirler
    {
        if (sehir.Length > 5)//where sehir.Length > 5
        {
            newSehirler.Add(new { sehir, uzunluk = sehir.Length });//select new { sehir, uzunluk = sehir.Length } --> {sehir = sehir, uzunluk = sehir.Length}
        }//sehir.ToUpper(), sehir.ToLower(), sehir.Substring(0, 1), sehir.Contains("a"), sehir.StartsWith("A"), sehir.EndsWith("a") gibi metotlar da kullanılabilir
    }

    foreach (var item in newSehirler)
    {
        Console.WriteLine(item);
    }
}

void Linq4() //#4
{
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    var sorgu = (from number in numbers
                 select number).Take(5).ToList(); //ilk 5 elemanı al
    Console.WriteLine($"ilk 5 eleman: {string.Join(",", sorgu)}");
}

