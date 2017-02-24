<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationControl.aspx.cs" Inherits="SciHospital.WebApp.ValidationControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <script type="text/C#" runat="server">

        protected void MyCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (!string.IsNullOrEmpty(Amount.Text) && !string.IsNullOrEmpty(Percent.Text))
            {
                args.IsValid = false;
            }
        }
    </script>

    <form id="form1" runat="server">
        <div>
            <asp:CustomValidator runat="server"
                ID="MyCustomValidator"
                ValidationGroup="Money"
                OnServerValidate="MyCustomValidator_ServerValidate"
                ErrorMessage="You can specify only amount or percent"
                ForeColor="Red" />


            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="Amount"
                ErrorMessage="Only numeric allowed for amount" ForeColor="Red"
                ValidationExpression="^[0-9]*$"
                ValidationGroup="Money">
            </asp:RegularExpressionValidator>
            <p>
                amount
                <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
            </p>

            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="Percent"
                ErrorMessage="Only numeric allowed for Percent" ForeColor="Red"
                ValidationExpression="^[0-9]*$"
                ValidationGroup="Money">
            </asp:RegularExpressionValidator>

            <p>
                percent
                <asp:TextBox ID="Percent" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Save" runat="server" Text="Button" OnClick="Save_OnClick" ValidationGroup="Money" />
            </p>
        </div>
    </form>
</body>
</html>
