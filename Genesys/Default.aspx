<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Genesys._Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <br />
            <p class="text-center" style="font-size:30px">Relatorio de Tentativas de Discagens</p>
        <br />
    </div>
    <br />
    <br />
    <form>
        <div class="form-row col-md-12">
            <div class="form-group form-inline col-md-12">
                <asp:Label ID="Label1" runat="server" Text="&nbsp; Data Inicial &nbsp;"></asp:Label>
                <div class='input-group date' id='datetimepicker1'>
                    <asp:TextBox ID="TextInicial" runat="server" CssClass="form-control" ></asp:TextBox>
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                <asp:Label ID="Label2" runat="server" Text="Data Final &nbsp;"></asp:Label>
                <div class='input-group date' id='datetimepicker2'>
                    <asp:TextBox ID="TextFinal" runat="server" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                <asp:Label runat="server" for="ura" ID="lblCampanha">Campanha: &nbsp;</asp:Label>
                <asp:DropDownList ID="cboxCampanha" CssClass="form-control" runat="server" DataSourceID="SqlDataSourceCampanha" DataTextField="name" DataValueField="dbid"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceCampanha" runat="server" ConnectionString="<%$ ConnectionStrings:gen_configConnectionString %>" SelectCommand="SELECT [dbid], [name] FROM [cfg_campaign]"></asp:SqlDataSource>
                
            </div>
        </div>
        <br /><br /><br /><br />
        <h4>Tipo de Relatório</h4>
            <div class="form-check">
                <asp:RadioButton runat="server" class="form-check-input" type="radio" GroupName="rbTipoRel" ID="rbResultadoChama" value="opcao1" AutoPostBack="true" OnCheckedChanged="rbResultadoChama_CheckedChanged" />
                <asp:Label runat="server" class="form-check-label" for="rbChamaEntrada">
                    Por Resultado das Chamadas
                </asp:Label>
                <br />
                <asp:DropDownList runat="server" CssClass="form-control" ID="cboxCallResult">
                    <asp:ListItem>Selecione</asp:ListItem>
                    <asp:ListItem Value="TODAS">TODAS</asp:ListItem>
                    <asp:ListItem Value="6">OCUPADO</asp:ListItem>
                    <asp:ListItem Value="28">CAIXA POSTAL</asp:ListItem>
                    <asp:ListItem Value="9">SECRETARIA ELETRONICA</asp:ListItem>
                    <asp:ListItem Value="7">NÃO ATENDE</asp:ListItem>
                    <asp:ListItem Value="11">NUMERO INVALIDO</asp:ListItem>
                    <asp:ListItem Value="10">SEM TRONCO</asp:ListItem>
                    <asp:ListItem Value="35">SEM TOM DE LINHA</asp:ListItem>
                    <asp:ListItem Value="44">SEM CANAL DISPONIVEL</asp:ListItem>
                    <asp:ListItem Value="3">ERRO GERAL</asp:ListItem>
                    <asp:ListItem Value="21">ABANDONO</asp:ListItem>
                    <asp:ListItem Value="32">SILENCIO</asp:ListItem>
                </asp:DropDownList>
            </div>
        <br />
            <div class="form-check">
                <asp:RadioButton runat="server" class="form-check-input" type="radio" GroupName="rbTipoRel" ID="rbCPF" value="opcao2" AutoPostBack="true" OnCheckedChanged="rbCPF_CheckedChanged" />
                <asp:Label runat="server" class="form-check-label" for="rbCPF">
                    Por CPF ou CNPJ
                </asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TextCpfCnpj"/>
            </div>
        <br />
            <div class="form-check">
                <asp:RadioButton runat="server" class="form-check-input" type="radio" GroupName="rbTipoRel" ID="rbTelefone" value="option3" AutoPostBack="true" OnCheckedChanged="rbTelefone_CheckedChanged"/>
                <asp:Label runat="server" class="form-check-label" for="rbTelefone">
                    Por Numero de Telefone
                </asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TextTelefone"/>
            </div>

            <br /> <br />
        <asp:Button Text="Gerar Relatório" runat="server" ID="btnGerarRelatorio" type="button" CssClass="btn btn-primary" OnClick="btnGerarRelatorio_Click"  />
    </form>
    <div class="container" style="margin:auto 0px 0px auto; width:82%; height: 399px;align-content:center">
        
        
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.1/moment.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/js/bootstrap-datetimepicker.min.js"></script>
    <script src="pt-br.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/css/bootstrap-datetimepicker.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />

    <style>
        h3 {
            text-align:center;
        }
    </style>
   <script>
        $(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'YYYY/MM/DD 00:00:00',
                locale: 'pt-br',
                showClear: true,
                showClose: true
            });
            $('#datetimepicker2').datetimepicker({
                format: 'YYYY/MM/DD 23:59:59',
                locale: 'pt-br',
                showClear: true,
                showClose: true
            });
        });
    </script>
    <script>
        function datainicio() {
            swal({
                type: 'error',
                title: 'Oops...',
                text: 'Informe uma data inicial para o relatório!'
            });
        };
     </script>
     <script>   
        function datafim() {
            swal({
                type: 'error',
                title: 'Oops...',
                text: 'Informe uma data fim para o relatório!'
            });
        };
      </script>
    <script>
       function sel_capanha() {
           swal({
               type: 'error',
               title: 'Oops...',
               text: 'Selecione a URA!'
           });
        };
    </script>
    <script>
       function erroSemEscolha() {
           swal({
               type: 'error',
               title: 'Oops...',
               text: 'Selecione um tipo de Relatório!'
           });
        };
    </script>


    
    <div>
        <asp:Chart ID="ChartGraficos" Width="1200px" Height="500px" runat="server" />
        
    </div>
    
    
    <style>
        .jumbotron{
    position: relative;
    padding:0 !important;
    margin-top:40px !important;
    background: #eee;
    margin-top: 28px;
    text-align:center;
    margin-bottom: 0 !important;
}
        

    </style>
 


</asp:Content>
