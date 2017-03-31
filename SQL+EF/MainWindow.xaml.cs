using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SQL_EF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private testEntities test = new testEntities();
        Stopwatch sw = new Stopwatch();
        TimeSpan ts2;
        int selcetid = 0;

        
        public void showtable()
        {
            using (testEntities tt = new testEntities())
            {
                sw.Reset();
                sw.Start();
                try
                {

                    //test.projectprocess.Load();
                    //dataGrid.ItemsSource = test.projectprocess.Local.ToBindingList();
                    tt.userinfo.Load();
                    dataGrid.ItemsSource = tt.userinfo.Local.ToBindingList();
                    sw.Stop();
                    ts2 = sw.Elapsed;
                    time.Text = ts2.TotalMilliseconds.ToString() + "ms";
                }
                catch
                {
                    sw.Stop();
                    ts2 = sw.Elapsed;
                    time.Text = ts2.TotalMilliseconds.ToString() + "ms";
                    MessageBox.Show("连接失败！请检查数据库和连接信息！");
                }
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            sw.Reset();
            sw.Start();


            try
            {

                userinfo user = new userinfo();
                user.username = na.Text;
                user.password = pwd.Text;
                user.userlevel = Convert.ToInt32(power.Text);

                test.userinfo.Add(user);
                test.SaveChanges();


                //使用Lambda表达式查询数据
                var a = test.userinfo.Where(o => o.userlevel == 1).ToList();

                //Linq语句查询
                var b = from o in test.userinfo
                        where o.userlevel == 0
                        select o;

                //打印查询结果  
                if (a.Any())
                {
                    Console.WriteLine("Lambda方式：" + a.FirstOrDefault().username + "----" + a.FirstOrDefault().password);
                    Console.WriteLine("Linq方式：" + b.FirstOrDefault().username + "----" + b.FirstOrDefault().password);
                }
                sw.Stop();
                ts2 = sw.Elapsed;
                time.Text = ts2.TotalMilliseconds.ToString() + "ms";
            }
            catch
            {
                sw.Stop();
                ts2 = sw.Elapsed;
                time.Text = ts2.TotalMilliseconds.ToString() + "ms";
                MessageBox.Show("连接失败！请检查数据库和连接信息！");
            }
            showtable();
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {

            showtable();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            using (testEntities te = new testEntities())
            {
                userinfo use = new userinfo
                {
                    userid = selcetid
                };
                var a = te.userinfo.Attach(use);
                a.username = na.Text;
                a.password = pwd.Text;
                a.userlevel = Convert.ToInt32(power.Text);
                te.SaveChanges();
                showtable();
            }

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {


            var selectedElement = (userinfo)dataGrid.SelectedItem;
            if (selectedElement != null)
            {
                var va = test.userinfo.FirstOrDefault(m => m.userid == selectedElement.userid);
                if (va != null)
                {

                    test.userinfo.Remove(va);
                    test.SaveChanges();
                    MessageBox.Show("成功删除!");
                    showtable();
                }
                else
                {
                    MessageBox.Show("删除失败!");
                }
            }
            else
            {
                MessageBox.Show("请选中想要删除的数据!");
            }

        }

        private void upd_Click(object sender, RoutedEventArgs e)
        {
            var selectedElement = (userinfo)dataGrid.SelectedItem;
            if (selectedElement != null)
            {
                na.Text = selectedElement.username;
                pwd.Text = selectedElement.password;
                power.Text = selectedElement.userlevel.ToString();
                selcetid = selectedElement.userid;
                int m = selcetid;
            }
            else
            {
                MessageBox.Show("请选中想要修改的数据!");
            }
        }

        private void ist_Click(object sender, RoutedEventArgs e)
        {
            object i = sender;
            RoutedEventArgs m = e;


            var selectedElement = (userinfo)dataGrid.SelectedItem;
            if (selectedElement != null)
            {
                na.Text = selectedElement.username;
                pwd.Text = selectedElement.password;
                power.Text = selectedElement.userlevel.ToString();

            }
            else
            {
                MessageBox.Show("请选中想要添加的数据模型!");
            }
        }


    }
}
