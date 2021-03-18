using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolesAvl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int cont = 0;
        int dato = 0;
        int datb = 0;
        int cont2 = 0;
        DibujaAVL arbolAVL = new DibujaAVL(null);
        DibujaAVL arbolAVL_Letra = new DibujaAVL(null);
        Graphics g;
        int pintaR = 0;

        private void Form1_Paint(object sender, PaintEventArgs en)
        {
            en.Graphics.Clear(this.BackColor);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;
            arbolAVL.DibujarArbol(g, this.Font,
            Brushes.White, Brushes.Black, Pens.White, datb, Brushes.Black);
            datb = 0;
            if (pintaR == 1)
            {
                arbolAVL.colorear(g, this.Font, Brushes.Black, Brushes.Yellow, Pens.Blue, arbolAVL.Raiz, post.Checked, ino.Checked, pre.Checked);
                pintaR = 0;
            }
            if (pintaR == 2)
            {
                arbolAVL.colorearB(g, this.Font, Brushes.White, Brushes.Red, Pens.White, arbolAVL.Raiz,
int.Parse(valor.Text));
                pintaR = 0;

            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);
                    arbolAVL.Insertar(dato);
                    valor.Clear();
                    valor.Focus();
                    lblAltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    cont++;
                    Refresh();
                    Refresh();
                }
                catch (Exception ex)
                {
                    errores.SetError(valor, "Debe ser numérico");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    datb = int.Parse(valor.Text);
                    arbolAVL.buscar(datb);
                    pintaR = 2;
                    Refresh();
                    valor.Clear();
                }
                catch (Exception ex)
                {
                    errores.SetError(valor, "Debe ser numérico");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);
                    valor.Clear();
                    arbolAVL.Eliminar(dato);
                    lblAltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    Refresh();
                    Refresh();
                    cont2++;
                }
                catch (Exception ex)
                {
                    errores.SetError(valor, "Debe ser nullérico");
                }
            }
            Refresh(); Refresh(); Refresh();
        }

        private void valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                errores.Clear();
                if (valor.Text == "")
                {
                    errores.SetError(valor, "Valor obligatorio");
                }
                else
                {
                    try
                    {
                        dato = int.Parse(valor.Text);
                        if (dato > 0)
                        {
                            arbolAVL.Insertar(dato);
                            valor.Clear();
                            valor.Focus();
                            lblAltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                            cont++;
                            Refresh();
                            Refresh();
                        }
                        else
                        {
                            errores.SetError(valor, "Debe ser un número mayor que 0");
                        }
                    }
                    catch (Exception ex)
                    {
                        errores.SetError(valor, "Debe ser numérico");
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (post.Checked)
            {
                arbolAVL.print = " ";
                arbolAVL.PostOrder(arbolAVL.Raiz);
                Orden.Text = arbolAVL.print;
            }
            else if (pre.Checked)
            {
                arbolAVL.print = " ";
                arbolAVL.PreOrder(arbolAVL.Raiz);
                Orden.Text = arbolAVL.print;
            }
            else if (ino.Checked)
            {
                arbolAVL.print = " ";
                arbolAVL.InOrder(arbolAVL.Raiz);
                Orden.Text = arbolAVL.print;
            }
        }
    }
}

