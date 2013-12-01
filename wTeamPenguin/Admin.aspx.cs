using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wTeamPenguin
{
    public partial class Admin : System.Web.UI.Page
    {
        public static int redirect = -10;
        bool canP = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Security
            string st = (string)Session["session1"];
            string ps = (string)Session["session2"];

            if ((st == null || st == "") || (ps == null || ps == "") || st != "AdminEntered" || ps != "#NREW23rhtfdsffd#F$6gfd")
            {
                if (Request.Cookies["cookie1"] != null && Request.Cookies["cookie2"] != null)
                {
                    st = Server.HtmlEncode(Request.Cookies["cookie1"].Value);
                    ps = Server.HtmlEncode(Request.Cookies["cookie2"].Value);

                    if (st != "AdminEntered" || ps != "#NREW23rhtfdsffd#F$6gfd")
                    {
                        mainF.InnerHtml = "<p style='margin-top:80px;'>You Are Not Supposed To Be Here.</p>";
                        if (redirect == -10) redirect = 1;
                        canP = false;
                    }
                }
                else
                {
                    mainF.InnerHtml = "<p style='margin-top:80px;'>You Are Not Supposed To Be Here.</p>";
                    if (redirect == -10) redirect = 1;
                    canP = false;
                }
            }



            if (canP)
            {
                timer1.Interval = Int32.MaxValue;
            #endregion

                string order = Request.QueryString["orderBy"];

                string n = "<table style='margin-left:auto; margin-right:auto; margin-top: 100px;'>";

                if (order == "id")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'><b>id</b></a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY userid") + "</table>";
                }
                if (order == "username")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'><b>username</b></a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY username,userid") + "</table>";
                }
                if (order == "password")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'><b>password</b></a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY password,userid") + "</table>";
                }
                if (order == "logins")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'><b>logins</b></a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY logins DESC,userid") + "</table>";
                }
                if (order == "email")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'><b>email</b></a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY email,userid") + "</table>";
                }
                if (order == "active")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'><b>activated</b></a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY activated,userid") + "</table>";
                }
                if (order == "firstname")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'><b>first name</b></a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY fname,userid") + "</table>";
                }
                if (order == "lastname")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'><b>last name</b></a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY lname,userid") + "</table>";
                }
                if (order == "country")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'><b>country</b></a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY country,userid") + "</table>";
                }
                if (order == "city")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'><b>city</b></a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY city,userid") + "</table>";
                }
                if (order == "bday")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'><b>birthday</b></a></th><th><a href='/Admin.aspx?orderBy=image'>image</a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY byear,bmonth,bday,userid") + "</table>";
                }
                if (order == "image")
                {
                    n += "<tr><th><a href='/Admin.aspx?orderBy=id'>id</a></th><th ><a href='/Admin.aspx?orderBy=username'>username</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=password'>password</a></th><th ><a href='/Admin.aspx?orderBy=logins'>logins</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=email'>email</a></th><th ><a href='/Admin.aspx?orderBy=active'>activated</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=firstname'>first name</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=lastname'>last name</a></th><th ><a href='/Admin.aspx?orderBy=country'>country</a></th>";
                    n += "<th ><a href='/Admin.aspx?orderBy=city'>city</a></th><th colspan='3'><a href='/Admin.aspx?orderBy=bday'>birthday</a></th><th ><a href='/Admin.aspx?orderBy=image'><b>image</b></a></th><th></th><th></th>";

                    n += "<tr />" + _default.db.ExecuteSpecialTableStringRead("SELECT * FROM users ORDER BY image DESC,userid") + "</table>";
                }


                n += "<table style='margin-left:auto; margin-right:auto; margin-top:80px;'><tr><td><input type='submit' name='Back' value='Back to homepage' style='margin:auto;' /></td></tr></table><br /><br />";

                mainF.InnerHtml = n;


                if (IsPostBack)
                {
                    string ch;
                    int lastId = Convert.ToInt32(_default.db.ExecuteStringRead("SELECT MAX(userid) FROM users"));
                    for (int i = 0; i <= lastId; i++)
                    {
                        ch = "Edit" + i;
                        if ((Request.Form[(string)ch] != null))
                            BtnsClick(i);

                        ch = "Delete" + i;
                        if ((Request.Form[(string)ch] != null))
                            DelBtnsClick(i);

                    }

                    if (Request.Form["Back"] != null) Response.Redirect("default.aspx");

                }
            }
        }

        private void BtnsClick(int num)
        {
            Session[_default.enc.EncryptToString("adminEdit")] = _default.enc.EncryptToString(Convert.ToString(num));
            Page.Response.Redirect("AdminEdit.aspx");
        }

        private void DelBtnsClick(int num)
        {
            _default.db.ExecuteQuery("DELETE FROM users WHERE userid=" + num + ";");
            Page.Response.Redirect("Admin.aspx?orderBy=id");
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            if (redirect > 0)
            {
                redirect++;
                if (redirect >= 5)
                    Page.Response.Redirect("http://www.google.com", false);
            }
        }
    }
}