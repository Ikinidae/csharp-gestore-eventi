public class ProgrammaEventi
{
    //properties
    public string Titolo { get; set; }
    public List<Evento> Eventi { get; }

    //costruttore
    public ProgrammaEventi(string titolo) {
        Titolo= titolo;
        Eventi = new List<Evento>();
    }

    //metodi
    public void AggiungiEvento (Evento evento)
    {
        Eventi.Add(evento);
    }

    public List<Evento> ListaEventiPerData (DateOnly dataScelta)
    {
        Console.WriteLine("Gli eventi disponibili nella data scelta sono:");
        List<Evento> listaEventiFiltrati = new List<Evento>();
        foreach (Evento evento in Eventi)
        {
            if (dataScelta == evento.Data)
            {
                listaEventiFiltrati.Add(evento);
            }
        }
        return listaEventiFiltrati;
    }

    public static void ListaEventi(List<Evento> Eventi)
    {
        Console.WriteLine("La lista degli eventi è: ");
        foreach (Evento evento in Eventi)
        {
            Console.WriteLine("---------");
            Console.WriteLine("nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}\n", evento.Titolo, evento.Data, evento.PostiMax, evento.PostiPrenotati, (evento.PostiMax - evento.PostiPrenotati));
        }
        Console.WriteLine();
    }

    public void NumeroEventi ()
    {
        int tot = 0;
        foreach (Evento evento in Eventi)
        {
            tot += 1;
        }
        Console.WriteLine("Il numero totale di eventi salvati è: {0}\n", tot);
    }

    public void SvuotaLista ()
    {
        Eventi.Clear();
        Console.WriteLine("La lista è stata svuotata\n");
    }

    public void NomeProgrammaEventi (ProgrammaEventi programmaEventi)
    {
        Console.WriteLine("Nome programma eventi {0}", programmaEventi.Titolo);
        foreach (Evento evento in Eventi)
        {
            Console.WriteLine(evento.ToString());           
        }
        Console.WriteLine("");
    }
}