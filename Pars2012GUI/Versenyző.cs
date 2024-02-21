using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars2012GUI
{
    public class Versenyző
    {
        string nev;
        string csoport;
        string nemzetTeljes;
        string kód;
        string nemzet;
        List<double> dobasok = new List<double>(); // X = -1     - = -2
        List<string> dobasokErdeti = new List<string>();
        bool automatikusanTovabb;
        double eredmény;


        public Versenyző(string sor)
        {
            List<string> mezo = sor.Split(';').ToList();
            List<double> lista = new List<double>();
            List<string> listaErdeti = new List<string>();
            for (int i = 3; i < mezo.Count(); i++)
            {
                if (mezo[i] == "-")
                {
                    lista.Add(-2);
                }
                else if (mezo[i] == "X")
                {
                    lista.Add(-1);
                }
                else
                {
                    lista.Add(double.Parse(mezo[i]));
                }
                listaErdeti.Add(mezo[i]);
            }

            this.nev = mezo[0];
            this.csoport = mezo[1];
            this.nemzetTeljes = mezo[2];
            this.dobasok = lista;
            this.dobasokErdeti = listaErdeti;

            automatikusanTovabb = dobasok.Contains(-2);
            eredmény = dobasok.Max(x => x);

            this.kód = mezo[2][^4..^1];
            this.nemzet = mezo[2][0..^6];
        }


        public string Nev { get => nev; }
        public string Csoport { get => csoport; }
        public string NemzetTeljes { get => nemzetTeljes; }
        public string Kód { get => kód; }
        public string Nemzet { get => nemzet; }
        public List<double> Dobasok { get => dobasok; }

        public bool AutomatikusanTovabb { get => automatikusanTovabb; }
        public double Eredmény { get => eredmény; }
        public List<string> DobasokErdeti { get => dobasokErdeti; }

        public override string ToString()
        {
            return $"{nev};{csoport};{nemzetTeljes};{string.Join(';', dobasokErdeti)}";
        }
    }
}
