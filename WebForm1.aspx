<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" ValidateRequest="false" Inherits="CRUD_Using_Ado.Net.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        body {
            width: 100%;
            margin: 5px;
        }

        .table {
            width:50%;
            border-collapse: collapse;
            margin: 25px 0;
            font-size: 0.9em;
            font-family: sans-serif;
            min-width: 400px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
        }

            .table thead tr {
                background-color: #009879;
                color: #ffffff;
                text-align: left;
            }

            .table th,
            .table td {
                padding: 12px 15px;
            }

            .table tbody tr {
                border-bottom: 1px solid #dddddd;
            }

                .table tbody tr:nth-of-type(even) {
                    background-color: #f3f3f3;
                }

                .table tbody tr:last-of-type {
                    border-bottom: 2px solid #009879;
                }

                .table tbody tr.active-row {
                    font-weight: bold;
                    color: chartreuse;
                }
    </style>
    <title>CRUD Opration Using ASP.Net</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h2>CRUD USING ASP.Net</h2>
        <asp:TextBox ID="txtCustomerNameSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="OnSearch" class="btn btn-secondary" />
        <div style="width: 60%">
            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" class="table table-bordered table-condensed table-responsive table-hover ">
                <Columns>
                    <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" />
                    <asp:BoundField DataField="CustomerId" HeaderText="ID" />
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
                    <asp:TemplateField HeaderText="Country">
                        <ItemTemplate>
                            <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("Country")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="OnEdit" class="btn btn-info"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClick="OnDelete" class="btn btn-dark"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <table class="table">
            <tr class="active-row">
                <td>
                    <asp:Label ID="lblCustomerName" runat="server" Text="CustomerName:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr class="active-row">
                <td>
                    <asp:Label ID="lblCustomerId" runat="server" Text="CustomerId:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerId" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr class="active-row">
                <td>
                    <asp:Label ID="ContactName" runat="server" Text="ContactName:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr class="active-row">
                <td>
                    <asp:Label ID="Country" runat="server" Text="Country:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="OnInsert" class="btn btn-primary" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="OnUpdate" class="btn btn-info" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="OnCancel" class="btn btn-danger" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
