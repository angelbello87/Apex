<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WF_FrontEnd.aspx.cs" Inherits="Apex.WF_FrontEnd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>APEX</title>
</head>
<body>
    <form id="form1" runat="server">
        <meta charset="utf-8" />    
    <style>
        body {
            background: #fff;
            color: #505050;
            font: 14px 'Segoe UI', tahoma, arial, helvetica, sans-serif;
            margin: 20px;
            padding: 0;
        }

        #header {
            background: #efefef;
            padding: 0;
        }

        h1 {
            font-size: 48px;
            font-weight: normal;
            margin: 0;
            padding: 0 30px;
            line-height: 150px;
        }

        p {
            font-size: 20px;
            color: #fff;
            background: #969696;
            padding: 0 30px;
            line-height: 50px;
        }

        #main {
            padding: 5px 30px;
        }

        .section {
            width: 21.7%;
            float: left;
            margin: 0 0 0 4%;
            height: 241px;
        }

            .section h2 {
                font-size: 13px;
                text-transform: uppercase;
                margin: 0;
                
                padding-bottom: 12px;
                margin-bottom: 8px;
            }

            .section.first {
                margin-left: 0;
            }

                .section.first h2 {
                    font-size: 24px;
                    text-transform: none;
                    margin-bottom: 25px;
                    border: none;
                }

                .section.first li {
                    border-top: 1px solid silver;
                    padding: 8px 0;
                }

            .section.last {
                margin-right: 0;
            }

        ul {
            list-style: none;
            padding: 0;
            margin: 0;
            line-height: 20px;
        }

        li {
            padding: 4px 0;
        }

        a {
            color: #267cb2;
            text-decoration: none;
        }

            a:hover {
                text-decoration: underline;
            }
    </style>
        <div style=" align-content:stretch">
            <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/Images/apexlogo.png" />
        </div>
        <div style="align-content:center" class=" section last">
            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" /> 
            <br />
            <br /> 
            <asp:Button ID="btn_export" runat="server" Text="Export" Height="25px" Width="61px" OnClick="btn_export_Click" />
        </div>        
        
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
               
            </asp:ScriptManager>
             <div class="section first">
                 <asp:Label ID="lbl_start" runat="server"></asp:Label>
                 <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageAlign="Middle" ImageUrl="~/Images/images.png" OnClick="ImageButton1_Click" Width="30px" />
                 <br />
            <asp:Calendar ID="cal_startdatereport" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" SelectedDate="2003-02-01" VisibleDate="2016-07-24" Width="220px" Caption="Select Start Due Date" CaptionAlign="Top" CellPadding="1" Font-Bold="True" OnSelectionChanged="cal_startdatereport_SelectionChanged" UseAccessibleHeader="False">
                <DayHeaderStyle BackColor="#99CCCC" Height="1px" ForeColor="#336666" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" BorderColor="#3366CC" BorderWidth="1px" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>
            <br />
        </div>

               <div class="section last">            
                   <asp:Label ID="lbl_end" runat="server"></asp:Label>
                   <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageAlign="Middle" ImageUrl="~/Images/images.png" OnClick="ImageButton2_Click" Width="30px" />
&nbsp;<h2>
                       <asp:Calendar ID="cal_enddatereport" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" SelectedDate="2005-11-30" Caption="Select End Due Date" CaptionAlign="Top" CellPadding="1" Font-Bold="True" OnSelectionChanged="cal_enddatereport_SelectionChanged">
                           <DayHeaderStyle BackColor="#99CCCC" Height="1px" ForeColor="#336666" />
                           <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" HorizontalAlign="Left" Wrap="True" />
                           <OtherMonthDayStyle ForeColor="#999999" />
                           <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                           <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                           <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" BorderColor="#3366CC" BorderWidth="1px" Height="25px" />
                           <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                           <WeekendDayStyle BackColor="#CCCCFF" />
                       </asp:Calendar>
                   </h2>
        </div>

        </div>
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
    <div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
