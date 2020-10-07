//add reference  system.web  from asembly

public  class EmailHelper
    {

        /// <summary>
        /// 发送邮件smtp本机25端口（云服务器默认关闭） 可定制化设置邮件 服务器 账号密码 收件人 标题 内容 参数 ， 默认jdcmail@qq.com 发给自己
         /// </summary>
        /// <param name="subject">邮件主题</param>
        /// <param name="msg">邮件内容</param>
        public static void SendMailSmtp(string subject, string msg)
        {

            try
            {
                ////构造一个Email的Message对象
                // MailMessage message = new MailMessage();

                //确定smtp服务器地址。实例化一个Smtp客户端
                SmtpClient client = new SmtpClient();
                //   client.EnableSsl = true;
                client.Host = "smtp.qq.com"; //邮件服务器SMTP
                                             //client.Port = 994;                  //邮件服务器端口
                                             // client.Timeout = 1000;
                                             ////构造发件人地址对象
                                             //message.From = new MailAddress(senderEmail);

                ////构造收件人地址对象
                //message.To.Add(new MailAddress(recipientEmail));
                //client.EnableSsl = true;
                MailAddress toMail = new MailAddress("jdcmail@qq.com");//接收者邮箱

                MailAddress fromMail = new MailAddress("jdcmail@qq.com");//发送者邮箱          
                MailMessage message = new MailMessage(fromMail, toMail);

                //添加邮件主题和内容
                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = msg;
                message.BodyEncoding = Encoding.UTF8;

                //设置邮件的信息
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                //设置用户名和密码。
                client.UseDefaultCredentials = false;
                //用户登陆信息
                NetworkCredential myCredentials = new NetworkCredential("jdcmail@qq.com", "");
                client.Credentials = myCredentials;
                //发送邮件
                client.Send(message);
                Console.WriteLine("mail successed sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("fail sent mail"+ ex.Message);
            }
        }


        /// <summary>
        /// 发送邮件web的形式（云服务器默认关闭） 可定制化设置邮件 服务器 账号密码 收件人 标题 内容 参数 ， 默认jdcmail@qq.com 发给自己
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="msg">内容</param>
        [Obsolete]
        public static void SendMailWeb465(string subject, string msg)
        {
            try
            {
                System.Web.Mail.MailMessage mmsg = new System.Web.Mail.MailMessage();

                //验证  
                mmsg.Subject = subject;// "zhuti1";//邮件主题


                mmsg.Body = msg;// "wqerwerwerwer";//邮件正文
                mmsg.BodyEncoding = Encoding.UTF8;//正文编码

                // mmsg.Priority = MailPriority.High;//优先级

                mmsg.From = "jdcmail@qq.com";
                mmsg.To = "jdcmail@qq.com";

                mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //登陆名  
                mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "jdcmail@qq.com");
                //登陆密码  
                mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "");

                mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 465);//端口 
                mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");

                System.Web.Mail.SmtpMail.SmtpServer = "smtp.qq.com";    //企业账号用smtp.exmail.qq.com  
                System.Web.Mail.SmtpMail.Send(mmsg);
                Console.WriteLine("mail successed sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("fail sent mail" + ex.Message);
            }
         
        }
    }
