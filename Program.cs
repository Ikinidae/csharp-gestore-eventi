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
Console.WriteLine("nome evento: {0}, data evento {1}, numero posti max: {2}, posti prenotati: {3}", evento1.Titolo, evento1.Data, evento1.PostiMax, evento1.PostiPrenotati);

evento1.DisdiciPosti(postiDaPrenotare);
Console.WriteLine("nome evento: {0}, data evento {1}, numero posti max: {2}, posti prenotati: {3}", evento1.Titolo, evento1.Data, evento1.PostiMax, evento1.PostiPrenotati);




//creare classe eccezioni per il programma
public class gestoreEventiEccezioni
{

}