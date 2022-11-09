Console.WriteLine(DateTime.Now);
Console.WriteLine(DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("inserisci nome evento");
string nomeEvento = Console.ReadLine();

Console.WriteLine("inserisci data evento (gg/mm/yyyy)");
DateOnly dataEvento = DateOnly.Parse((Console.ReadLine()));

Console.WriteLine("inserisci numero posti max evento");
int postiMaxEvento = Convert.ToInt32(Console.ReadLine());

Evento evento1 = new Evento (nomeEvento, dataEvento, postiMaxEvento);

Console.WriteLine("inserisci numero posti da prenotare");
int postiDaPrenotare = Convert.ToInt32(Console.ReadLine());
evento1.PrenotaPosti(postiDaPrenotare);
Console.WriteLine("posti prenotati: {0}", evento1.PostiPrenotati);

//creare classe eccezioni per il programma
public class gestoreEventiEccezioni
{

}