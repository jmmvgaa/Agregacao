using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_4___Agregação
{
    class Partida
    {
        private DateTime data;
        private Time timeCasa;
        private Time timeVisitante;
        private int placarCasa;
        private int placarVisitante;

        public Partida(DateTime dataPartida, Time Tcasa, Time Tvisitante)
        {
            this.data = dataPartida;
            this.timeCasa = Tcasa;
            this.timeVisitante = Tvisitante;
            this.placarCasa = 0;
            this.placarVisitante = 0;
        }

        public int golCasa()
        {
            return placarCasa++;
        }

        public int golVisitante()
        {
            return placarVisitante++;
        }

        public string getPlacar()
        {
            if (this.placarCasa > this.placarVisitante)
            {
                this.timeCasa.Vitorias += 1;
                this.timeVisitante.Derrotas += 1;
                return "O vencedor da partida em " +
                    this.data.ToString("dd-MM-yyyy") +
                    " entre " + this.timeCasa.Nome +
                    " e " + this.timeVisitante.Nome +
                    " foi o time " + this.timeCasa.Nome +
                    " com o placar de " + this.placarCasa.ToString() +
                    " a " + this.placarVisitante.ToString();
            }

            if (this.placarCasa == this.placarVisitante)
            {
                this.timeCasa.Empates += 1;
                this.timeVisitante.Empates += 1;

                return "Sem vencedor na partida em " + this.data.ToString("dd-MM-yyyy");
            }

            else
            {
                this.timeVisitante.Vitorias += 1;
                this.timeCasa.Derrotas += 1;
                return "O vencedor da partida em " +
                    this.data.ToString("dd-MM-yyyy") +
                    " entre " + this.timeCasa.Nome +
                    " e " + this.timeVisitante.Nome +
                    " foi o time " + this.timeVisitante.Nome +
                    " com o placar de " + this.placarVisitante.ToString() +
                    " a " + this.placarCasa.ToString();
            }
        }


        public void jogar()
        {
            Random rand = new Random();
            Int32 gols = rand.Next(0, 15);

            Console.WriteLine("Jogando...");

            for (int i = 1; i <= gols; i++)
            {
                Int32 golvar = rand.Next(0, 2);
                if (golvar == 1)
                {
                    this.golCasa();
                    this.timeCasa.gol(rand.Next(1, 11));
                }

                else
                {
                    this.timeVisitante.gol(rand.Next(1, 11));
                    this.golVisitante();
                }
            }

            Console.WriteLine("Total de gols: " + gols);
        }
    }
}
