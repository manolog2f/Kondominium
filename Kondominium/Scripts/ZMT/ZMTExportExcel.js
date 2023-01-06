
//$("#btnExport").click(function (e) {
//    $('.grid-wrap').find('table').removeAttr('class');
//    $('.grid-header').removeAttr('class');
//    $('.grid-row').removeAttr('class');

//    $('.grid-cell').removeAttr('data-name');
//    $('.grid-cell').removeAttr('class');


//    window.open('data:application/vnd.ms-excel,' + $('.grid-wrap').html());


//    //MakeAnyFunctionToReloadThePageToGetTheClassesAgain();
//    e.preventDefault();
//});

//function exportTableToExcel(tableID, filename = '') {
//    var downloadLink;
//    var dataType = 'application/vnd.ms-excel';
//    var tableSelect = document.getElementById(tableID);
//    var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

//    // Specify file name
//    filename = filename ? filename + '.xls' : 'excel_data.xls';

//    // Create download link element
//    downloadLink = document.createElement("a");

//    document.body.appendChild(downloadLink);

//    if (navigator.msSaveOrOpenBlob) {
//        var blob = new Blob(['\ufeff', tableHTML], {
//            type: dataType
//        });
//        navigator.msSaveOrOpenBlob(blob, filename);
//    } else {
//        // Create a link to the file
//        downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

//        // Setting the file name
//        downloadLink.download = filename;

//        //triggering the function
//        downloadLink.click();
//    }
//}



function fnExcelReport(tableID, filename = '') {
    var tab_text = "<table border='2px'><tr bgcolor='#87AFC6'>";
    var textRange; var j = 0;
    tab = document.getElementById(tableID); // id of table

    for (j = 0; j < tab.rows.length; j++) {
        tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
        //tab_text=tab_text+"</tr>";
    }

    tab_text = tab_text + "</table>";
    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
    tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
    {
        txtArea1.document.open("txt/html", "replace");
        txtArea1.document.write(tab_text);
        txtArea1.document.close();
        txtArea1.focus();
        sa = txtArea1.document.execCommand("SaveAs", true, "Say Thanks to Sumit.xls");
    }
    else                 //other browser not tested on IE 11
        sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));

    return (sa);
}

function exportTableToExcel(tableID, FileName = '') {
    var type, fn, dl;

    type = 'xlsx';

    if (FileName == '') { FileName = "KomdominoFile" }

    var elt = document.getElementById(tableID);
    var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });
    return dl ?
        XLSX.write(wb, { bookType: type, bookSST: true, type: 'base64' }) :
        XLSX.writeFile(wb, fn || (FileName +'.' + (type || 'xlsx')));
}