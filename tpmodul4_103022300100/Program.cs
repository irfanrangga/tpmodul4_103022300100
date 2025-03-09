using System.Security.Cryptography.X509Certificates;

public class MainClass
{
    public static void Main()
    {
        Console.WriteLine(KodePos.getKodePos(KodePos.Kelurahan.Batununnggal));
        Console.WriteLine(KodePos.getKodePos(KodePos.Kelurahan.Kujangsari));
        DoorMachine pintu = new DoorMachine();
        Console.WriteLine(pintu.currentState);
        pintu.activateTrigger(Trigger.KunciPintu);
        pintu.activateTrigger(Trigger.BukaPintu);
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

public enum DoorState { Terkunci, Terbuka }
public enum Trigger { KunciPintu, BukaPintu }
public class DoorMachine
{
    DoorState stateAwal;
    DoorState stateAkhir;
    Trigger trigger;

    public (DoorState stateAwal, DoorState stateAkhir, Trigger trigger)[] transisi =
    {
        (DoorState.Terkunci, DoorState.Terbuka, Trigger.BukaPintu),
        (DoorState.Terbuka, DoorState.Terkunci, Trigger.KunciPintu)
    };

    public DoorState currentState = DoorState.Terkunci;

    public DoorState GetNextState(DoorState stateAwal, Trigger trigger)
    {
        DoorState stateAkhir = stateAwal;
        for(int i = 0; i < transisi.Length; i++)
        {
            (DoorState stateAwal, DoorState stateAkhir, Trigger trigger) perubahan = transisi[i];

            if(stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
            {
                stateAkhir = perubahan.stateAkhir;
            }
        }
        return stateAkhir;
    }

    public void activateTrigger(Trigger trigger)
    {
        currentState = GetNextState(currentState, trigger);
        if(currentState == DoorState.Terkunci)
        {
            Console.WriteLine("Pintu terkunci");
        } else
        {
            Console.WriteLine("Pintu tidak terkunci");
        }
    }
}