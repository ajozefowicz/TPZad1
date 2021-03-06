﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class DataRepository
    {
        private DataContext dataContext;
        private Wypelnianie wypelniacz;

        public DataContext DataContex
        {
            set => dataContext = value;
        }
        public Wypelnianie Wypelniacz
        {
            set => wypelniacz = value;
        }

        public void Wypelnij()
        {
            wypelniacz.Wypelnij(ref dataContext);
        }

        ////TODO dodaj inne metody by dodawac elementy jak dodaj/usun/zmien Egzemplarz, Uzytkownika - uwaga rozne klasy bo dziedziczenie
        ///
        //Add
        public void AddUzytkownika(Uzytkownik uz)
        {
            dataContext.listaUzytkownikow.Add(uz);
        }

        public void AddEgzemplarz(Egzemplarz eg)
        {
            dataContext.egzemplarze.Add(eg.Id, eg);
        }

        public void AddZdarzenieWypozyczenie(Uzytkownik uz, Egzemplarz eg, DateTime dataWypoz)
        {
            Zdarzenie zd1 = new Zdarzenie();
            zd1.Kto = uz;
            zd1.Co = eg;
            zd1.KiedyWypozyczyl = dataWypoz;
            dataContext.zdarzenia.Add(zd1);
        }

        public void AddZdarzenieZwrot(Uzytkownik uz, Egzemplarz eg, DateTime dataWypoz, DateTime dataZwrotu)
        {
            Zdarzenie zd1 = new Zdarzenie();
            zd1.Kto = uz;
            zd1.Co = eg;
            zd1.KiedyWypozyczyl = dataWypoz;
            zd1.KiedyWypozyczyl = dataZwrotu;
            zd1.Kara = (dataZwrotu - dataWypoz).Days;
            //TimeSpan wynik = dataZwrotu - dataWypoz;
            //zd1.Kara = wynik.Days;
            dataContext.zdarzenia.Add(zd1);
        }

        public void AddOpisStanuEgzemplarza(DateTime dataZakupu, Boolean stan, string opisStanu, Egzemplarz ktoryEgzemplarz)
        {
            OpisStanuEgzemplarza ose = new OpisStanuEgzemplarza();
            ose.DataZakupu = dataZakupu;
            ose.Stan = stan;
            ose.OpisStanu = opisStanu;
            ose.KtoryEgzemplarz = ktoryEgzemplarz;
            dataContext.opisStanow.Add(ose);
        }

        /// Get

        public Uzytkownik GetUzytkownika(int pesel) //// TODO sprawdz czy dziala
        {
            Predicate<Uzytkownik> predykat = FindPoints;

            bool FindPoints(Uzytkownik uzyt)
            {
                return uzyt.Pesel == pesel;
            }

            return dataContext.listaUzytkownikow.Find(predykat);
        }

        public Egzemplarz GetEgzemplarz(int id) //// TODO sprawdz czy dziala czy pobiera klucz czy numer elem w kolejnosci
        {

            return dataContext.egzemplarze[id];
        }

        public Zdarzenie GetZdarzenie(int nr)
        {
            return dataContext.zdarzenia[nr];
        }

        public OpisStanuEgzemplarza GetOpisStanuEgzemplarza(int nr)
        {
            return dataContext.opisStanow[nr];
        }


        /////
        ///
        public List<Uzytkownik> GetAllUzytkownikow()
        {
            return dataContext.listaUzytkownikow;
        }

        ////// TODO jak zwrocic wszystkie Ksiazki - Egzemplarze
        //


        ///// TODO jak zwrocic wszyskie Zdarzenia ????

        /////
        ///

        public List<OpisStanuEgzemplarza> GetAllOpisStanuEgzemplarzas()
        {
            return dataContext.opisStanow;
        }


        public void UpdateUzytkownik(Uzytkownik stary, Uzytkownik nowy)
        {
            stary.Adres = nowy.Adres;
            stary.Imie = nowy.Imie;
            stary.Nazwisko = nowy.Nazwisko;
            stary.Pesel = nowy.Pesel;
        }

        public void UpdateEgzemplarz(Egzemplarz stary, Egzemplarz nowy)
        {
            stary.Id = nowy.Id;
            stary.LicznikWypozyczen = nowy.LicznikWypozyczen;
            stary.Stan = nowy.Stan;
            stary.Tytul = nowy.Tytul;
            stary.Zarezerwowany = nowy.Zarezerwowany;
        }

        public void UpdateZdarzenie(Zdarzenie stary, Zdarzenie nowy)
        {
            stary.Co = nowy.Co;
            stary.Kara = nowy.Kara;
            stary.KiedyWypozyczyl = nowy.KiedyWypozyczyl;
            stary.KiedyZwrocil = nowy.KiedyZwrocil;
            stary.Kto = nowy.Kto;
        }

        public void UpdateOpisStanowEgzemplarza(OpisStanuEgzemplarza stary, OpisStanuEgzemplarza nowy)
        {
            stary.DataZakupu = nowy.DataZakupu;
            stary.KtoryEgzemplarz = nowy.KtoryEgzemplarz;
            stary.OpisStanu = nowy.OpisStanu;
            stary.Stan = nowy.Stan;
        }

        ////// Delete
        ///

        public void DeleteUzytkownik(Uzytkownik uz)
        {
            dataContext.listaUzytkownikow.Remove(uz);
        }

        public void DeleteEgzemplarz(int klucz)
        {
            dataContext.egzemplarze.Remove(klucz);
        }

        public void DeleteZdarzenie(Zdarzenie zd)
        {
            dataContext.zdarzenia.Remove(zd);
        }

        public void DeleteOpisStanuEgzemplarza(OpisStanuEgzemplarza ose)
        {
            dataContext.opisStanow.Remove(ose);
        }

    }
}
