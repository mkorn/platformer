using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace пл
{
	public partial class MainForm : Form
	{
		/*string[] A = new string[]{		//"матрица", соотносимая со схемой платформ
			"2222222222222222222222222",
			"2000000000111000000000002",
			"2000000000000000000000002",
			"2000000000000000011100002",
			"2000000000000000000000002",
			"2000011111100000000000002",
			"2000000000000000000000002",
			"2000000000000000000000002",
			"2011111000000001111110002",
			"2000000000000000000000002",
			"2000000000001111000000002",
			"2000000000000000000000002",
			"2000000011100000000000002",
			"2222222222222222222222222"
		};*/
		int[,] A1 = new int[,]{
		{ 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },	//3 - стены
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },	
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },	//2 - платформы
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 3 },
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },	//1- монетки
		{ 3, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
		{ 3, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 3 },
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
		{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
		{ 3, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
		{ 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 }
		};
		int coin=0;			//количество съеденных монеток
		/*string s="1";		//для сравнения; рисовка платформ
		string s1="2";		//для сравнения; рисовка стен
		string s2="0";		//для сравнения; проверка падения*/

		enum Directions
		{
			stop = 0,
			right = 1,
			left = 2,
			jump = 4
		};

		Directions D;				//направление движения
		int j=0;					//флаг запрета падения
		int k=0;					//счетчик прыжков
		Random R = new Random(DateTime.Now.Millisecond);
		Random M = new Random();
		public MainForm ()
		{
			InitializeComponent ();
			panel1.Parent = panel2;
			label1.Parent = panel2;
			label2.Parent = panel3;
			for (int i=0; i<14; i++)
			{
				for ( int j=0; j<25; j++ )
				{
					if ( A1[i, j]==2 )
					{
						Panel panel = new Panel ();
						panel.Parent = panel2;
						panel.Location = new Point (40*j, 50*i);
						panel.BackColor = Color.SlateBlue;
						panel.Size = new Size (40, 50);
						panel.TabIndex = 3;
					}
					if ( A1[i, j]==3 )
					{
						Panel p = new Panel ();
						p.Parent = panel2;
						p.Location = new Point (40*j, 50*i);
						p.BackColor = Color.SandyBrown;
						p.Size = new Size (40, 50);
						p.TabIndex = 3;
					}
				}
			}
			Panel Coins = new Panel();
			Coins.Parent = panel2;
			Coins.Location = new Point ( 40, 50 );
			Bitmap bm = new Bitmap("/home/user/Рабочий стол/пл/пл/bin/Debug/moneta.png");
			Coins.BackgroundImage = bm;
			Coins.Size = new Size (40, 40);

			Timer timer = new Timer();
			timer.Interval = 100;
			timer.Enabled = true;
			timer.Tick += new EventHandler(timer_Tick);
		}
		Panel[,] m = new Panel[14, 25];
		Panel monster = new Panel();
		public void FindCoin ( int q, int o )			//процедура съедания монетки
		{
			if ( A1[q, o]==1 )		//если в ячейке есть монетка
			{
				coin++;
				label1.Text=coin.ToString();
				A1[q, o]=0;
				m[q, o].BackgroundImage = null;
				m[q, o].SendToBack();
			}
		}
		public void NewGame()
		{
			for (int i=0; i<14; i++)
			{
				for ( int j=0; j<25; j++ )
				{
					if ( A1[i, j]==1 )
					{
						coin=0;
						label1.Text=coin.ToString();
						A1[i, j]=0;
						m[i, j].BackgroundImage = null;
						m[i, j].SendToBack();
					}
				}
			}
			monster.BackgroundImage=null;
			panel1.Location = new Point(40, 600);
			panel3.Visible = false;
			panel2.Visible = true;
		}

		void timer_Tick (object sender, EventArgs e)
		{
			int t = panel1.Top;			//высота в данный момент; для сравнения
			int l = panel1.Left;		//горизональная координата в данный момент; для сравнения
			double x = R.NextDouble();
			if ( x < 0.5 )
			{
				int y = M.Next(1, 14);
				for (int c=0; c<25 ; c++ )
				{
					if ( A1[y, c]==2 )			//поиск платформы
					{
						if ( A1[y-1, c]==1 || ((int)t/50==y-1 && (int)l/40==c) )	//если есть монетка в ячейке
							continue;
						else
						{
							m[y-1, c] = new Panel();
							m[y-1, c].Parent = panel2;
							m[y-1, c].Location = new Point ( c*40, y*50-50 );
							Bitmap bm = new Bitmap("/home/user/Рабочий стол/пл/пл/bin/Debug/moneta.png");
							m[y-1, c].BackgroundImage = bm;
							m[y-1, c].BringToFront();
							m[y-1, c].Size = new Size (40, 40);
							A1[y-1, c]=1;
							break;
						}
				 	}
				}
			}
			if ( coin>=5 )
			{
				monster.Parent = panel2;
				monster.Location = new Point (520, 600);
				monster.Size = new Size (36, 50);
				Bitmap mstr = new Bitmap("/home/user/Рабочий стол/пл/пл/bin/Debug/monster.jpg");
				monster.BackgroundImage = mstr;
			}
			bool jump = ((int)D&4) > 0;
			bool right = ((int)D&1) > 0;
			bool left = ((int)D&2) > 0;
			if ( right==true )
			{//сравнение с массивом; если правая ячейка пуста && чтобы не шел по нижней половине платформы												
				if ( A1[(int)t/50, (int)(l+40)/40]<2 && A1[(int)(t+25)/50, (int)(l+40)/40]<2 )
				{
					panel1.Left += 10;
					FindCoin( (int)t/50, (int)(l+40)/40 );
					/*if ( A1[(int)t/50, (int)(l+40)/40]==1 )//если в ячейке есть монетка
					{
						/*coin++;
						label1.Text=coin.ToString();				//съедание монетки
						A1[(int)t/50, (int)(l+40)/40]=0;
						mon[(int)t/50, (int)(l+40)/40].BackgroundImage = null;
						mon[(int)t/50, (int)(l+40)/40].SendToBack();
					}*/
					if ( panel1.Left==monster.Left && panel1.Top==monster.Top && monster.BackgroundImage!=null )
					{
						panel2.Visible = false;
						panel3.Visible = true;
					}
				}
			}
			if ( left==true )
			{		//если левая ячейка пуста; 			&&		чтобы не шел по середине платформы
				if ( A1[(int)t/50, (int)(l-10)/40]<2 && A1[(int)(t+25)/50, (int)(l-10)/40]<2 )
				{
					panel1.Left += (-10);
					FindCoin( (int)t/50, (int)(l-10)/40 );
				}
				if ( A1[(int)panel1.Top/50+1, (int)(panel1.Left-30)/40]>1 )
					j=1;
				if ( panel1.Left-40 == monster.Left && panel1.Top == monster.Top && monster.BackgroundImage!=null )
				{
					panel2.Visible = false;
					panel3.Visible = true;

				}
			}
			if ( jump==true )
			{	//счетчик && проверка состояния выше стоящей ячейки && ещё одна проверка: чтобы не вылезал с левой стороны
				if ( k<5 && A1[(int)(t-25)/50, (int)l/40] == 0 && A1[(int)(t-25)/50, (int)(l+30)/40] == 0 )
				{
					panel1.Top += (-25);
					k++;
				}
				else
				{
					D-=Directions.jump;
					k=5;
				}
			}
			if ( ( jump==false && j!=1) || k==5 )									//без j - наскакивает на край
			{//чтобы не съезжал на платформы при падении(слева) && проверка на пустоту ячейки
				if ( A1[(int)t/50+1, (int)(l+30)/40]<2 && A1[(int)t/50+1, (int)l/40]<2 )
						panel1.Top += 25;							//собственно, падение
				FindCoin( (int)t/50+1, (int)l/40 );
			}
		}
		void MainFormKeyDown (object sender, KeyEventArgs e)
		{
			j=0;
			if (e.KeyCode == Keys.Right)
			{
				if ( A1[(int)panel1.Top/50+1, (int)panel1.Left/40+1]!=0 )//запрет на падение, если прыгает на край ячейки
					j=1;
				D = (Directions)((int)D|1);
			}
			if (e.KeyCode == Keys.Left)
			{
				D = (Directions)((int)D|2);
				//if ( A1[(int)panel1.Top/50+1, (int)(panel1.Left-30)/40]!=0 )//запрет на падение, если прыгает на край ячейки
				//	j=1;
			}
			if (e.KeyCode == Keys.Up && (A1[(int)panel1.Top/50+1, (int)(panel1.Left+30)/40]!=0 || A1[(int)panel1.Top/50+1, (int)panel1.Left/40]!=0))
			{
				D = (Directions)((int)D|4);
			}
			if (e.KeyCode == Keys.D1)
			{
				NewGame();
			}
			if (e.KeyCode == Keys.D2)
			{
				Close();
			}
		}
		void MainFormKeyUp (object sender, KeyEventArgs e)
		{
			//D=Directions.stop;		//при отпускании клавиши стоять на месте
			if (e.KeyCode == Keys.Left)
				D -= Directions.left;
			if (e.KeyCode == Keys.Right)
				D -= Directions.right;
			if (e.KeyCode == Keys.Up)
			{
				if ( D>=Directions.jump)
					D -= Directions.jump;
				k = 0;
			}
			j=0;
		}
	}
}
