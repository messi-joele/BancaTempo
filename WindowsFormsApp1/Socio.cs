using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
     class Socio   
    {
        private string nome;
        private string cognome;
        private int debito;
        private string telefono;
        private bool segreteria;


        public Socio(string nome, string cognome, int debito, string telefono, bool segreteria)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.debito = debito;
            this.telefono = telefono;
            this.segreteria = segreteria;
            Prestazioni = new List<Prestazione>();
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nuovonome)
        {
            if (!String.IsNullOrWhiteSpace(nuovonome))
                cognome = nuovonome;
            else
                throw new Exception("Cognome non valido");
        }

        public string GetCognome()
        {
            return nome;
        }

        public void SetCognome(string nuovocognome)
        {
            if (!String.IsNullOrWhiteSpace(nuovocognome))
                cognome = nuovocognome;
            else
                throw new Exception("Cognome non valido");
        }

        public double GetNumero()
        {
            return GetNumero();
        }

        public void SetNumero(string nuovonumero)
        {
            if (!String.IsNullOrWhiteSpace(nuovonumero) && nuovonumero.Length == 10)
                telefono = nuovonumero;
            else
                throw new Exception("Numero di Telefono non valido");
        }

        public int GetDebito()
        {
            return debito;
        }

        public void SetDebito(int nuovodebito)
        {
            debito=nuovodebito;
        }

        public bool GetSegreteria()
        {
            return segreteria;
        }

        public void SetSegreteria(bool nuovasegreteria)
        {
            if (!String.IsNullOrWhiteSpace(nuovasegreteria.ToString()))
                segreteria = nuovasegreteria;
            else
                throw new Exception("Partecipazione alla segreteria non valida");
        }
        public List<Prestazione> Prestazioni
    }

    
    

   
}
