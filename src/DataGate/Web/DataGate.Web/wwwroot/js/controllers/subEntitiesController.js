function loadAddInfo(token, id, date, controllerName) {
    // ________________________________________________________
    //
    // Select menu for fund additional information -
    // subentities, timeline changes, all documents
    // Get selected value and keep select option open

    $('#fundAdditionalInfSelect option').each(function () {
        if (this.selected) {
            const dropdownvalue = $("#fundAdditionalInfSelect option:selected").val();
            if (dropdownvalue == 'SubFunds') {
                $("#subEntities").css('visibility', 'visible');
                $("#timelineChanges").addClass('d-none');
                $("#allDocuments").addClass('d-none');
                $("#allAgreements").addClass('d-none');
            } else if (dropdownvalue == 'TimelineChanges') {
                $("#timelineChanges").removeClass('d-none');
                $("#subEntities").css('visibility', 'hidden');
                $("#allDocuments").addClass('d-none');
                $("#allAgreements").addClass('d-none');
            } else if (dropdownvalue == 'AllDocuments') {
                $("#allDocuments").removeClass('d-none');
                $("#timelineChanges").addClass('d-none');
                $("#subEntities").css('visibility', 'hidden');
                $("#allAgreements").addClass('d-none');
            } else if (dropdownvalue == 'AllAgreements') {
                $("#allAgreements").removeClass('d-none');
                $("#timelineChanges").addClass('d-none');
                $("#subEntities").css('visibility', 'hidden');
                $("#allDocuments").addClass('d-none');
            } else {
                $("#subEntities").css('visibility', 'hidden');
                $("#timelineChanges").addClass('d-none');
                $("#allDocuments").addClass('d-none');
                $("#allAgreements").addClass('d-none');
            }
        }
    });

    // ________________________________________________________
    //
    // Select menu for fund additional information -
    // subentities, timeline changes, all documents -
    // On change event for selected value

    $("#fundAdditionalInfSelect").on('change', function () {
        const dropdownvalue = $("#fundAdditionalInfSelect option:selected").val();
        $(this).find('[selected]').removeAttr('selected')
        $(this).find(':selected').attr('selected', 'selected')
        if (dropdownvalue == 'SubFunds') {
            $("#subEntities").css('visibility', 'visible');
            $("#timelineChanges").addClass('d-none');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'TimelineChanges') {
            $("#timelineChanges").removeClass('d-none');
            $("#subEntities").css('visibility', 'hidden');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'AllDocuments') {
            $("#allDocuments").removeClass('d-none');
            $("#timelineChanges").addClass('d-none');
            $("#subEntities").css('visibility', 'hidden');
            $("#allAgreements").addClass('d-none');

            $.ajax({
                type: "GET",
                url: '/loadAllDoc',
                contentType: "application/json; charset=utf-8",
                //headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadAllDocuments').html(response);
                }
            });
        } else if (dropdownvalue == 'AllAgreements') {
            $("#allAgreements").removeClass('d-none');
            $("#timelineChanges").addClass('d-none');
            $("#subEntities").css('visibility', 'hidden');
            $("#allDocuments").addClass('d-none');
        } else {
            $("#subEntities").css('visibility', 'hidden');
            $("#timelineChanges").addClass('d-none');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        }
    });
}
