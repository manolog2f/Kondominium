
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

function exportTableToExcel(tableID, filename = '') {
    var downloadLink;
    var dataType = 'application/vnd.ms-excel';
    var tableSelect = document.getElementById(tableID);
    var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

    // Specify file name
    filename = filename ? filename + '.xls' : 'excel_data.xls';

    // Create download link element
    downloadLink = document.createElement("a");

    document.body.appendChild(downloadLink);

    if (navigator.msSaveOrOpenBlob) {
        var blob = new Blob(['\ufeff', tableHTML], {
            type: dataType
        });
        navigator.msSaveOrOpenBlob(blob, filename);
    } else {
        // Create a link to the file
        downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

        // Setting the file name
        downloadLink.download = filename;

        //triggering the function
        downloadLink.click();
    }
}
