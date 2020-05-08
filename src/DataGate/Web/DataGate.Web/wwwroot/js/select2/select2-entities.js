// ________________________________________________________
//
// Autocomplete search entities

function passControllerToSelect(controllerToPass) {
    var token = $("#update-form input[name=__RequestVerificationToken]").val();
    $("#SelectTerm").select2({
        placeholder: "Quick Select",
        theme: "classic",
        ajax: {
            url: '/api/autocomplete',
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            headers: { 'X-CSRF-TOKEN': token },
            delay: 250,
            data: function (params) {
                return {
                    selectTerm: params.term,
                    controllerToPass: controllerToPass,
                };
            },
            processResults: function (data) {
                return { results: data }
            }
        }
    });
}