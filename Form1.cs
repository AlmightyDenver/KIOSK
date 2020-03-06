using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class Form1 : Form
    {

        int max_x = 0;
        int max_y = 0;

        int pn1_x = 1000;
        int pn1_x_init = 1000;
        bool pn1_move = false;

        int pn2_x = 1000;
        int pn2_x_init = 1000;
        bool pn2_move = false;
        //int pn_x = 1000;

        public Form1()
        {
            InitializeComponent();

            //============ 전체 화면 =============================
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            pn1_x = panel1.Left;
            pn1_x_init = panel1.Left;


            pn2_x = panel2.Left;
            pn2_x_init = panel2.Left;
        }



        //와퍼&버거, 사이드, 음료&디저트, 
        string[,] my_memu_list = new string[3, 5] { { "와퍼", "더콰트로치즈와퍼", "몬스터X", "통모짜와퍼", "트리플머쉬룸와퍼" }, { "21치즈스틱", "크리미모짜볼", "프렌치프라이", "너겟킹8조각", "어니언링" }, { "아메리카노", "핫초코", "선데", "스프라이트", "물" } };
        int[,] my_cost_list = new int[3, 5] { { 5900, 6800, 8900, 8200, 8900 }, { 1500, 2200, 1600, 2000, 2000 }, { 1500, 2000, 1800, 1700, 1200 } };



        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            timer1.Start();
        }



        //==================== Q 누르면 닫기 ===================
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                this.Close();
            }
        }



        //========================= 자동 움직임 ===============================
        private void timer1_Tick(object sender, EventArgs e)
        {
            pn1_move = true;
            pn1_x = 1000;
            my_auto_move_pn(panel1,  pn1_move, pn1_x_init);
            //my_move_panel(panel1, pn1_x, pn1_move, pn1_x_init, false);

        }


        private void my_auto_move_pn(Panel mypanel, bool mypn_move, int mypn_x_init)
        {
            if (mypn_move)
            {
                pn1_x -= 20;
                mypanel.Left = pn1_x;
                if (mypanel.Left <= mypn_x_init - mypanel.Width * 2)
                {
                    mypn_x_init = mypanel.Left;
                }
                else if (pn1_x <= 0)
                {
                    pn1_x = 1000;
                }
            }
        }




        //======================== 좌우 움직임 ===============================


        private void button1_Click(object sender, EventArgs e)
        {

            pn2_move = true;
            my_RL_panel_move(panel2, pn2_x, pn2_move, pn2_x_init, true);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            pn2_move = true;
            my_RL_panel_move(panel2, pn2_x, pn2_move, pn2_x_init, false);
        }





        private void my_RL_panel_move(Panel mypanel, int mypn_x, bool mypn_move, int mypn_x_init, bool dir)
        {
            //움직임 방향. 
            int move_size ;
            if (dir) move_size = -30;
            else move_size = 30;


            mypn_x += move_size;
            mypanel.Left = mypn_x;

            // 움직일곳 없음.  화면 끝
            if (mypanel.Left <= mypn_x_init - mypanel.Width * 2 ) 
            {
                mypn_move = false;
            }


        }


  
        //private void my_move_panel(Panel mypanel, int mypn_x, bool mypn_move, int mypn_x_init, bool turn_off)
        //{
        //    if (mypn_move)
        //    {
        //        pn_x -= 20;
        //        mypanel.Left = pn_x;
        //        if (mypanel.Left <= mypn_x_init - mypanel.Width*2)
        //        {
        //            if (!turn_off)
        //            {
        //                mypn_move = false;
        //                button1.Text = "Left";
        //            }
        //            mypn_x_init = mypanel.Left;
        //        }
        //        else if (pn_x <= 0)
        //        {
        //            pn_x = 1600;
        //        }
        //    }



    }
}