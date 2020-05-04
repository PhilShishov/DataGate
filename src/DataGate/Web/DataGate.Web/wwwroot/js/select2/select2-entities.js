// ________________________________________________________
//
// Autocomplete search entities

function passUrlToSelect(url) {
    var token = $("#update-form input[name=__RequestVerificationToken]").val();
    $("#SelectTerm").select2({
        placeholder: "Quick Select",
        theme: "classic",
        ajax: {
            url: url,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            headers: { 'X-CSRF-TOKEN': token },
            delay: 250,
            data: function (params) {
                return { selectTerm: params.term };
            },
            processResults: function (data) {
                return { results: data }
            }
        }
    });
}