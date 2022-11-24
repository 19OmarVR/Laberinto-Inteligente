using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Laberinto_Inteligente
{
    public partial class Form1 : Form
    { 
        //Indices de la Matriz
        //0 = Camino
        //1 = Pared
        //2 = Entrada
        //3 = Salida
        int[,] Laberinto = new int[42, 42];

        //Constructor
        public Form1()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1F618D");
        }

        //------------------------------------------------------- Crear Laberinto -------------------------------------------------------------------------------


        //Boton Crear Laberinto
        private void BT_CrearLaberinto_Click(object sender, EventArgs e)
        {
            //Variables globales
            int i, j;


            //Objeto de la clase Random 
            Random random = new Random();


            //Limpiar todo el Laberinto con 1
            for (i = 0; i < 42; i++)
            {
                for (j = 0; j < 42; j++)
                {
                    Laberinto[i, j] = 1;
                }
            }

            //Colocar Paredes
            int rand, totaldecamino, cambios;
            for (i = 1; i <= 40; i++)
            {
                rand = random.Next(33, 45);
                totaldecamino = Convert.ToInt32((rand * 40) / 100);
                cambios = 0;
                while (cambios != totaldecamino)
                {
                    rand = random.Next(1, 41);
                    if (Laberinto[i, rand] == 0)
                    {
                        //Bloque ya usado
                    }
                    else
                    {
                        Laberinto[i, rand] = 0;
                        cambios++;
                    }
                }
            }

            //Establecer salidas y entradas
            int salida;
            salida = random.Next(1, 41);
            //Entrada
            Laberinto[1, 0] = 2;

            //Salida
            Laberinto[41, salida] = 3;

            //Asegurar que hay un camino
            int mut;
            mut = random.Next(1, 5);
            //MessageBox.Show("Salida: " + salida);
            Camino(mut, salida);

            //Asegurar que hay un segundo camino
            Camino2(salida);

            //mostrar Laberinto en el TextBox
            String texto = "";
            for (i = 0; i < 42; i++)
            {
                for (j = 0; j < 42; j++)
                {
                    texto += Laberinto[i, j] + " ";
                }
                texto += Environment.NewLine;
            }
            TB_LaberintoTabla.Text = texto;

        }

        //Funcion para hacer primer camino
        public void Camino(int mut, int salida)
        {
            //Variables
            int i, j, bloques = 0;

            //Indices de tamaño en alto de el camino
            switch (mut)
            {
                case 1:
                    //1 = 8 lineas de a 5 bloques hacia abajo
                    mut = 8;
                    bloques = 5;
                    break;
                case 2:
                    //2 = 10 lineas de a 4 bloques hacia abajo
                    mut = 10;
                    bloques = 4;
                    break;
                case 3:
                    //3 = 20 lineas de a 2 bloques hacia abajo
                    mut = 20;
                    bloques = 2;
                    break;
                case 4:
                    //4 = 10 lineas de a 4 bloques hacia abajo\
                    mut = 4;
                    bloques = 10;
                    break;
            }
            //MessageBox.Show("Cantidad de bloques a bajar: " + bloques + "    Numero de veces: " + mut);

            //Inicializar puntos Y y X en la posicion [1,1]
            int x = 0, y = 1;
            int espacios = 0;
            float decimales = 0;
            float salidad = (float)salida;

            //ciclo del numero de veces que el camino va a bajar
            for (i = 0; i < mut; i++)
            {
                //Bajar el numero de bloques correspondiente
                for (j = 0; j < bloques; j++)
                {
                    x++;
                    Laberinto[x, y] = 0;
                }

                //Calculos de cuantos bloques a la derecha
                espacios = ((int)(salida / mut)); //Optener numero entero de bloques a la derecha

                decimales += (salidad / mut) - espacios;  //Optener solo el porcentaje de la operacion anterior e irla iterando

                //Cuando los decimales alcancen un 1 o mas a un 1
                if (decimales >= 1)
                {
                    //Aumentar ese 1 a los bloques
                    espacios += 1;
                    //Quitar uno a los decimales 
                    decimales -= 1;
                }
                //MessageBox.Show("Total a la derecha: " + espacios + "   Decimales: " + decimales);

                //Limpiar Espacios bloques hacia la derecha
                for (j = 0; j < espacios; j++)
                {
                    y++;
                    Laberinto[x, y] = 0;
                }
            }
            //Repintar un cuadro xd por si acazo
            Laberinto[40, 41] = 1;
        }

        //funcion para hacer segundo camino
        public void Camino2(int salida)
        {
            Random rand = new Random();

            int direccion=0;
            int x = 1;
            int y = 1;

            while(x!=40 && y != salida)
            {
                direccion = rand.Next(1, 3);
                switch (direccion) 
                {
                    case 1:
                        //Abajo
                        if (x != 40)
                        {
                            x++;
                            Laberinto[x, y] = 0;
                        }
                        break;
                    case 2:
                        //Derecha
                        if (y != salida)
                        {
                            y++;
                            Laberinto[x, y] = 0;
                        }
                        break;
                }
            }
            if (y == salida)
            {
                while(x != 41)
                {
                    Laberinto[x, y] = 0;
                    x++;
                }
            }
            if (x == 40)
            {
                while (y != salida)
                {
                    Laberinto[x, y] = 0;
                    y++;
                }
            }
        }



        //------------------------------------------------------- Dibujar Laberinto -------------------------------------------------------------------------------
        private void BT_DibujarLAberinto_Click(object sender, EventArgs e)
        {
            //Variables
            int tamaño = 15;

            //Objeto de la clase Graphics
            Graphics g = this.CreateGraphics();

            //Crear colores
            Brush camino = new SolidBrush(Color.White);
            Brush pared = new SolidBrush(Color.Black);
            Brush entrada = new SolidBrush(Color.Red);
            Brush salida = new SolidBrush(Color.Green);

            //Revisar todas las lineas de la matriz y colorear segun el numero de indice
            int posicion_x = tamaño;
            int posicion_y = tamaño;

            for (int i = 0; i < 42; i++)
            {
                for (int j = 0; j < 42; j++)
                {
                    int numero = Laberinto[i, j];
                    switch (numero)
                    {
                        case 0:
                            g.FillRectangle(camino, posicion_x, posicion_y, tamaño, tamaño);
                            break;
                        case 1:
                            g.FillRectangle(pared, posicion_x, posicion_y, tamaño, tamaño);
                            break;
                        case 2:
                            g.FillRectangle(entrada, posicion_x, posicion_y, tamaño, tamaño);
                            break;
                        case 3:
                            g.FillRectangle(salida, posicion_x, posicion_y, tamaño, tamaño);
                            break;
                    }
                    posicion_x += tamaño;
                }
                posicion_y = posicion_y + tamaño;
                posicion_x = tamaño;
            }
        }


        //------------------------------------------------------- Encontrar Camino Laberinto -------------------------------------------------------------------------------
        
        //Boton Encontrar Camino
        private void EncontrarCamino(object sender, EventArgs e)
        {
            //Objetos
            Random rand = new Random();
            Graphics g = this.CreateGraphics();

            //Pinceles
            Brush Recorrido = new SolidBrush(Color.Orange);
            Brush Regresar = new SolidBrush(Color.Gray);
            int TamañoPixel = 15;

            //Pila  de recorrido
            Stack<Point> Ruta = new Stack<Point>();

            //Matriz aux
            int[,] Matriz = new int[Laberinto.GetLength(0), Laberinto.GetLength(1)];

            //Igualar Laberinto a Matriz aux
            for (int i = 0; i < Matriz.GetLength(0); i++)
            {
                for (int j = 0; j < Matriz.GetLength(1); j++)
                {
                    Matriz[i, j] = Laberinto[i, j];
                }
            }

            //Marca como visitada la primera celda [1,1]
            Ruta.Push(new Point(1, 1));
            //Primer casilla la marca como visitada
            Matriz[1, 1] = 2;
            //Guarda las coordenadas de la celda a evaluar
            Point CeldaActual;
            //Numero random que indica la celda a la cual se dirijira
            int val = 0;
            //Guarda las celdas a las que puede avanzar
            List<int> PosiblesCeldas = new List<int>();


            while (Ruta.Count != 0)
            {
                //Guarda como celda actual a lo que esta al frente de la pila
                CeldaActual = Ruta.Peek();
                g.FillRectangle(Recorrido, (CeldaActual.Y + 1) * TamañoPixel, (CeldaActual.X + 1) * TamañoPixel, TamañoPixel, TamañoPixel);
                Thread.Sleep(100);
                Ruta.Pop();//Saca la celda que esta al frente de la pila
                PosiblesCeldas = RevisarVecinos(CeldaActual, Matriz);

                if (PosiblesCeldas.Count != 0)//Si existen vecinos
                {
                    Ruta.Push(CeldaActual);//Como si tiene vecinos la agrega a la ruta

                    if (PosiblesCeldas.Contains(5) || PosiblesCeldas.Contains(6) || PosiblesCeldas.Contains(7) || PosiblesCeldas.Contains(5))
                    {
                        //Encontro la salida
                        break;
                    }

                    val = rand.Next(0, PosiblesCeldas.Count);

                    if (PosiblesCeldas.ElementAt(val) == 1)//Se movera arriba
                    {
                        Matriz[CeldaActual.X - 1, CeldaActual.Y] = 2;//Se marca la celda como visitada
                        Ruta.Push(new Point(CeldaActual.X - 1, CeldaActual.Y));
                    }
                    else if (PosiblesCeldas.ElementAt(val) == 2)//Se movera hacia abajo
                    {

                        Matriz[CeldaActual.X + 1, CeldaActual.Y] = 2;//Se marca la celda como visitada
                        Ruta.Push(new Point(CeldaActual.X + 1, CeldaActual.Y));
                    }
                    else if (PosiblesCeldas.ElementAt(val) == 3)//Se movera a la izquierda
                    {
                        Matriz[CeldaActual.X, CeldaActual.Y - 1] = 2;//Se marca la celda como visitada
                        Ruta.Push(new Point(CeldaActual.X, CeldaActual.Y - 1));
                    }
                    else if (PosiblesCeldas.ElementAt(val) == 4)//Se movera a la derecha
                    {
                        Matriz[CeldaActual.X, CeldaActual.Y + 1] = 2;//Se marca la celda como visitada
                        Ruta.Push(new Point(CeldaActual.X, CeldaActual.Y + 1));
                    }
                }
                else
                {
                    g.FillRectangle(Regresar, (CeldaActual.Y + 1) * TamañoPixel, (CeldaActual.X + 1) * TamañoPixel, TamañoPixel, TamañoPixel);
                }

                PosiblesCeldas.Clear();
            }


        }

        //Funcion para RevisarVecinos
        public List<int> RevisarVecinos(Point CeldaActual, int[,] Matriz)
        {
            List<int> PosiblesCeldas = new List<int>();

            /*
                1: arriba
                2: abajo
                3: izquierda
                4: derecha
                5: salida arriba
                6: salida abajo
                7; salida izquierda
                8: salida derecha
             */

            if (CeldaActual.X > 0)
            {
                if (Matriz[CeldaActual.X - 1, CeldaActual.Y] == 0)//Si la celda de arriba es igual a cero
                {
                    PosiblesCeldas.Add(1);
                }
                else if (Matriz[CeldaActual.X - 1, CeldaActual.Y] == 3)//Si la celda de arriba es igual a la salida
                {
                    PosiblesCeldas.Add(5);
                }
            }

            if (CeldaActual.X < Matriz.GetLength(0) - 1)
            {
                if (Matriz[CeldaActual.X + 1, CeldaActual.Y] == 0)//Si la celda de abajo esta libre
                {
                    PosiblesCeldas.Add(2);
                }
                else if (Matriz[CeldaActual.X + 1, CeldaActual.Y] == 3)//Si la celda de abajo es igual a la salida
                {
                    PosiblesCeldas.Add(6);
                }
            }


            if (CeldaActual.Y > 0)
            {
                if (Matriz[CeldaActual.X, CeldaActual.Y - 1] == 0)//Si la celda de la izquierda esta libre
                {
                    PosiblesCeldas.Add(3);
                }
                else if (Matriz[CeldaActual.X, CeldaActual.Y - 1] == 3)//Si la celda de izquierda es igual a la salida
                {
                    PosiblesCeldas.Add(7);
                }
            }

            if (CeldaActual.Y < Matriz.GetLength(1) - 1)
            {
                if (Matriz[CeldaActual.X, CeldaActual.Y + 1] == 0)//Si la celda de la derecha esta libre
                {
                    PosiblesCeldas.Add(4);
                }
                else if (Matriz[CeldaActual.X, CeldaActual.Y + 1] == 3)//Si la celda de derecha es igual a la salida
                {
                    PosiblesCeldas.Add(8);
                }
            }

            return PosiblesCeldas;
        }

        //------------------------------------------------------- Movimientos del Jugador -------------------------------------------------------------------------------
        //Variables Globales
        int direccion, x , y , Evaluar;
        int Px, Py;
        int tamaño = 15;

        //Indice de Direcciones
        //1 = Arriba
        //2 = Abajo
        //3 = Derecha 
        //4 = Izquierda
        //5 = Inicio de Jugador

        //Iniciar Jugador
        private void BT_Jugador_Click(object sender, EventArgs e)
        {
            BT_Jugador.Enabled = false;
            direccion = 5;
            Movimientos(direccion); 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                direccion = 1;
                Movimientos(direccion);
            }
            if (e.KeyData == Keys.S)
            {
                direccion = 2;
                Movimientos(direccion);
            }
            if (e.KeyData == Keys.D)
            {
                direccion = 3;
                Movimientos(direccion);
            }
            if (e.KeyData == Keys.A)
            {
                direccion = 4;
                Movimientos(direccion);
            }
        }
        //Funcion para el movimiento
        public void Movimientos(int direccion)
        {
            //Objeto de la clase Graphics
            Graphics g = this.CreateGraphics();

            //Crear colores
            Brush Jugador = new SolidBrush(Color.Yellow);
            Brush Camino = new SolidBrush(Color.White);
            Brush Ganar = new SolidBrush(Color.Green);

            switch (direccion)
            {
                

                //Mover a Arriba
                case 1:
                    Evaluar = (x - 1);
                    
                    if (Laberinto[Evaluar, y] != 1 && Laberinto[Evaluar, y] != 2)
                    {
                        g.FillRectangle(Camino, Py, Px, tamaño, tamaño);
                        x -= 1;
                        Px = Px - tamaño;
                        g.FillRectangle(Jugador, Py, Px, tamaño, tamaño);
    
                    }
                    break;

                //Mover a Abajo
                case 2:
                    Evaluar = x + 1;
                    if (Laberinto[Evaluar, y] != 1 && Laberinto[Evaluar, y] != 2)
                    {
                        g.FillRectangle(Camino, Py, Px, tamaño, tamaño);
                        x += 1;
                        Px = Px + tamaño;
                        g.FillRectangle(Jugador, Py, Px, tamaño, tamaño);
           
                    }
                    break;

                //Mover a Derecha
                case 3:
                    Evaluar = y + 1;
                    if (Laberinto[x, Evaluar] != 1 && Laberinto[Evaluar, y] != 2)
                    {
                        g.FillRectangle(Camino, Py, Px, tamaño, tamaño);
                        y += 1;
                        Py = Py + tamaño;
                        g.FillRectangle(Jugador, Py, Px, tamaño, tamaño);
                      
                    }
                    break;

                //Mover a Izquierda
                case 4:
                    Evaluar = y - 1;
                    if (Laberinto[x, Evaluar] != 1 && Laberinto[Evaluar, y] != 2)
                    {
                        g.FillRectangle(Camino, Py, Px, tamaño, tamaño);
                        y-= 1;
                        Py = Py - tamaño;
                        g.FillRectangle(Jugador, Py, Px, tamaño, tamaño);
                   
                    }
                    break;
                //Caso de inicio
                case 5:

                    x = 1;
                    y = 1;
                    Px = 30;
                    Py = 30;
                    g.FillRectangle(Jugador, Px, Py, tamaño, tamaño);

                    break;

                default:
                    MessageBox.Show("Qpd ni existe");
                    break;
            }
            Evaluar = 0;
            if (Laberinto[x, y] == 3)
            {
                MessageBox.Show("Ganaste");
                textBox1.Text = "";
                BT_Jugador.Enabled = true;
                g.FillRectangle(Ganar, Py, Px, tamaño, tamaño);
            }

        }

       
    }
}