using System.Collections.Generic;

try
{
    Console.Write("Per creare un nuovo programma di eventi inserire nome: ");
    string nomeProgrammaEvento = Console.ReadLine();
    ProgrammaEventi programmaEventiUser = new ProgrammaEventi(nomeProgrammaEvento);

    Console.Write("Quanti eventi vuoi aggiungere? ");
    int numeroEventi = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < numeroEventi; i++)
    {
        Console.Write("Per creare un nuovo evento inserire nome evento: ");
        string nomeEvento = Console.ReadLine();

        Console.Write("Inserire data evento (gg/mm/yyyy): ");
        DateOnly dataEvento = DateOnly.Parse((Console.ReadLine()));

        Console.Write("Inserire numero posti max evento: ");
        int postiMaxEvento = Convert.ToInt32(Console.ReadLine());

        Evento newEvento = new Evento(nomeEvento, dataEvento, postiMaxEvento);
        programmaEventiUser.AggiungiEvento(newEvento);
        Console.WriteLine("\n nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}\n", newEvento.Titolo, newEvento.Data, newEvento.PostiMax, newEvento.PostiPrenotati, (newEvento.PostiMax - newEvento.PostiPrenotati));
    }

    menu(programmaEventiUser);         
}
catch (GestoreEventiException e)
{
    Console.WriteLine(e.ToString());
}

void menu(ProgrammaEventi programmaEventi)
{
    Console.WriteLine("Seleziona l'azione");
    Console.WriteLine("1: Prenota posti");
    Console.WriteLine("2: Ricerca eventi per data");
    Console.WriteLine("3: Disdici prenotazioni");
    Console.WriteLine("4: Visualizza tutti gli eventi");
    Console.WriteLine("5: Visualizza numero totale di eventi");
    Console.WriteLine("6: Svuota lista");
    Console.WriteLine("7: Stampa un programma eventi");
    int action = Convert.ToInt32(Console.ReadLine());

    switch (action)
    {
        case 1:
            //prenota posti
            Console.Write("Inserisci data evento (gg/mm/yyyy): ");
            DateOnly dataEventoRicerca = DateOnly.Parse((Console.ReadLine()));
            Console.WriteLine();
            ProgrammaEventi.ListaEventi(programmaEventi.ListaEventiPerData(dataEventoRicerca));

            Console.Write("Per quale evento ti vuoi prenotare? Inserisci titolo: ");
            string ricercaEvento = Console.ReadLine();
            Console.Write("Quanti posti vuoi prenotare? ");
            int postiDaPrenotare = Convert.ToInt32(Console.ReadLine());

            foreach (Evento evento in programmaEventi.Eventi)
            {
                if (ricercaEvento == evento.Titolo)
                {
                    evento.PrenotaPosti(postiDaPrenotare);
                    Console.WriteLine("\n nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}\n", evento.Titolo, evento.Data, evento.PostiMax, evento.PostiPrenotati, (evento.PostiMax - evento.PostiPrenotati));
                }
            }

            funzioneCase(programmaEventi);

            break;

        case 2:
            //ricerca eventi per data
            Console.Write("Inserisci data evento (gg/mm/yyyy): ");
            DateOnly dataRicerca = DateOnly.Parse((Console.ReadLine()));
            List<Evento> listaFlitrata = programmaEventi.ListaEventiPerData(dataRicerca);
            ProgrammaEventi.ListaEventi(listaFlitrata);


            funzioneCase(programmaEventi);

            break;

        case 3:
            //disdici prenotazioni
            Console.Write("Inserisci data evento (gg/mm/yyyy): ");
            DateOnly dataEventoRicerca2 = DateOnly.Parse((Console.ReadLine()));
            ProgrammaEventi.ListaEventi(programmaEventi.ListaEventiPerData(dataEventoRicerca2));

            Console.Write("Per quale evento vuoi rimuovere prenotazioni? Inserisci titolo: ");
            string ricercaEvento2 = Console.ReadLine();

            foreach (Evento evento in programmaEventi.Eventi)
            {
                if (ricercaEvento2 == evento.Titolo)
                {
                    while (evento.PostiPrenotati > 0)
                    {
                        Console.Write("Vuoi disdire prenotazioni? [si/no] ");
                        string inputDisdire = Console.ReadLine();
                        if (inputDisdire == "si")
                        {
                            Console.Write("Quante prenotazioni vuoi disdire?: ");
                            int postiDaDisdire = Convert.ToInt32(Console.ReadLine());
                            if (postiDaDisdire > evento.PostiPrenotati)
                            {
                                Console.WriteLine("Non sono presenti {0} posti prenotati", postiDaDisdire);
                            }
                            else
                            {
                                evento.DisdiciPosti(postiDaDisdire);
                                Console.WriteLine("\n nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}\n", evento.Titolo, evento.Data, evento.PostiMax, evento.PostiPrenotati, (evento.PostiMax - evento.PostiPrenotati));
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }
                    
            funzioneCase(programmaEventi);

            break;

        case 4:
            //stampa tutti gli eventi
            ProgrammaEventi.ListaEventi(programmaEventi.Eventi);
            funzioneCase(programmaEventi);
            break;
        
        case 5:
            //stampa totale eventi
            programmaEventi.NumeroEventi();
            funzioneCase(programmaEventi);
            break;

        case 6:
            //svuota lista eventi
            programmaEventi.SvuotaLista();
            funzioneCase(programmaEventi);
            break;

        case 7:
            //stampa programma eventi
            programmaEventi.NomeProgrammaEventi(programmaEventi);
            funzioneCase(programmaEventi);
            break;
    }
}
void funzioneCase(ProgrammaEventi programmaEventi)
{
    Console.Write("Vuoi fare altro? [si/no] ");
    string inputUno = Console.ReadLine();
    if (inputUno == "si")
    {
        menu(programmaEventi);
    }
}
