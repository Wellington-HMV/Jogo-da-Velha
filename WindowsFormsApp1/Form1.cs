using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int xPlayer = 0, oPlayer = 0, empates = 0, rodadas = 0;
        bool turno = true, jogoFinal = false;
        string[] texto = new string[9];
        public Form1()
        {
            InitializeComponent();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            rodadas = 0;
            jogoFinal = false;
            for(int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ButtonIndex = btn.TabIndex;
            if (btn.Text == "" && jogoFinal == false)
            {
                if (turno)
                {
                    btn.Text = "X";
                    texto[ButtonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[ButtonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(2);
                }
            }
        }//final botão
        void Vencedor(int playerQueGanhou)
        {
            jogoFinal = true;
            if (playerQueGanhou == 1)
            {
                xPlayer++;
                Xpontos.Text = Convert.ToString(xPlayer);
                MessageBox.Show("Player X Winner! \nCongragulations!!!!!!");
                turno = true;
            }
            else
            {
                oPlayer++;
                Opontos.Text = Convert.ToString(oPlayer);
                turno = false;
                MessageBox.Show("Player O Winner! \nCongragulations!!!!!!");
            }
        }
        void Checagem(int checagemPlayer)
        {
            string suporte = "";
            if (checagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }//final suporte
            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(checagemPlayer);
                        return;
                    }
                }
            }//final loop horizontal
            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(checagemPlayer);
                        return;
                    }
                }
            }//final loop vertical

            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Vencedor(checagemPlayer);
                    return;
                }//diagonal principal

            }
            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(checagemPlayer);
                    return;
                }//diagonal secundária
            }//final loop diagonal
            if (rodadas == 9 && jogoFinal == false)
            {
                empates++;
                Draw.Text = Convert.ToString(empates);
                MessageBox.Show("Draw!");
                jogoFinal = true;
                return;
            }
        }
    }
}
