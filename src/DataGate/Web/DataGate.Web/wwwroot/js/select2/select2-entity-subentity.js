// ________________________________________________________
//
// Autocomplete search for particular entity subentities

function passUrlAndEntityToSelect(url, entityId) {
    $("#SelectTerm").select2({
        placeholder: "Quick Select",
        theme: "classic",
        ajax: {
            url: url,
            dataType: "json",
            delay: 250,
            data: function (params) {
                return {
                    selectTerm: params.term,
                    entityId: entityId
                };
            },
            processResults: function (data) {
                return {
                    results: data
                }
            }
        }
    });
}