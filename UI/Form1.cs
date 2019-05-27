using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 绘制区域代码

        /// <summary>
        /// 绘制椭圆形边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StartURL_Click_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.UrlAddress.Text))
            {

                //判断是否请求成功 如果没有成功就再次请求
                bool State = true;
                while (State)
                {
                    //向一个网站发送请求
                    WebRequest request = WebRequest.Create(this.UrlAddress.Text.Trim());
                    request.Credentials = CredentialCache.DefaultCredentials;
                    //获取请求响应
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusDescription == "OK")
                    {
                        State = false;
                        //获取响应流
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        //当前网页下的所有的内容
                        string responseFromServer = reader.ReadToEnd();
                        //获取网站当前的视频目录
                        Match ma_name = Regex.Match(responseFromServer, @"<meta name=""keywords"".+content=""(.+)""/>");

                         //< meta name =\"keywords\" content=\"亚洲无码\" 


                        while (ma_name.Success)
                        {
                            string name = ma_name.Groups[1].Value.ToString().Split(',')[0];
                           // richTextBox1.Text = name;
                        }
                        //获取根目录
                       // richTextBox1.Text = responseFromServer;

                       
                        reader.Close();
                        dataStream.Close();
                        response.Close();

                    }

                }



            }
        }

        #endregion

        
    }
}
