using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace wTeamPenguin
{
    public partial class AdminEdit : System.Web.UI.Page
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

                if (Session[_default.enc.EncryptToString("adminEdit")] != null)
                {
                    string id = _default.enc.DecryptString((string)Session[_default.enc.EncryptToString("adminEdit")]);


                    #region inputs
                    if (!IsPostBack)
                    {
                        string nhtml = "<table style='margin:auto; margin-top: 80px;'>";

                        nhtml += "<tr style='padding:30px;'>";
                        nhtml += "<td><input type='text' name='username' placeholder='Username' value='" + _default.db.ExecuteStringRead("SELECT username FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "<td><input type='text' name='Password' placeholder='Password' value='" + _default.db.ExecuteStringRead("SELECT password FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "<td><input type='text' name='Firstname' placeholder='First Name' value='" + _default.db.ExecuteStringRead("SELECT fname FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "<td><input type='text' name='Lastname' placeholder='Last Name' value='" + _default.db.ExecuteStringRead("SELECT lname FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "</tr>";

                        nhtml += "<tr style='padding:30px;'>";
                        nhtml += "<td><input type='text' name='email' placeholder='Email' value='" + _default.db.ExecuteStringRead("SELECT email FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "<td><input type='text' name='activated' placeholder='Activated' value='" + _default.db.ExecuteStringRead("SELECT activated FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "<td><input type='text' name='city' placeholder='City' value='" + _default.db.ExecuteStringRead("SELECT city FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "<td><input type='text' name='country' placeholder='Country' value='" + _default.db.ExecuteStringRead("SELECT country FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "</tr>";

                        nhtml += "<tr style='padding:30px;'>";
                        nhtml += "<td><input type='text' name='day' min='1' max='31' placeholder='Day' style='width: 100px;' value='" + _default.db.ExecuteStringRead("SELECT bday FROM users WHERE userid=" + id + "") + "'></td>";
                        nhtml += "<td><input type='text' name='month' min='1' max='12' placeholder='Month' style='width: 100px;' value='" + _default.db.ExecuteStringRead("SELECT bmonth FROM users WHERE userid=" + id + "") + "'></td>";
                        nhtml += "<td><input type='text' name='year' min='1910' max='" + DateTime.Now.Year + "' placeholder='Year' style='width: 100px;' value='" + _default.db.ExecuteStringRead("SELECT byear FROM users WHERE userid=" + id + "") + "'></td>";
                        nhtml += "<td><input type='text' name='image' placeholder='Image' value='" + _default.db.ExecuteStringRead("SELECT image FROM users WHERE userid=" + id + "") + "' /></td>";
                        nhtml += "<br/><br/></tr>";

                        nhtml += "</table>";

                        nhtml += "<div style='margin-left:auto;margin-right:auto;width:300px; margin-top: 5px;'><img style='margin:auto;max-width:300px; max-height: 250px;' src='Uploads/" + _default.db.ExecuteStringRead("SELECT username FROM users WHERE userid=" + id + "") + _default.db.ExecuteStringRead("SELECT image FROM users WHERE userid=" + id + "") + "' /><br/>";
                        nhtml += "<input type='submit' name='deleteImage' value='Delete Image' style='margin:auto; margin-top: 10px; width:300px;' />    ";
                        nhtml += "<br/><br/><input type='submit' name='SaveChanges' value='Save Changes' style='margin:auto;width:300px;' />";
                        nhtml += "<br/><br/><input type='submit' name='Back' value='Back to admin page' style='margin:auto;width:300px;/></div>";

                        mainF.InnerHtml = nhtml;
                    }
                    #endregion

                    else
                    {
                        if (Request.Form["deleteImage"] != null)
                        {
                            string path = Request.PhysicalApplicationPath + @"\Uploads\" + _default.db.ExecuteStringRead("SELECT username FROM users WHERE userid=" + id + "")
                                            + _default.db.ExecuteStringRead("SELECT [image] FROM users WHERE userid=" + id + "");
                            if (File.Exists(path)) File.Delete(path);

                            _default.db.ExecuteQuery("UPDATE users SET [image]='' WHERE userid=" + id);
                            Response.Redirect("Admin.aspx?orderBy=id");
                        }

                        #region save
                        if (Request.Form["SaveChanges"] != null)
                        {
                            string nImage = Request.Form["image"];
                            string meg = nImage;

                            if (!String.IsNullOrEmpty(meg) && !(meg == ".jpeg" || meg == ".gif" || meg == ".png" || meg == ".bmp" || meg == ".jpg"))
                            {
                                if (_default.UrlExists(meg))
                                {
                                    string remoteImgPath = meg;
                                    Uri remoteImgPathUri = new Uri(remoteImgPath);
                                    string remoteImgPathWithoutQuery = remoteImgPathUri.GetLeftPart(UriPartial.Path);
                                    string localPath = Request.PhysicalApplicationPath + @"\Uploads\" + _default.db.ExecuteStringRead("SELECT username FROM users WHERE userid=" + id + "") + Path.GetExtension(remoteImgPathWithoutQuery);
                                    WebClient webClient = new WebClient();
                                    webClient.DownloadFile(remoteImgPath, localPath);

                                    nImage = Path.GetExtension(remoteImgPathWithoutQuery);
                                }
                            }


                            _default.db.ExecuteQuery("UPDATE users SET username=@user, [password]=@pass, email=@email, activated=@active, fname=@fname, lname=@lname, "
                                                      + "country=@country, city=@city, bday=@bday, bmonth=@bmonth, byear=@byear, [image]=@meg WHERE userid=" + id,
                                                      new string[] { "user", "pass", "email", "active", "fname", "lname", "country", "city", "bday", "bmonth", "byear", "meg" },
                                                      new string[] { Request.Form["username"], Request.Form["Password"], Request.Form["email"], Request.Form["activated"], Request.Form["Firstname"], 
                                                  Request.Form["Lastname"], Request.Form["country"], Request.Form["city"], Request.Form["day"], Request.Form["month"], Request.Form["year"], nImage });

                            Response.Redirect("Admin.aspx?orderBy=id");
                        }
                        #endregion

                        if (Request.Form["Back"] != null)
                        {
                            Session[_default.enc.EncryptToString("adminEdit")] = "";
                            Response.Redirect("Admin.aspx?orderBy=id");
                        }

                    }
                }
            }
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