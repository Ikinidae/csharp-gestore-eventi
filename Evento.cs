//classe evento
public class Evento {
    
    //attributi
    private string _titolo;
    private DateOnly _data;

    //properties
    public string Titolo {
        get {
            return _titolo;
        }
        set {
            if (value == null || value == "")
            {
                throw new GestoreEventiException("Il nome passato è vuoto");
            }
            _titolo = value;
        } 
    }
    public DateOnly Data
    {
        get
        {
            return _data;
        }
        set
        {
            if (value <= DateOnly.FromDateTime(DateTime.Now))
            {
                throw new GestoreEventiException("La data passata è antecedente a quella attuale");
            }
            _data = value;           
        }
    }
    public int PostiMax { get; }
    public int PostiPrenotati { get; private set; }

    //costruttore
    public Evento(string titolo, DateOnly data, int postiMax)
    {
        Titolo = titolo;
        Data = data;
        if (postiMax < 0 )
        {
            throw new GestoreEventiException("Inserire un numero maggiore a zero");
        }
        PostiMax = postiMax;
        PostiPrenotati = 10;
    }

    //metodi
    public int PrenotaPosti(int inputPrenotazioni)
    {
        //se posti disponibili sono >= dei posti tot
        //se data non è passata
        if ((PostiMax - PostiPrenotati) >= inputPrenotazioni && Data >= DateOnly.FromDateTime(DateTime.Now))
        {
            return PostiPrenotati += inputPrenotazioni;
        }
        else
        {
            return 0;
        }
    }

    public int DisdiciPosti(int inputDisdici)
    {
        //metodo che si occuperà di gestire i posti cancellati ad un evento
        if ((PostiPrenotati - inputDisdici) >= 0 && Data >= DateOnly.FromDateTime(DateTime.Now))
        {
            return PostiPrenotati -= inputDisdici;
        }
        else
        {
            return 0;
        }
    }

    public override string ToString()
    {
        return Data + " - " + Titolo;
    }
}
