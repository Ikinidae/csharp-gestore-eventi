Console.WriteLine("Per creare un nuovo evento inserire nome evento:");
string nomeEvento = Console.ReadLine();

Console.WriteLine("Inserire data evento (gg/mm/yyyy)");
DateOnly dataEvento = DateOnly.Parse((Console.ReadLine()));

Console.WriteLine("Inserire numero posti max evento");
int postiMaxEvento = Convert.ToInt32(Console.ReadLine());

try
{
    Evento evento1 = new Evento(nomeEvento, dataEvento, postiMaxEvento);

    Console.WriteLine("Vuoi prenotare dei posti per l'evento? [si/no]");
    string inputPrenotazione = Console.ReadLine();
    if (inputPrenotazione == "si")
    {
        Console.WriteLine("Quanti posti vuoi prenotare?");
        int postiDaPrenotare = Convert.ToInt32(Console.ReadLine());
        evento1.PrenotaPosti(postiDaPrenotare);
        Console.WriteLine("nome evento: {0} \n data evento {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", evento1.Titolo, evento1.Data, evento1.PostiMax, evento1.PostiPrenotati, (evento1.PostiMax - evento1.PostiPrenotati));
    }

    while (evento1.PostiPrenotati > 0)
    {
        Console.WriteLine("Vuoi disdire prenotazioni? [si/no]");
        string inputDisdire = Console.ReadLine();
        if (inputDisdire == "si")
        {
            Console.WriteLine("Quante prenotazioni vuoi disdire?");
            int postiDaDisdire = Convert.ToInt32(Console.ReadLine());
            if (postiDaDisdire > evento1.PostiPrenotati)
            {
                Console.WriteLine("Non sono presenti {0} posti prenotati", postiDaDisdire);
            }
            else
            {
            evento1.DisdiciPosti(postiDaDisdire);
            Console.WriteLine("nome evento: {0} \n data evento {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", evento1.Titolo, evento1.Data, evento1.PostiMax, evento1.PostiPrenotati, (evento1.PostiMax - evento1.PostiPrenotati));
            }
        }
    }

    //Console.WriteLine(evento1.ToString());

}
catch (GestoreEventiException e)
{
    Console.WriteLine(e.ToString());
}


