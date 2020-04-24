// ________________________________________________________
//
// Autocomplete search entities

function passUrlToSelect(url) {
    $("#SelectTerm").select2({
        placeholder: "Quick Select",
        theme: "classic",
        ajax: {
            url: url,
            dataType: "json",
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