using System;
using System.Collections.Generic;
using System.Text;

namespace Persons.Model
{
    public class PersonDatabase
    {
        //------------------------------------Tvorba databáze---------------------------------------------
        //samotné úložiště dat
        private static Dictionary<string, Person> database;
        //promněná ukazující na danou instanci databáze
        private static PersonDatabase singleInstance = null;

        //zamykací objekt
        private static readonly object lockingObject = new object();

        //konstruktor databáze
        private PersonDatabase()
        {
            database = new Dictionary<string, Person>();
        }

        //vlastnost databáze vracející promněnou odkazující na konkrétní 1 instanci
        public static PersonDatabase Instance
        {
            //návrat (pouze pro čtení)
            get
            {
                //zamčení procesu tvorby a odkazování na instanci kvůli multithredingu
                lock (lockingObject)
                {
                    //tvorba nové instance pokud neexistuje
                    if (database == null)
                    {
                        singleInstance = new PersonDatabase();
                    }
                }

                //pokud existuje - vrátí ji
                return singleInstance;
            }
        }

        //------------------------------------Práce s databází---------------------------------------------
        //počet záznamů
        public int Count { get { return database.Count; } private set { } }

        //vložení nové osoby do databáze
        public void Add(Person newPerson) => database.Add(newPerson.PersonalIdentificationNumber, newPerson);

        //smazání existující osoby z databáze
        public void Remove(Person person) => database.Remove(person.PersonalIdentificationNumber);

        //vrácení celé databáze
        public Dictionary<string, Person> GetDatabase() => database;
    }
}
