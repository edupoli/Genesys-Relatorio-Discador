<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="relResultadoChamadas1.aspx.cs" Inherits="Genesys._1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin:auto 0px 0px auto; width:100%; height: 600px;">
        <br />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="600px">
            <LocalReport ReportPath="relResultadoChamadas1.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetGenesys" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSetAtendidas" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Genesys.genesysTableAdapters.AtendidaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="p_dataInicial" QueryStringField="dataInicial" Type="String" />
                <asp:QueryStringParameter Name="p_dataFinal" QueryStringField="dataFinal" Type="String" />
                <asp:QueryStringParameter Name="p_campanha" QueryStringField="campanha" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Genesys.gen_configDataSetTableAdapters.cfg_campaignTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_dbid" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="dbid" Type="Decimal" />
                <asp:Parameter Name="name" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="p_campanha" QueryStringField="campanha" Type="Decimal" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="Original_dbid" Type="Decimal" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
