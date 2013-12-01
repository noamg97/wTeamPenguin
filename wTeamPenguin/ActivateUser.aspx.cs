using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wTeamPenguin
{
    public partial class ActivateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Request.QueryString["n14325"]))
            {
                // no username value
                form1.InnerHtml = "<script>alert('No username was provided.'); window.location.replace('default.aspx');</script>";
            }
            else
            {
                string user = "";
                bool conti = true;

                try
                {
                    user = _default.enc.DecryptString(Request.QueryString["n14325"]);
                }
                catch (Exception ex)
                {
                    form1.InnerHtml = "<script>alert('Invalid username value.'); window.location.replace('default.aspx');</script>";
                    conti = false;
                }
                if (conti)
                {
                    if (_default.doesExists(user) == "nonactive")
                    {
                        _default.db.ExecuteQuery("UPDATE users SET [activated]='t' WHERE username=@usr", new string[] { "usr" }, new string[] { user });
                        form1.InnerHtml = "<script>alert('Your account has been activated.'); window.location.replace('default.aspx');</script>";
                    }
                    else
                    {
                        form1.InnerHtml = "<script>alert('Username does not exists or has already been activated.'); window.location.replace('default.aspx');</script>";
                    }
                }
            }
        }
    }
}