<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEdit.aspx.cs" Inherits="wTeamPenguin.AdminEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Edit</title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <style>
        @font-face
        {
            font-family: 'open_sansregular';
            src: url('Fonts/opensans-regular-webfont.eot');
            src: url('Fonts/opensans-regular-webfont.eot?#iefix') format('embedded-opentype'), url('Fonts/opensans-regular-webfont.woff') format('woff'), url('Fonts/opensans-regular-webfont.ttf') format('truetype'), url('Fonts/opensans-regular-webfont.svg#open_sansregular') format('svg');
            font-weight: normal;
            font-style: normal;
        }

        *
        {
            -webkit-touch-callout: none;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            font-family: 'open_sansregular', Arial;
        }

        label
        {
            text-align: justify;
            font-size: 0.9em;
            font-family: 'open_sansregular', Arial;
            font-weight: 500;
            text-transform: none;
            color: black;
            opacity: .9;
        }

        input:not([type=submit]):not([type=file]):not([type=checkbox])
        {
            transition: all 0.8s;
            -webkit-transition: all 0.3s;
            font-family: 'open_sansregular', Arial;
            outline: none;
            padding: 3px 0px 3px 3px;
            margin: 5px 1px 3px 0px;
            border: 1px solid #cccccc;
            -webkit-user-select: text;
            -khtml-user-select: text;
            -moz-user-select: text;
            -ms-user-select: text;
            user-select: text;
        }

            input:not([type=submit]):not([type=file]):not([type=checkbox]):focus
            {
                box-shadow: 0 0 5px #50bcfa;
                padding: 3px 0px 3px 3px;
                margin: 5px 1px 3px 0px;
                border: 1px solid #50bcfa;
            }

        input[type=submit], button
        {
            font-size: 0.9em;
            font-family: 'open_sansregular', Arial;
            font-weight: lighter;
            text-transform: uppercase;
            padding: 8px 25px 8px 25px;
            border: 1px solid #DDDDDD;
            background-color: white;
        }

        input[type=checkbox]
        {
            border: none;
            width: 15px;
            height: 15px;
            outline: none;
            padding: 0;
            margin: 0;
            vertical-align: bottom;
            position: relative;
            top: -1px;
            *overflow: hidden;
        }

        td
        {
            border: 0px none;
        }

        table
        {
            background-color: rgb(240,240,240);
        }

        tr
        {
            border-bottom: 1px rgba(0,0,0,0);
            border-top: 1px rgba(0,0,0,0);
            border-left: 0px rgba(0,0,0,0);
            border-right: 0px rgba(0,0,0,0);
        }

        body
        {
            overflow-y: auto;
            overflow-x: hidden;
            width: 100%;
            height: auto;
            cursor: default;
            background: rgb(14,14,14); /* Old browsers - apparently also IE9 */
            /* IE10 Consumer Preview */
            background-image: -ms-radial-gradient(center, circle farthest-corner, rgb(37,37,37) 0%, #000000 100%);
            /* Mozilla Firefox */
            background-image: -moz-radial-gradient(center, circle farthest-corner, rgb(37,37,37) 0%, #000000 100%);
            /* Opera */
            background-image: -o-radial-gradient(center, circle farthest-corner, rgb(37,37,37) 0%, #000000 100%);
            /* Webkit (Safari/Chrome 10) */
            background-image: -webkit-gradient(radial, center center, 0, center center, 506, color-stop(0, rgb(37,37,37)), color-stop(1, #000000));
            /* Webkit (Chrome 11+) */
            background-image: -webkit-radial-gradient(center, circle farthest-corner, rgb(25,25,25) 0%, #000000 100%);
            /* W3C Markup, IE10 Release Preview */
            background-image: radial-gradient(circle farthest-corner at center, rgb(25,25,25) 0%, #000000 100%);
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: auto;" id="mainF" runat="server">
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="timer1" Interval="1000" Enabled="true" runat="server" OnTick="timer1_Tick"></asp:Timer>
    </form>
</body>
</html>
