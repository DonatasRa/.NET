$(document).ready(function (){

    $('select').prop("disabled", true);
    $('#btnSave').prop("disabled", true);
    $('#btnCancel').prop("disabled", true);
});

$('#btnEdit').click(function () {

    $('select').prop("disabled", false);
    $('#btnSave').prop("disabled", false);
    $('#btnCancel').prop("disabled", false);
    $('#btnEdit').prop("disabled", true);
});