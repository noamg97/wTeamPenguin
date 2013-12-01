using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Text;
using System.IO;
using System.Net;

namespace wTeamPenguin
{
    public partial class _default : System.Web.UI.Page
    {
        public static OleDBManager db = new OleDBManager("Table1.accdb", "App_Data", 2007);
        public static SimpleAES enc = new SimpleAES();
        static string domain;
        static string usernameVar = "";
        static string passVar = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            domain = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;

            string sessionST = (string)Session["session1"];
            string cookiesST = "";

            if (Request.Cookies["cookie1"] != null)
                cookiesST = Server.HtmlEncode(Request.Cookies["cookie1"].Value);

            if (sessionST != null && sessionST != "" && doesExists(sessionST) == "True" && isPassword(sessionST, (string)Session["session2"]) == "true")
                changeLoginDiv(sessionST);

            if (Request.Cookies["cookie2"] != null)
                if (cookiesST != null && cookiesST != "" && doesExists(cookiesST) == "True" && isPassword(cookiesST, Server.HtmlEncode(Request.Cookies["cookie2"].Value)) == "true")
                    changeLoginDiv(cookiesST);

            #region MyRegion
            if (sessionST != null && sessionST != "" && (string)Session["session1"] == "AdminEntered" && (string)Session["session2"] == "#NREW23rhtfdsffd#F$6gfd")
                changeLoginDivA(sessionST);

            if (Request.Cookies["cookie2"] != null)
                if (cookiesST == "AdminEntered" && Server.HtmlEncode(Request.Cookies["cookie2"].Value) == "#NREW23rhtfdsffd#F$6gfd")
                    changeLoginDivA(cookiesST);
            #endregion


            uploadImage();
        }

        protected void loginFunc(object sender, EventArgs e)
        {
            string userS = Request.Form["user"];
            string passS = Request.Form["pass"];
            #region MyRegion
            if (userS != "admin")
            #endregion
            {
                if (rememberME.Checked)
                {
                    Response.Cookies["cookie1"].Value = userS; // username
                    Response.Cookies["cookie2"].Value = passS; // password
                    Response.Cookies["cookie1"].Expires = DateTime.Now.AddDays(365);
                    Response.Cookies["cookie2"].Expires = DateTime.Now.AddDays(365);
                }
                else
                {
                    Session["session1"] = userS;
                    Session["session2"] = passS;
                }


                string logins = db.ExecuteStringRead("SELECT logins FROM users WHERE username=@usr", new string[] { "usr" }, new string[] { userS });
                int loginsInt = Int32.Parse(logins) + 1;
                int a = db.ExecuteQuery("UPDATE users SET logins=@log WHERE username=@usr", new string[] { "log", "usr" }, new string[] { loginsInt.ToString(), userS });

                changeLoginDiv(userS);
            }
            #region MyRegion
            else if (passS == "#nwv6uc0t#")
            {
                if (!rememberME.Checked)
                {
                    Session["session1"] = "AdminEntered";
                    Session["session2"] = "#NREW23rhtfdsffd#F$6gfd";
                }
                else
                {
                    Response.Cookies["cookie1"].Value = "AdminEntered";
                    Response.Cookies["cookie2"].Value = "#NREW23rhtfdsffd#F$6gfd";
                    Response.Cookies["cookie1"].Expires = DateTime.Now.AddDays(3);
                    Response.Cookies["cookie2"].Expires = DateTime.Now.AddDays(3);
                }
                Response.Redirect("Admin.aspx?orderBy=id");
            }
            #endregion
        }
        protected void loginAfterReg(object sender, EventArgs e)
        {
            string userS = Request.Form["ruser"];
            string passS = Request.Form["rpass"];
            if (doesExists(userS).ToLower() == "true")
            {
                Session["session1"] = userS;
                Session["session2"] = passS;


                string logins = db.ExecuteStringRead("SELECT logins FROM users WHERE username=@usr", new string[] { "usr" }, new string[] { userS });
                if (logins != "")
                {
                    int loginsInt = Int32.Parse(logins) + 1;
                    int a = db.ExecuteQuery("UPDATE users SET logins=@log WHERE username=@usr", new string[] { "log", "usr" }, new string[] { loginsInt.ToString(), userS });
                }

                changeLoginDiv(userS);
            }
        }

