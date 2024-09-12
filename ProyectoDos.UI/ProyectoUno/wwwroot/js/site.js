


function DeleteItem(btn) {

    var tabla = document.getElementById('tablaC');
    var fila = tabla.getElementsByTagName('tr');

    if (fila.length == 2) {

        alert("La factura debe tener productos o tours");
        return;

    }

    var btnE = btn.id.replaceAll('btnremoveC-', '');
    var btnInput = btnE + "__EsEliminado";
    var cambioEstado = document.querySelector("[id$='" + btnInput + "']").id;

    document.getElementById(cambioEstado).value = "true";


    $(btn).closest('tr').hide();
}


function AddCursos(btn) {

    var tabla = document.getElementById('tablaC');
    var fila = tabla.getElementsByTagName('tr');

    var codigoFila = fila[fila.length - 1].outerHTML;

    var ultimafila = fila.length - 2
    var proximafila = eval(ultimafila) + 1;


    codigoFila = codigoFila.replaceAll('_' + ultimafila + '_', '_' + proximafila + '_');
    codigoFila = codigoFila.replaceAll('[' + ultimafila + ']', '[' + proximafila + ']');
    codigoFila = codigoFila.replaceAll('-' + ultimafila, '-' + proximafila);

    var nuevaFila = tabla.insertRow();
    nuevaFila.innerHTML = codigoFila;

    var x = document.getElementsByTagName("INPUT");

    for (var n = 0; n < x.length; n++) {
        if (x[n].type == "text" && x[n].id.indexOf('_' + proximafila + '_') > 0) {
            x[n].value = '';
        } else if (x[n].type == "number" && x[n].id.indexOf('_' + proximafila + '_') > 0) {
            x[n].value = 0;
        }
    }
}
    function DeleteItem1(btn) {

        var tabla = document.getElementById('tablaD');
        var fila = tabla.getElementsByTagName('tr');

        if (fila.length == 2) {
            alert("La factura debe tener productos o tours");
            return;

        }

        var btnE = btn.id.replaceAll('btnremoveD-', '');
        var btnInput = btnE + "__EsEliminado";
        var cambioEstado = document.querySelector("[id$='" + btnInput + "']").id;

        document.getElementById(cambioEstado).value = "true";


        $(btn).closest('tr').hide();
    }


    function AddCursos1(btn) {

        var tabla = document.getElementById('tablaD');
        var fila = tabla.getElementsByTagName('tr');

        var codigoFila = fila[fila.length - 1].outerHTML;

        var ultimafila = fila.length - 2
        var proximafila = eval(ultimafila) + 1;


        codigoFila = codigoFila.replaceAll('_' + ultimafila + '_', '_' + proximafila + '_');
        codigoFila = codigoFila.replaceAll('[' + ultimafila + ']', '[' + proximafila + ']');
        codigoFila = codigoFila.replaceAll('-' + ultimafila, '-' + proximafila);

        var nuevaFila = tabla.insertRow();
        nuevaFila.innerHTML = codigoFila;

        var x = document.getElementsByTagName("INPUT");

        for (var n = 0; n < x.length; n++) {
            if (x[n].type == "text" && x[n].id.indexOf('_' + proximafila + '_') > 0) {
                x[n].value = '';
            } else if (x[n].type == "number" && x[n].id.indexOf('_' + proximafila + '_') > 0) {
                x[n].value = 0;
            }
        }



        //Adaptado del video de Salas Carcamo Bryan (15, agosto,2022).https://unedcr.sharepoint.com/sites/ApoyoWeb/Documentos%20compartidos/Forms/AllItems.aspx?FolderCTID=0x012000F8E7CCB1ABA87447B80F6DE1EAA87C94&id=%2Fsites%2FApoyoWeb%2FDocumentos%20compartidos%2FGeneral%2FClases%2F%231&viewid=a23ffd8e%2Db192%2D4330%2Dae38%2D88637667e8dc
}

