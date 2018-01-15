<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCargaRapidaActualizar.aspx.cs" Inherits="EToolWeb.FrmCargaRapidaActualizar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Style.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <script>
        function ActualizoExito() {
            alert("El registro se Actualizo con exito");
            opener.location.reload();
            window.close();
        }
        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h4>Codigo: <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label></h4>
        <div class="form-group">
            <label for="ddlEmpleado">Empleado</label>

            <asp:DropDownList ID="ddlEmpleado" runat="server" class="form-control"></asp:DropDownList>

        </div>
        <div class="form-group">
            <label for="ddlEntrenamiento">Entrenamiento</label>

            <asp:DropDownList ID="ddlEntrenamiento" runat="server" class="form-control"></asp:DropDownList>

        </div>
        <div class='col-sm-4'>
            <div class="form-group">
                <div class='input-group date' id='datetimepicker6'>
                    <asp:TextBox ID="txtFecha" runat="server" class="form-control"></asp:TextBox>
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
        </div>
        <div class='col-sm-4'>
            <label for="txtNota">Nota</label>
            <asp:TextBox ID="txtNota" runat="server" Text="20" class="form-control bfh-number" onKeyPress="return soloNumeros(event)"></asp:TextBox>
        </div>
        <div class="form-check">
            <asp:CheckBox ID="chbCertificado" runat="server" class="form-check-input" />
            <label class="form-check-label" for="chbCertificado">Certificado</label>
        </div>
        <div class="form-group">
            <label for="fupExamen">Seleccione Examen</label>
            <asp:FileUpload ID="fupExamen" runat="server" class="btn btn-primary" aria-describedby="fileHelp" />
            <asp:Literal ID="ltlArchivo" runat="server"></asp:Literal>
            <asp:Label ID="lblExamen" runat="server"></asp:Label>
        </div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
        <input type=button value="Cancelar" onclick="javascript:window.close();" class="btn btn-primary">
    </form>
    <script type="text/javascript" src="jquery/jquery-1.8.3.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/bootstrap-datetimepicker.js" charset="UTF-8"></script>
    <script type="text/javascript" src="js/locales/bootstrap-datetimepicker.es.js" charset="UTF-8"></script>
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker6').datetimepicker({
                language: 'es',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                minView: 2,
                forceParse: 0,
                format: 'dd/mm/yyyy'
            });
            $('#datetimepicker7').datetimepicker({
                language: 'es',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                minView: 2,
                forceParse: 0,
                format: 'dd/mm/yyyy'
            });
            $("#datetimepicker6").on("dp.change", function (e) {
                $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
            });
            $("#datetimepicker7").on("dp.change", function (e) {
                $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
            });
        });
    </script>
</body>
</html>
