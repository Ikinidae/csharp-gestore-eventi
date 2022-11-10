public class Conferenza : Evento
{
    //properties
    public string Relatore { get; private set; }
    public double Prezzo { get; private set; }

    //costruttore
    public Conferenza (string titolo, DateOnly data, int postiMax, string relatore, double prezzo) : base (titolo, data, postiMax)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }

    //metodi
    public override string ToString()
    {
        return Data + " - " + Titolo + " - " + Relatore + " - " + Prezzo.ToString("0.00") + " euro";
    }
}