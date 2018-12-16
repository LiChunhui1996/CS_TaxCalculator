//开发主题：实现一实际的符合客户需求的 “个人存款计算器”。
//开发人员：李纯辉  2016118162  软件工程(1)班
//这要功能程序主要实现一个存款计算器，主要内容昂参见建行的理财计算器网页：http://www.ccb.com/cn/personal/interest/calculator.html
//实现情况：完成了主要的功能要求，程序对用户的输入有一定的判断能力并且有很好的提示功能。


using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //全局变量  利息
        public double interest;

        //通过第一个复选框来实现对客户需求的判断。
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = comboBox1.Text;
            switch (select)
            {
                case "活期":        label2.Text = "您选择了活期存款！"; ShowMenu(sender, e, 1);  break;
                case "定活两便": label2.Text = "您选择了定活两便！"; ShowMenu(sender, e, 2); break;
                case "存本取息": label2.Text = "您选择了存本取息！"; ShowMenu(sender, e, 3); break;
                case "整存整取": label2.Text = "您选择了整存整取！"; ShowMenu(sender, e, 4); break;
                case "零存整取": label2.Text = "您选择了零存整取！"; ShowMenu(sender, e, 5); break;
                case "通知存款": label2.Text = "您选择了通知存款！"; ShowMenu(sender, e, 6); break;
            }
        }

        //这里主要将会要显示的输入框调制成可见，并且这里直接设置利息
        private void ShowMenu(object sender, EventArgs e,int v)
        {
            switch (v)
            {
                case 1://选择了活期
                    interest = 0.003; textBox5.Text = ((interest*100).ToString()+"%");
                    panel_活期.Visible = true; panel_定活两便.Visible = false;
                    panel_存本取息.Visible = false; panel_整存整取.Visible = false;
                    panel_零存整取.Visible = false; panel_通知存款.Visible = false; break;
                case 2://选择了定活两便
                    interest = 0.0115;textBox5.Text = ((interest * 100).ToString() + "%"); 
                    panel_活期.Visible = false; panel_定活两便.Visible = true;
                    panel_存本取息.Visible = false; panel_整存整取.Visible = false;
                    panel_零存整取.Visible = false; panel_通知存款.Visible = false; break;
                case 3: //选择了存本取息
                    panel_活期.Visible = false; panel_定活两便.Visible = false;
                    panel_存本取息.Visible = true; panel_整存整取.Visible = false;
                    panel_零存整取.Visible = false; panel_通知存款.Visible = false; break;
                case 4://选择了整存整取
                    radioButton3.Enabled = true; radioButton4.Checked = false;
                    radioButton4.Enabled = false;radioButton4.Enabled = false;
                    panel_活期.Visible = false; panel_定活两便.Visible = false;
                    panel_存本取息.Visible = false; panel_整存整取.Visible = true;
                    panel_零存整取.Visible = false; panel_通知存款.Visible = false; break;
                case 5://选择了零存整取
                    panel_活期.Visible = false; panel_定活两便.Visible = false;
                    panel_存本取息.Visible = false; panel_整存整取.Visible = false;
                    panel_零存整取.Visible = true; panel_通知存款.Visible = false; break;
                case 6://选择了通知存款
                    panel_活期.Visible = false; panel_定活两便.Visible = false;
                    panel_存本取息.Visible = false; panel_整存整取.Visible = false;
                    panel_零存整取.Visible = false; panel_通知存款.Visible = true; break;
            }
        }

        //当按下计算后的实现逻辑
        private void button1_Click(object sender, EventArgs e)
        {
            string select = comboBox1.Text;
            if (textBox4.Text.ToString() == "")
            {
                textBox4.BackColor = Color.Red;
                textBox4.Focus();
                select = "NULL";
            }

            switch (select)
            {
                case "活期":         Caculater_活期(sender, e); break;//活期的计算方法
                case "定活两便":  Caculater_定活两便(sender, e); break;//定活两便的计算方法
                case "存本取息":  SetInterest_存本取息(sender, e);  Caculater_存本取息(sender,e); break;//存本取息的计算方法
                case "整存整取":  SetInterest_整存整取(sender, e);  Caculter_整存整取(sender, e); break;//整存整取的计算方法
                case "零存整取":  SetInterest_零存整取(sender, e);  Caculater_零存整取(sender, e); break;//零存整取的计算方法
                case "通知存款":  SetInterest_通知存款(sender, e);  Caculater_通知存款(sender, e); break;//通知存款的计算方法
                case "NULL":        break;
            }
        }
        //将利息显示出来的方法
        private double GetInterest(object sender, EventArgs e)
        {
            double interest;
            if (radioButton6.Checked)
            {
                interest = this.interest;
            }
            else
            {
                string note = textBox5.Text.Replace("%", "");
                interest = Convert.ToDouble(note);
                interest = interest / 100;
            }
            return interest;
        }

        //下面是程序的利息设置部分
        private void SetInterest_存本取息(object sender, EventArgs e)
        {
            string info = comboBox2.Text;
            switch (info)
            {
                case "一年": interest = 0.0135; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "三年": interest = 0.0155; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "五年": interest = 0.0155; textBox5.Text = ((interest * 100).ToString() + "%"); break;
            }
        }

        private void SetInterest_零存整取(object sender, EventArgs e)
        {
            string info = comboBox4.Text;
            switch (info)
            {
                case "一年": interest = 0.0135; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "三年": interest = 0.0155; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "五年": interest = 0.0155; textBox5.Text = ((interest * 100).ToString() + "%"); break;
            }
        }

        private void SetInterest_整存整取(object sender, EventArgs e)
        {
            string info = comboBox3.Text;
            switch (info)
            {
                case "三个月": interest = 0.0135; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "六个月": interest = 0.0155; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "一年":     interest = 0.0175; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "两年":     interest = 0.0215; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "三年":     interest = 0.0275; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "五年":     interest = 0.0275; textBox5.Text = ((interest * 100).ToString() + "%"); break;
            }
        }

        private void SetInterest_通知存款(object sender, EventArgs e)
        {
            string info = comboBox5.Text;
            switch (info)
            {
                case "一天": interest = 0.0055; textBox5.Text = ((interest * 100).ToString() + "%"); break;
                case "七天": interest = 0.0110; textBox5.Text = ((interest * 100).ToString() + "%"); break;
            }
        }

        //下面是程序的计算部分
        private void Caculater_活期(object sender, EventArgs e)
        {
            //1、接受数据（判断数据完整性、收集数据）。
            //2、计算出结果，并显示出来。
            string date_1 = dateTimePicker1.Value.ToString();
            string date_2 = dateTimePicker2.Value.ToString();

            int date1year = Convert.ToInt16(dateTimePicker1.Value.Year);
            int date1moon = Convert.ToInt16(dateTimePicker1.Value.Month);
            int date1day = Convert.ToInt16(dateTimePicker1.Value.Day);
            int date2year = Convert.ToInt16(dateTimePicker2.Value.Year);
            int date2moon = Convert.ToInt16(dateTimePicker2.Value.Month);
            int date2day = Convert.ToInt16(dateTimePicker2.Value.Day);

            int yearDelta = date2year - date1year;
            int moonDelta = date2moon - date1moon;
            int dayDelta = date2day - date1day;

            int allDay = 0;

            if (yearDelta < 0)
            {
               label2.Text = "请检查输入的日期";
            }
            else if (yearDelta == 0)
            {
                allDay = moonDelta * 30 + dayDelta;
            }
            else if (yearDelta > 0)
            {
                allDay = yearDelta * 365 + moonDelta * 30 + dayDelta;
            }
            double allDayDividYear = allDay / 365.0;
            Console.WriteLine(allDay + " " + allDayDividYear);
            double money = 0;
            try
            {
                money = Convert.ToDouble(textBox4.Text.ToString());
            }
            catch
            {
                //textBox4.Text = "";
                textBox4.BackColor = Color.Red;
            }

            double interest = GetInterest(sender, e);

            double fee = money * allDayDividYear * interest;
            double feeAll = fee + money;

            textBox2.Text = fee.ToString();
            textBox3.Text = feeAll.ToString();
        }


        private void Caculater_定活两便(object sender, EventArgs e)
        {
            //解析时间
            int year =Convert.ToInt16( numericUpDown1.Value);
            int moon= Convert.ToInt16(numericUpDown2.Value);
            int day= Convert.ToInt16(numericUpDown3.Value);

            int allDay = year * 365 + moon * 30 + day;
            double allDayDividYear = allDay / 365;
            double money = 0;
            try
            {
                money = Convert.ToDouble(textBox4.Text.ToString());
            }
            catch
            {
                //textBox4.Text = "";
                textBox4.BackColor = Color.Red;
            }
            double interest = GetInterest(sender,e);

            double fee = money * allDayDividYear * interest;
            double feeAll = fee + money;

            textBox2.Text = fee.ToString();
            textBox3.Text = feeAll.ToString();
        }

        private void Caculater_存本取息(object sender, EventArgs e)
        {
            int year = 0;
            string info=comboBox2.Text;
            switch (info)
            {
                case "一年": year = 1; break;
                case "三年": year = 3; break;
                case "四年": year = 5; break;
            }

            double money = 0;
            try
            {
                money = Convert.ToDouble(textBox4.Text.ToString());
            }
            catch
            {
                //textBox4.Text = "";
                textBox4.BackColor = Color.Red;
            }
            double fee = money * year * interest;
            double feeAll = fee + money;

            textBox2.Text = fee.ToString();
            textBox3.Text = feeAll.ToString();
        }

        private void Caculter_整存整取(object sender, EventArgs e)
        {
            double year=0;
            string info = comboBox3.Text;
            switch (info)
            {
                case "三个月": year = 0.25; break;
                case "六个月": year = 0.5; break;
                case "一年": year = 1; break;
                case "两年": year = 2; break;
                case "三年": year = 3; break;
                case "五年": year = 5; break;
            }
            double money = 0;
            try
            {
                money = Convert.ToDouble(textBox4.Text.ToString());
            }
            catch
            {
                //textBox4.Text = "";
                textBox4.BackColor = Color.Red;
            }
            double fee = money * year * interest;
            double feeAll = fee + money;

            textBox2.Text = fee.ToString();
            textBox3.Text = feeAll.ToString();
        }

        private void Caculater_零存整取(object sender, EventArgs e)
        {
            int year = 0;
            string info = comboBox4.Text;
            switch (info)
            {
                case "一年": year = 1; break;
                case "三年": year = 3; break;
                case "四年": year = 5; break;
            }

            double money = 0;
            try
            {
                money = Convert.ToDouble(textBox4.Text.ToString());
            }
            catch
            {
                //textBox4.Text = "";
                textBox4.BackColor = Color.Red;
            }
            double fee = money * year * interest;
            double feeAll = fee + money;

            textBox2.Text = fee.ToString();
            textBox3.Text = feeAll.ToString();
        }

        private void Caculater_通知存款(object sender, EventArgs e)
        {
            double year = 0;
            int day = 0;
            string info = comboBox5.Text;
            switch (info)
            {
                case "一天": day = 1; break;
                case "七天": day = 7; break;
            }
            year = (day / 365.0);
            Console.WriteLine(year);
            double money = 0;
            try
            {
                money = Convert.ToDouble(textBox4.Text.ToString());
            }
            catch
            {
                //textBox4.Text = "";
                textBox4.BackColor = Color.Red;
            }
            double fee = money * year * interest;
            double feeAll = fee + money;
            textBox2.Text = fee.ToString();
            textBox3.Text = feeAll.ToString();
        }

        //附属方法部分
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.BackColor = Color.Red;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            textBox5.Text = ((interest * 100).ToString() + "%");
            textBox5.Enabled = false;
        }
    }
}