        protected void logoutFunc(object sender, EventArgs e)
        {
            Session["session1"] = "";
            Session["session2"] = "";
            Response.Cookies["cookie1"].Expires = DateTime.Now.AddMinutes(-10);
            Response.Cookies["cookie2"].Expires = DateTime.Now.AddMinutes(-10);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void uploadImage()
        {
            if (Request.Form["upImageU"] != null)
            {
                #region MyRegion
                if (String.IsNullOrEmpty(Request.Form["UrlImage"]) && UrlExists(Request.Form["UrlImage"]))
                {
                    string remoteImgPath = Request.Form["UrlImage"];
                    Uri remoteImgPathUri = new Uri(remoteImgPath);
                    string remoteImgPathWithoutQuery = remoteImgPathUri.GetLeftPart(UriPartial.Path);
                    string localPath = Request.PhysicalApplicationPath + @"\Uploads\" + usernameVar + Path.GetExtension(remoteImgPathWithoutQuery);
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(remoteImgPath, localPath);

                    db.ExecuteQuery("UPDATE users SET [image]=@img WHERE username=@username",
                        new string[] { "img", "username" },
                        new string[] { Path.GetExtension(remoteImgPathWithoutQuery), usernameVar });

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else scripty.InnerHtml = "<script>alert('The URL did not contain a valid image file');</script>";

                #endregion
            }

            if (Request.Form["upImage"] != null)
            {
                #region MyRegion
                if (FileUpload1.HasFile)
                {
                    string saveDir = @"\Uploads\";
                    string appPath = Request.PhysicalApplicationPath;

                    string savePath = appPath + saveDir + usernameVar;
                    string FileName = FileUpload1.FileName;
                    string extension = System.IO.Path.GetExtension(Server.HtmlEncode(FileName));
                    savePath += extension;
                    extension = extension.ToLower();

                    if (extension == ".jpeg" || extension == ".gif" || extension == ".png" || extension == ".bmp" || extension == ".jpg")
                    {
                        try
                        {
                            FileUpload1.SaveAs(savePath);

                            db.ExecuteQuery("UPDATE users SET [image]=@img WHERE username=@username", new string[] { "img", "username" }, new string[] { extension, usernameVar });
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);
                        }
                        catch (Exception e)
                        {
                            scripty.InnerHtml = "<script>alert('The file could not be uploaded');</script>";
                        }
                    }
                    else scripty.InnerHtml = "<script>alert('The uploaded file is not a supported image file');</script>";
                }

                #endregion
            }
        }
        public static bool UrlExists(string url)
        {
            HttpWebResponse response = null;
            try
            {
                new System.Net.WebClient().DownloadData(url);
                try
                {
                    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                    response = (HttpWebResponse)wr.GetResponse();
                }
                catch (WebException webEx)
                {
                    response = (HttpWebResponse)webEx.Response;
                }
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }
            if (response != null)
                if (response.ContentType.Contains("image"))
                    return true;

            return false;
        }

        protected void deleteImageClick(object sender, EventArgs e)
        {
            if (doesExists(usernameVar).ToLower() == "true" && isPassword(usernameVar, passVar) == "true")
            {
                string path = Request.PhysicalApplicationPath + @"\Uploads\" + usernameVar + _default.db.ExecuteStringRead("SELECT [image] FROM users WHERE username=@user", new string[] { "user" }, new string[] { usernameVar });
                if (File.Exists(path)) File.Delete(path);

                db.ExecuteQuery("UPDATE users SET [image]='' WHERE username=@user AND [password]=@pass;", new string[] { "user", "pass" }, new string[] { usernameVar, passVar });
            }

        }


        [WebMethod]
        public static string doesExists(string st)
        {
            if (db.ExecuteStringRead("SELECT activated FROM users WHERE username=@username", new string[] { "username" }, new string[] { st }) == "f")
                return "nonactive";

            return db.IsExist("SELECT * FROM users WHERE username=@username", new string[] { "username" }, new string[] { st }).ToString();
        }

        [WebMethod]
        public static string doesMailExists(string st)
        {
            return db.IsExist("SELECT * FROM users WHERE email=@email", new string[] { "email" }, new string[] { st }).ToString();
        }

        [WebMethod]
        public static string doesMailExists_ForUpdate(string st)
        {
            return db.IsExist("SELECT * FROM users WHERE email=@email AND username<>@user", new string[] { "email", "user" }, new string[] { st, usernameVar }).ToString();
        }

        [WebMethod]
        public static string doesMailExists_ForUpdate(string st, string mail)
        {
            return db.IsExist("SELECT * FROM users WHERE email=@email AND username<>@user", new string[] { "email", "user" }, new string[] { mail, st }).ToString();
        }

        [WebMethod]
        public static string isPassword(string username, string password)
        {

            if (db.ExecuteStringRead("SELECT [password] FROM users WHERE username=@usr", new string[] { "usr" }, new string[] { username }) == password)
                return "true";

            return "false";
        }

        [WebMethod]
        public static string isAdmin(string user, string pass)
        {
            return (user == "admin" && pass == "#nwv6uc0t#").ToString().ToLower();
        }

        [WebMethod]
        public static string registerUser(string user, string pass, string mail, string fname, string lname, string bday, string bmonth, string byear, string country, string city)
        {
            if (user == "admin") return "error";


            try
            {
                db.ExecuteQuery(
                "INSERT INTO users(username, [password], email, [activated], fname, lname, bday, bmonth, byear, country, city) " +
                          "VALUES (@username, @password, @email, 'f', @fname, @lname, @bday, @bmonth, @byear, @country, @city);"
                , new string[] { "@username", "@password", "@email", "@fname", "@lname", "@bday", "@bmonth", "@byear", "@country", "@city" }
                , new string[] { user, pass, mail, fname, lname, bday, bmonth, byear, country, city });
            }
            catch (Exception exx)
            {
                return "error";
            }
            return "done";
        }

        [WebMethod]
        public static string sendEmail(string userTo, string pass, string mail)
        {
            string user = enc.EncryptToString(userTo);
            try
            {
                MailMessage myEmail = new MailMessage()
                {
                    Subject = "Team Penguin Account Confirmation‏",
                    Body = "Hi  " + userTo + " !" + Environment.NewLine + Environment.NewLine + "You are just one step away from creating your Team Penguin account! " + Environment.NewLine + "Please follow this link to confirm that this is your e-mail address:" + Environment.NewLine + Environment.NewLine + domain + "ActivateUser.aspx?n14325=" + user,
                    IsBodyHtml = false,
                    From = new MailAddress("noReply@TeamPenguin.com", "Team Penguin account configiration"),
                };
                myEmail.To.Add(new MailAddress(mail));

                SmtpClient server = new SmtpClient();
                server.Send(myEmail);
            }
            catch (Exception ex)
            {
                #region trying again
                try
                {
                    MailMessage myEmail = new MailMessage()
                    {
                        Subject = "Team Penguin Account Confirmation‏",
                        Body = "Hi  " + user + " !" + Environment.NewLine + "You are just one step away from creating your Team Penguin account! Please follow this link to confirm that this is your e-mail address:" + Environment.NewLine + Environment.NewLine + domain + "/ActiveUser.aspx?ab1zfs=" + user,
                        IsBodyHtml = true,
                        From = new MailAddress("noReply@TeamPenguin.com", "Team Penguin account configiration"),
                    };
                    myEmail.To.Add(new MailAddress(mail));

                    SmtpClient server = new SmtpClient();
                    server.Port = 25;
                    server.Send(myEmail);
                }
                catch (Exception e)
                {
                    return "error";
                }
                #endregion
            }
            return "sent";
        }

        [WebMethod]
        public static string[] FillProfile()
        {

            string bd = db.ExecuteStringRead("SELECT bday FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar }) + "." +
                db.ExecuteStringRead("SELECT bmonth FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar }) + "." +
                db.ExecuteStringRead("SELECT byear FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar });
            if (bd == "0.0.0") bd = "";


            string mage = db.ExecuteStringRead("SELECT image FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar });
            if (mage == ".jpeg" || mage == ".gif" || mage == ".png" || mage == ".bmp" || mage == ".jpg") mage = "<img style='width:100%;height:100%;' src='Uploads/" + usernameVar + mage + "' />";


            return new string[] { 
                usernameVar, 
                db.ExecuteStringRead("SELECT email FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar }), 
                db.ExecuteStringRead("SELECT fname FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar }), 
                db.ExecuteStringRead("SELECT lname FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar }), 
                db.ExecuteStringRead("SELECT country FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar }), 
                db.ExecuteStringRead("SELECT city FROM users WHERE username=@uname", new string[] { "uname" }, new string[] { usernameVar }), 
                bd,
                mage
            };
        }

        [WebMethod]
        public static void UpdateUser(string mail, string fname, string lname, string bday, string bmonth, string byear, string country, string city)
        {
            db.ExecuteQuery("UPDATE users SET email=@mail, fname=@fna, lname=@lna, bday=@bda, bmonth=@bmo, byear=@bye, country=@coun, city=@cty WHERE username=@user AND [password]=@pass;",
                new string[] { "mail", "fna", "lna", "bda", "bmo", "bye", "coun", "cty", "user", "pass" },
                new string[] { mail, fname, lname, bday, bmonth, byear, country, city, usernameVar, passVar });
        }

        [WebMethod]
        public static string ChangePassword(string old, string newp)
        {
            if (isPassword(usernameVar, old) == "false") return "old";

            db.ExecuteQuery("UPDATE users SET [password]=@pass WHERE username=@user", new string[] { "pass", "user" }, new string[] { newp, usernameVar });

            passVar = newp;

            return "ok";
        }


        [WebMethod]
        public static string reSendEmail(string userTo, string pass, string nmail)
        {
            string user = enc.EncryptToString(userTo);

            string mail;
            if (string.IsNullOrEmpty(nmail)) mail = db.ExecuteStringRead("SELECT email FROM users WHERE username=@userTo", new string[] { "userTo" }, new string[] { userTo });
            else
            {
                mail = nmail;
                db.ExecuteQuery("UPDATE users SET email=@mail WHERE username=@user", new string[] { "mail", "user" }, new string[] { nmail, userTo });
            }

            try
            {
                MailMessage myEmail = new MailMessage()
                {
                    Subject = "Team Penguin Account Confirmation‏",
                    Body = "Hi  " + userTo + " !" + Environment.NewLine + Environment.NewLine + "You are just one step away from creating your Team Penguin account! " + Environment.NewLine + "Please follow this link to confirm that this is your e-mail address:" + Environment.NewLine + Environment.NewLine + domain + "ActivateUser.aspx?n14325=" + user,
                    IsBodyHtml = false,
                    From = new MailAddress("noReply@TeamPenguin.com", "Team Penguin account configiration"),
                };
                myEmail.To.Add(new MailAddress(mail));

                SmtpClient server = new SmtpClient();
                server.Send(myEmail);
            }
            catch (Exception ex)
            {
                #region trying again
                try
                {
                    MailMessage myEmail = new MailMessage()
                    {
                        Subject = "Team Penguin Account Confirmation‏",
                        Body = "Hi  " + user + " !" + Environment.NewLine + "You are just one step away from creating your Team Penguin account! Please follow this link to confirm that this is your e-mail address:" + Environment.NewLine + Environment.NewLine + domain + "/ActiveUser.aspx?ab1zfs=" + user,
                        IsBodyHtml = true,
                        From = new MailAddress("noReply@TeamPenguin.com", "Team Penguin account configiration"),
                    };
                    myEmail.To.Add(new MailAddress(mail));

                    SmtpClient server = new SmtpClient();
                    server.Port = 25;
                    server.Send(myEmail);
                }
                catch (Exception e)
                {
                    return "error";
                }
                #endregion
            }
            return "sent";
        }

        [WebMethod]
        public static string ForgottenEmail(string mailTo)
        {

            string passStr = db.ExecuteStringRead("SELECT [password] FROM users WHERE email=@mail", new string[] { "mail" }, new string[] { mailTo });

            try
            {
                MailMessage myEmail = new MailMessage()
                {
                    Subject = "Team Penguin Password Recovery‏",
                    Body = "Your password is:" + Environment.NewLine + passStr + Environment.NewLine + Environment.NewLine + "You can now log back in at " + domain + "/default.aspx",
                    IsBodyHtml = false,
                    From = new MailAddress("noReply@TeamPenguin.com", "Team Penguin Password Recovery"),
                };
                myEmail.To.Add(new MailAddress(mailTo));

                SmtpClient server = new SmtpClient();
                server.Send(myEmail);
            }
            catch (Exception ex)
            {
                #region trying again
                try
                {
                    MailMessage myEmail = new MailMessage()
                    {
                        Subject = "Team Penguin Password Recovery‏",
                        Body = "Your password is:" + Environment.NewLine + passStr + Environment.NewLine + Environment.NewLine + "You can now log back in at " + domain + "/default.aspx",
                        IsBodyHtml = false,
                        From = new MailAddress("noReply@TeamPenguin.com", "Team Penguin Password Recovery"),
                    };
                    myEmail.To.Add(new MailAddress(mailTo));

                    SmtpClient server = new SmtpClient();
                    server.Send(myEmail);
                }
                catch (Exception e)
                {
                    return "error";
                }
                #endregion
            }
            return "sent";
        }
        [WebMethod]
        public static string doesExistsFromMail(string st)
        {
            return db.IsExist("SELECT * FROM users WHERE email=@username", new string[] { "username" }, new string[] { st }).ToString();
        }

        [WebMethod]
        public static string ForgottenEmail2(string userTo)
        {

            string passStr = db.ExecuteStringRead("SELECT [password] FROM users WHERE username=@usr", new string[] { "usr" }, new string[] { userTo });
            string mailStr = db.ExecuteStringRead("SELECT email FROM users WHERE username=@usr", new string[] { "usr" }, new string[] { userTo });

            try
            {
                MailMessage myEmail = new MailMessage()
                {
                    Subject = "Team Penguin Password Recovery‏",
                    Body = "Your password is:" + Environment.NewLine + passStr + Environment.NewLine + Environment.NewLine + "You can now log back in at " + domain + "/default.aspx",
                    IsBodyHtml = false,
                    From = new MailAddress("noReply@TeamPenguin.com", "Team Penguin Password Recovery"),
                };
                myEmail.To.Add(new MailAddress(mailStr));

                SmtpClient server = new SmtpClient();
                server.Send(myEmail);
            }
            catch (Exception ex)
            {
                #region trying again
                try
                {
                    MailMessage myEmail = new MailMessage()
                    {
                        Subject = "Team Penguin Password Recovery‏",
                        Body = "Your password is:" + Environment.NewLine + passStr + Environment.NewLine + Environment.NewLine + "You can now log back in at " + domain + "/default.aspx",
                        IsBodyHtml = false,
                        From = new MailAddress("noReply@TeamPenguin.com", "Team Penguin Password Recovery"),
                    };
                    myEmail.To.Add(new MailAddress(mailStr));

                    SmtpClient server = new SmtpClient();
                    server.Send(myEmail);
                }
                catch (Exception e)
                {
                    return "error";
                }
                #endregion
            }
            return mailStr;
        }


        [WebMethod]
        public static string checkBeforeReg(string st, string mail)
        {
            string st1 = doesExists(st).ToLower();
            string st2 = doesMailExists(mail).ToLower();

            if (st1 == "true" && st2 == "true") return "both";
            if (st1 == "false" && st2 == "true") return "mail";
            if (st1 == "true" && st2 == "false") return "user";
            if (st1 == "false" && st2 == "false") return "ok";

            return "WTF";
        }

        private void changeLoginDiv(string userS)
        {
            if (userS != null && userS != "")
            {
                changer.InnerHtml =
                    "<div id='loginR'>" + userS +
                    "<br /><span class='link' id='loggeduser' onclick='openProfile()'>Profile</span><span style='font-size:13px; font-weight: normal; vertical-align:1px;'> | </span><span id='logout' class='link' onclick='logOut()'>Logout</span></div>";
                usernameVar = userS;


                if (Request.Cookies["cookie2"] != null)
                    passVar = Server.HtmlEncode(Request.Cookies["cookie2"].Value);
                else if (Session["session2"] != null)
                    passVar = (string)Session["session2"];
            }
        }

        private void changeLoginDivA(string userS)
        {
            if (userS != null && userS != "")
                changer.InnerHtml =
                    "<div id='loginR'>" + userS +
                    "<br /><span class='link' id='loggeduser'><a href='/Admin.aspx?orderBy=id' class='link' id='apro'>Profile</a></span><span style='font-size:13px; font-weight: normal; vertical-align:1px;'> | </span><span id='logout' class='link' onclick='logOut()'>Logout</span></div>";
        }

    }
}