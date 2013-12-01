<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="wTeamPenguin._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Team Penguin</title>
    <meta name="keywords" content="Team, Penguin, Team-Penguin, Team Penguin, SolitaireG, Project-Penguin, TeamPenguin, Project Penguin, Game, Games, Garden Gnome Station, video game, Penguins Under Cover, Almighty Penguin God, Team Penguin Corporation, George, ever-lasting, world-wide-famous, groundbreaking" />
    <meta name="author" content="Noam Gal of the Team Penguin Corporation" />
    <meta name="description" content="Official website of Team Penguin" />
    <link rel="shortcut icon" href="images/icon.jpg" />
    <link href="StyleSheet1.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="fb-root"></div>
        <div id="blacky"></div>
        <div id="header">
            <span id="changer" runat="server"><span id="login" class="link">Login</span></span>
            <span id="games" class="link" onclick="gamesFunc()">Games</span>
        </div>
        <pre id="titleD" class="link">Team<br />  Penguin</pre>
        <div id="menu">
            <span class="menuC link">news </span>
            <span class="menuC link">company </span>
            <span class="menuC link">contact </span>
            <span class="menuC link">jobs </span>
        </div>
        <div id="bodyD">
            <div id="wrap"></div>
        </div>
        <div id="a1" class="arrow link"></div>
        <div id="a2" class="arrow link"></div>
        <div id="progressWrap">
            <div id="progressValue"></div>
        </div>
        <div id="extraFoot">
            <br />
            <a href="https://twitter.com/TeamPegnuinOffi" class="twitter-follow-button" data-show-count="false" data-show-screen-name="false">Follow @TeamPegnuinOffi</a>
            <div class="fb-like" data-send="false" data-layout="button_count" data-width="450" data-show-faces="false"></div>
            <br />
            <br />
            All rights reserved to Team Penguin 
        </div>
        <div id="bgD"></div>
        <div id="container">
            <img src="images/exit.png" id="exit" class="link" />
            <img src="images/back.png" id="back" class="link" />
            <div id="logindiv">
                <div style="margin: auto; width: 80%; height: 100%;">
                    <br />
                    <br />
                    <span class="headline">login</span>
                    <br />
                    <br />
                    <br />
                    Username :
                    <input type="text" id="user" name="user" /><br />
                    Password :
                    <input type="password" id="pass" name="pass" /><br />
                    <label id="checkLabel" for="rememberME" class="link">
                        <input type="checkbox" id="rememberME" value="remember" runat="server" class="link" />
                        remember me</label>
                    <br />
                    <br />
                    <button id="log" runat="server" onclick="return LogIn();" style="margin-left: -1px; margin-top: 3px;">login</button>
                    <label id="errorLabel"></label>
                    <br />
                    <span id="rrrr">
                        <br />
                        <br />
                    </span>
                    <br />
                    <span id="registerSpan" onclick="openRegister();" class="link clickSpan">Don't have a user?     Register!</span><br />
                    <span id="forgpassSpan" onclick="openForgotten()" class="link clickSpan">Forgot my password</span>
                </div>
            </div>
            <div id="registerDiv">
                <div style="margin-left: 10%; width: 90%; height: 100%;">
                    <br />
                    <br />
                    <span class="headline">register</span>
                    <br />
                    <br />
                    Username<span style="color: red"> *</span> :
                    <input type="text" id="ruser" name="ruser" onblur="validate(1)" />
                    <label id="Label1"></label>
                    <br />
                    Password<span style="color: red"> *</span> :
                    <input type="password" id="rpass" name="rpass" onblur="validate(2)" />
                    <label id="Label2"></label>
                    <br />
                    Email<span style="color: red"> *</span> :<span style="word-spacing: 35px;"> </span>
                    <input type="email" id="email" name="email" onblur="validate(3)" />
                    <label id="Label3"></label>
                    <br />
                    First Name :<span style="word-spacing: 7px;"> </span>
                    <input type="text" id="fname" name="fname" onblur="validate(4)" />
                    <label id="Label4"></label>
                    <br />
                    Last Name :<span style="word-spacing: 11px;"> </span>
                    <input type="text" id="lname" name="lname" onblur="validate(5)" />
                    <label id="Label5"></label>
                    <br />
                    Birthday :<span style="word-spacing: 21px;"> </span>
                    <select name="day" style="width: 80px;" class="day" id="day"></select><select name="month" style="width: 80px;" class="month" id="month"></select><select name="year" style="width: 88px;" class="year" id="year"></select>
                    <label id="Label6"></label>
                    <br />
                    Country :<span style="word-spacing: 21px;"> </span>
                    <input type="text" id="country" name="country" onblur="validate(7)" />
                    <label id="Label7"></label>
                    <br />
                    City :<span style="word-spacing: 58px;"> </span>
                    <input type="text" id="city" name="city" onblur="validate(8)" />
                    <label id="Label8"></label>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <button id="regis" onclick="return Register();" style="margin-left: -1px; margin-top: 3px;">register</button>
                    <label id="rlabel"></label>
                </div>
            </div>
            <div id="forgottenDiv">
                <div style="margin: auto; width: 80%; height: 100%;">
                    <br />
                    <br />
                    <span class="headline">Password Recovery</span>
                    <br />
                    <br />
                    <br />
                    <span style="font-size: 10px; vertical-align: 1px;">by</span> Email :
                    <input type="text" id="fmail" name="fmail" style="margin-left: 35px;" />
                    <div style="margin-top: -25px;">
                        <br />
                        <span style="font-size: 10px;">or</span>
                        <br />
                    </div>
                    <div style="margin-top: -5px;">
                        <span style="font-size: 10px; vertical-align: 1px;">by</span> Username :
                        <input type="text" id="fuser" name="fuser" />
                    </div>
                    <br />
                    <br />
                    <br />
                    <label id="fLabel"></label>
                    <br />
                    <button id="fButton" onclick="return retPass();" style="margin-left: -1px; margin-top: 3px;">Retrive Password</button>
                </div>
            </div>
            <div id="ProfileDiv">
                <div id="ProfileChild" style="margin: auto; width: 84%; height: 100%;">
                    <br />
                    <br />
                    <span class="headline" style="height: 171px;">Profile</span>
                    <br />
                    <br />
                    <br />
                    <table class="proTable">
                        <tr>
                            <td>Username:</td>
                            <td class="proTd">
                                <label id="usernameLabel" style="left: 100px; vertical-align: 3px;"></label>
                            </td>
                            <td rowspan="7" style="width: 8px; height: 145px; border: 0px none;"></td>
                            <td id="imageTd" rowspan="7" style="padding: 0px; width: 211px;"></td>
                        </tr>
                        <tr>
                            <td>First Name:</td>
                            <td class="proTd">
                                <label id="firstNameLabel" style="left: 100px; vertical-align: 3px;"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>Last Name:</td>
                            <td class="proTd">
                                <label id="lastNameLabel" style="left: 100px; vertical-align: 3px;"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>Email:</td>
                            <td class="proTd">
                                <label id="emailLabel" style="left: 100px; vertical-align: 3px;"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>Birthday:</td>
                            <td class="proTd">
                                <label id="birthdayLabel" style="left: 100px;"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>Country:</td>
                            <td class="proTd">
                                <label id="countryLabel" style="left: 100px; vertical-align: 3px;"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td class="proTd">
                                <label id="cityLabel" style="left: 100px; vertical-align: 3px;"></label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <span onclick="openEditProfile();" class="link clickSpan">Change Profile</span><br />
                    <span onclick="openImageChanger()" class="link clickSpan">Change Profile Image</span><br />
                    <span onclick="openPassChanger()" class="link clickSpan">Change Password</span>
                </div>
                <div id="imageUploader" style="display: none; margin: auto; width: 84%; height: 100%;">
                    <br />
                    <br />
                    <span class='headline'>Change Profile Image</span><br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <table>
                        <tr>
                            <td>Upload From URL:</td>
                            <td>
                                <input type='text' id="UrlImage" name='UrlImage' />
                            </td>
                            <td>
                                <input onclick="return checkme(1);" type='submit' name='upImageU' style='margin-left: 20px;' value='Upload' />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px; padding-right: 4px; width: 140px;">Upload Image File:</td>
                            <td style="padding-top: 10px; padding-right: 10px; width: 150px;">
                                <asp:FileUpload Height='22' Width="160px" ID='FileUpload1' runat='server' />
                            </td>
                            <td style="padding-top: 10px;">
                                <input onclick="return checkme(2);" type='submit' name='upImage' style='margin-left: 20px;' value='Upload' />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <button id="deleteImage" runat="server" onserverclick="deleteImageClick">Delete Profile Image</button>
                    <br />
                    <label id='ilabel' runat="server" style='position: absolute; margin-top: 8px;'></label>
                </div>
                <div id="ChangePass" style="display: none; margin: auto; width: 84%; height: 100%;">
                    <br />
                    <br />
                    <span class='headline'>Change Password</span><br />
                    <br />
                    <br />
                    <br />
                    <table style="width: 80%; margin: auto;">
                        <tr>
                            <td>Old Password</td>
                            <td style="padding-top: 10px;">
                                <input type='text' id="oPass" style="margin-left: auto;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px;">New Password</td>
                            <td style="padding-top: 10px;">
                                <input type='text' id="nPass" style="margin: auto;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px;">Re-Type New Password</td>
                            <td style="padding-top: 10px;">
                                <input type='text' id="nPass2" style="margin: auto;" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <label id='pLabel' style='position: absolute; margin-top: 8px;'></label>
                    <button onclick="ChangePassword(); return false;" id="changePassBtn" style='margin-left: 350px;'>Submit</button>
                </div>
            </div>
            <div id="gamesDiv">
            </div>
        </div>
        <div style="display: none;">
            <button id="logoutb" runat="server" onserverclick="logoutFunc" style="display: none;"></button>
            <button id="loginb" runat="server" onserverclick="loginFunc" style="display: none;"></button>
        </div>
        <div id="scripty" runat="server"></div>
    </form>
    <script type="text/javascript" src="JavaScript1.js"></script>
</body>
</html>
