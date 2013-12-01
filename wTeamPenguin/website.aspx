<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="website.aspx.cs" Inherits="wTeamPenguin.website" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="bbb" style="display: none;">
            <div id="news">
                <div id="Div1" style="width: 70%; margin-left: auto; margin-right: auto;">
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="headline">News</div>
                    <br style="font-size: 3em;" />
                    <b>17.4.1952</b> - <a href="http://TeamPenguin.somee.com">http://TeamPenguin.somee.com</a> has just been uploaded to the net and is now on the air.<br />
                    <hr />
                    <b>17.4.<% Response.Write(DateTime.Now.Year.ToString()); %></b> - <i>Messege from Team Penguin's web-news editors: </i>terribly sorry for the long pause in the news flow, we were experiencing some technical difficulties.<br />
                    Any way, We're back on air !<br />
                    <hr />
                    <b>18.4.<% Response.Write(DateTime.Now.Year.ToString()); %></b> - And for some exciting news: rumors from within the close walls of the Team Penguin Corporation has it that George has commanded the high council to start working on an International version of the groundbreaking game Project Penguin.<br />
                    <hr />
                    <b>18.4.<% Response.Write(DateTime.Now.Year.ToString()); %></b> - As surly remembered, the former release of Project Penguin in 1932 has been limited for Antarctica residents only. Nevertheless, Project Penguin in it's first realese is remember to this day for it's successfullness and grounbreaking gaming style.<br />
                    <hr />
                    <b>18.4.<% Response.Write(DateTime.Now.Year.ToString()); %></b> - Now when you are as excited as you should be from your newly accuaired information, follow us on either our Twitter or Facebook accounts. Links on the bottom.<br />
                    <hr />
                    <b>19.4.<% Response.Write(DateTime.Now.Year.ToString()); %></b> - Great news from headquarters! The highly anticipated SolitaireG is now on development. We have just been informed that the new main menu has just been finished and is absolutely breathtaking.<br />
                    <hr />
                    <b>19.4.<% Response.Write(DateTime.Now.Year.ToString()); %></b> - Excited ?! Just as you should be ! Follow us on Twitter or Facebook to satisfy your excitement, Links on the bottom.<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>
            <div id="company">
                <div style="width: 80%; margin-left: auto; margin-right: auto;">
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="headline">Company</div>
                    <br style="font-size: 3em;" />
                    Team Penguin (formerly known as Penguins Under Cover) is an International video game (and occasional PC program) development and distribution company based in Garden Gnome Station, Antartica.<br />
                    Founded in 1873 by the Almighty Penguin God of the Team Penguin Corporation, George, Team Penguin is mostly known by it's ever-lasting world-wide-famous game development style and creativity.<br />
                    Team Penguin's mostly known game is their world wide successfull groundbreaking signature game - Project Penguin, released in 1932 for Antarctica residents only.<br />
                    Also from Team Penguin comes the most addictive smartphones' game app known-to-all as SolitaireG.
                </div>
            </div>
            <div id="contact">
                <div style="width: 74%; margin-left: auto; margin-right: auto;">
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="headline">Contact</div>
                    <br style="font-size: 5em;" />
                    <b style="padding-right: 5px;">Contact by email:</b> TeamPenguinES@gmail.com
                    <hr style="margin: 15px 0px 15px 0px;" />
                    <b style="padding-right: 13px;">Contact by mail:</b> Peng St. 42 | Garden Gnome Station | Antarctica.
                </div>
            </div>
            <div id="jobs">
                <div style="width: 75%; margin-left: auto; margin-right: auto;">
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="headline">Jobs</div>
                    <br style="font-size: 3em;" />
                    Currently looking for experienced 3D Modelers and level designers.<br />
                    Also accepting programmers from all levels of experience.<br />
                    <br />
                    For job interview appliance please email us at TeamPenguinES@gmail.com with the title 'Job Appliance'.
                </div>
            </div>

            <%-- -------------------------------------------------------------- --%>

            <div id="Games">
                <a href="http://SolitaireG.somee.com" style="cursor: pointer;" class="link">
                    <div class="link" style="-webkit-box-shadow: inset 0 0 15px 5px rgba(0,0,0,.2); box-shadow: inset 0 0 15px 7px rgba(0,0,0,.2); background: #14a803; background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPHJhZGlhbEdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgY3g9IjUwJSIgY3k9IjUwJSIgcj0iNzUlIj4KICAgIDxzdG9wIG9mZnNldD0iMCUiIHN0b3AtY29sb3I9IiMxNGE4MDMiIHN0b3Atb3BhY2l0eT0iMSIvPgogICAgPHN0b3Agb2Zmc2V0PSIxMDAlIiBzdG9wLWNvbG9yPSIjMGI1YTAyIiBzdG9wLW9wYWNpdHk9IjEiLz4KICA8L3JhZGlhbEdyYWRpZW50PgogIDxyZWN0IHg9Ii01MCIgeT0iLTUwIiB3aWR0aD0iMTAxIiBoZWlnaHQ9IjEwMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+); background: -moz-radial-gradient(center, ellipse cover, #14a803 0%, #0b5a02 100%); background: -webkit-gradient(radial, center center, 0px, center center, 100%, color-stop(0%,#14a803), color-stop(100%,#0b5a02)); background: -webkit-radial-gradient(center, ellipse cover, #14a803 0%,#0b5a02 100%); background: -o-radial-gradient(center, ellipse cover, #14a803 0%,#0b5a02 100%); background: -ms-radial-gradient(center, ellipse cover, #14a803 0%,#0b5a02 100%); background: radial-gradient(ellipse at center, #14a803 0%,#0b5a02 100%); filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#14a803', endColorstr='#0b5a02',GradientType=1 ); margin: 3px 0px;">
                        <div id="solitaireG" class="gameBanner link">
                            <img src="images/AndroidBackground.png" class="link" style="width: 220px; margin-top: 70px;" />
                            <img src="images/icon2.png" class="link" style="margin-top: -80px; margin-left: 460px; width: 110px; height: 110px;" />
                        </div>
                    </div>
                </a>
                <div style="-webkit-box-shadow: inset 0 0 15px 5px rgba(0,0,0,.2); box-shadow: inset 0 0 15px 7px rgba(0,0,0,.2); background: #0c0c0c; background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPHJhZGlhbEdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgY3g9IjUwJSIgY3k9IjUwJSIgcj0iNzUlIj4KICAgIDxzdG9wIG9mZnNldD0iMCUiIHN0b3AtY29sb3I9IiMwYzBjMGMiIHN0b3Atb3BhY2l0eT0iMSIvPgogICAgPHN0b3Agb2Zmc2V0PSI3NiUiIHN0b3AtY29sb3I9IiMwMDAwMDAiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvcmFkaWFsR3JhZGllbnQ+CiAgPHJlY3QgeD0iLTUwIiB5PSItNTAiIHdpZHRoPSIxMDEiIGhlaWdodD0iMTAxIiBmaWxsPSJ1cmwoI2dyYWQtdWNnZy1nZW5lcmF0ZWQpIiAvPgo8L3N2Zz4=); background: -moz-radial-gradient(center, ellipse cover, #0c0c0c 0%, #000000 76%); background: -webkit-gradient(radial, center center, 0px, center center, 100%, color-stop(0%,#0c0c0c), color-stop(76%,#000000)); background: -webkit-radial-gradient(center, ellipse cover, #0c0c0c 0%,#000000 76%); background: -o-radial-gradient(center, ellipse cover, #0c0c0c 0%,#000000 76%); background: -ms-radial-gradient(center, ellipse cover, #0c0c0c 0%,#000000 76%); background: radial-gradient(ellipse at center, #0c0c0c 0%,#000000 76%); filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#0c0c0c', endColorstr='#000000',GradientType=1 ); color: white; margin: 3px 0px;">
                    <div id="ProjectPenguin" class="gameBanner">
                        <br />
                        <p style="font-size: 1.2em; font-family: 'open_sansregular', Arial; font-weight: lighter; text-decoration: underline;">
                            Project Penguin
                        </p>
                        <br />
                        <br />
                        <img src="images/contsr.png" style="margin-top: -80px; margin-left: 460px; width: 110px; height: 120px;" />
                    </div>
                </div>
                <a href="/VirtualTV.rar" style="cursor: pointer;">
                    <div class="link" style="-webkit-box-shadow: inset 0 0 15px 5px rgba(0,0,0,.2); box-shadow: inset 0 0 15px 7px rgba(0,0,0,.2); background: #00478e; background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPHJhZGlhbEdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgY3g9IjUwJSIgY3k9IjUwJSIgcj0iNzUlIj4KICAgIDxzdG9wIG9mZnNldD0iMCUiIHN0b3AtY29sb3I9IiMwMDQ3OGUiIHN0b3Atb3BhY2l0eT0iMSIvPgogICAgPHN0b3Agb2Zmc2V0PSIxMDAlIiBzdG9wLWNvbG9yPSIjMTMzZTYwIiBzdG9wLW9wYWNpdHk9IjEiLz4KICA8L3JhZGlhbEdyYWRpZW50PgogIDxyZWN0IHg9Ii01MCIgeT0iLTUwIiB3aWR0aD0iMTAxIiBoZWlnaHQ9IjEwMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+); background: -moz-radial-gradient(center, ellipse cover, #00478e 0%, #133e60 100%); background: -webkit-gradient(radial, center center, 0px, center center, 100%, color-stop(0%,#00478e), color-stop(100%,#133e60)); background: -webkit-radial-gradient(center, ellipse cover, #00478e 0%,#133e60 100%); background: -o-radial-gradient(center, ellipse cover, #00478e 0%,#133e60 100%); background: -ms-radial-gradient(center, ellipse cover, #00478e 0%,#133e60 100%); background: radial-gradient(ellipse at center, #00478e 0%,#133e60 100%); filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#00478e', endColorstr='#133e60',GradientType=1 ); color: white; margin: 3px 0px;">
                        <div id="Virtual VOD" class="gameBanner link">
                            <img src="images/VirtualTV.png" class="link" style="margin-top: 40px; margin-left: 460px; width: 110px; height: 110px;" />
                            <p class="link" style="font-size: 0.8em; font-family: 'open_sansregular', Arial; font-weight: lighter; text-decoration: none; margin-top: -70px;">
                                Download <span class="link" style="font-size: 2em; text-decoration: underline;">Virtual TV</span> Beta
                            </p>
                        </div>
                    </div>
                </a>
                <div style="-webkit-box-shadow: inset 0 0 15px 5px rgba(0,0,0,.2); box-shadow: inset 0 0 15px 7px rgba(0,0,0,.2); background: #b62a11; background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPHJhZGlhbEdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgY3g9IjUwJSIgY3k9IjUwJSIgcj0iNzUlIj4KICAgIDxzdG9wIG9mZnNldD0iMCUiIHN0b3AtY29sb3I9IiNiNjJhMTEiIHN0b3Atb3BhY2l0eT0iMSIvPgogICAgPHN0b3Agb2Zmc2V0PSI5OSUiIHN0b3AtY29sb3I9IiNiMjAwMDAiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvcmFkaWFsR3JhZGllbnQ+CiAgPHJlY3QgeD0iLTUwIiB5PSItNTAiIHdpZHRoPSIxMDEiIGhlaWdodD0iMTAxIiBmaWxsPSJ1cmwoI2dyYWQtdWNnZy1nZW5lcmF0ZWQpIiAvPgo8L3N2Zz4=); background: -moz-radial-gradient(center, ellipse cover, #b62a11 0%, #b20000 99%); background: -webkit-gradient(radial, center center, 0px, center center, 100%, color-stop(0%,#b62a11), color-stop(99%,#b20000)); background: -webkit-radial-gradient(center, ellipse cover, #b62a11 0%,#b20000 99%); background: -o-radial-gradient(center, ellipse cover, #b62a11 0%,#b20000 99%); background: -ms-radial-gradient(center, ellipse cover, #b62a11 0%,#b20000 99%); background: radial-gradient(ellipse at center, #b62a11 0%,#b20000 99%); filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#b62a11', endColorstr='#b20000',GradientType=1 ); color: white; margin: 3px 0px;">
                    <div id="Pyromaniac" class="gameBanner">
                        <br />
                        <p style="font-size: 1.2em; font-family: 'open_sansregular', Arial; font-weight: lighter; text-decoration: underline;">
                            Pyromaniac
                        </p>
                        <br />
                        <img src="images/contsr.png" style="margin-top: -60px; margin-left: 460px; width: 110px; height: 120px;" />
                    </div>
                </div>


                <div class="link" onclick="alert('');" style="top: 205px; cursor: pointer; position: absolute; height: 197px; width: 100%;">
                </div>
                <div class="link" onclick="alert('');" style="top: 605px; cursor: pointer; position: absolute; height: 197px; width: 100%;">
                </div>
            </div>

        </div>
    </form>
</body>
</html>
