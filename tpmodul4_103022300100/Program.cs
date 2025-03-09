using System.Security.Cryptography.X509Certificates;

public class MainClass
{
    public static void Main()
    {
        Console.WriteLine(KodePos.getKodePos(KodePos.Kelurahan.Margasari));
    }
}

public class KodePos
{
    public enum Kelurahan { Batununnggal, Kujangsari, Mengger, Wates, Cijaura, 
        Jatisari, Margasari, Sekejati, Kebonwaru, Maleer, Samoja}

    public static string getKodePos(Kelurahan kelurahan)
    {
        string[] kodePos = { "40266", "40287", "40267", "40256", "40287",
            "40286", "40286", "40286", "40272", "40274", "40273"};

        return kodePos[(int)kelurahan];
    }
}
