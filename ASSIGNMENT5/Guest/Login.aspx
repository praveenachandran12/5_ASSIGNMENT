<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/Guest.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASSIGNMENT5.Guest.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><center>LOGIN FORM</center></h1>
                       
              
     <table align="center" bgcolor="white" >
                
     
                <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="uname" runat="server" required></asp:TextBox><br /><br />
                    </td>
                </tr>
                <tr>
                    <td> Password</td>
                    <td>
                        <asp:TextBox ID="pswd" runat="server" TextMode="Password" required></asp:TextBox><br /><br />
                    </td>
                </tr>
                
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"  />
            </td>
        </tr>
                         
            </table>
</asp:Content>
