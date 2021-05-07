        public static void SendMail(string subject, string msg)
        {
            try
            {
                var myCredentials = new NetworkCredential("jdcmail@qq.com", "邮箱smtp密码");

                var client = new SmtpClient
                {
                    EnableSsl = true,
                    Port = 587,//qq邮箱设置测试通过端口
                    Host = "smtp.qq.com",
                    Timeout = 2000,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                var toMail = new MailAddress("jdcmail@qq.com"); //接收
                var fromMail = new MailAddress("jdcmail@qq.com"); //发送    

                var message = new MailMessage(fromMail, toMail) { Subject = subject, Body = msg };
                client.Credentials = myCredentials;
                client.Send(message);
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
