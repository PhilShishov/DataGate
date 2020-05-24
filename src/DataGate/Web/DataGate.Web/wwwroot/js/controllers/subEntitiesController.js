function loadAddInfo(token, url, json) {
    // ________________________________________________________
    //
    // Select menu for fund additional information -
    // subentities, timeline changes, all documents -
    // On change event for selected value

    $('#fundAdditionalInfSelect').on('change', function () {
        const dropdownvalue = $('#fundAdditionalInfSelect option:selected').val();

        $(this).find('[selected]').removeAttr('selected')
        $(this).find(':selected').attr('selected', 'selected')
        if (dropdownvalue == 'SubFunds') {
            $('#subEntities').css('visibility', 'visible');
            $('#timelineChanges').addClass('d-none');
            $('#allDocuments').addClass('d-none');
            $('#allAgreements').addClass('d-none');

            $.ajax({
                url: url,
                type: 'GET',
                data: json,
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadSubEntities').html(response);
                }
            });
        } else if (dropdownvalue == 'TimelineChanges') {
            $('#timelineChanges').removeClass('d-none');
            $('#subEntities').css('visibility', 'hidden');
            $('#allDocuments').addClass('d-none');
            $('#allAgreements').addClass('d-none');

            $.ajax({
                url: '/loadTimelines',
                type: 'GET',
                data: json,
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadTimelines').html(response);
                }
            });
        } else if (dropdownvalue == 'AllDocuments') {
            $('#allDocuments').removeClass('d-none');
            $('#timelineChanges').addClass('d-none');
            $('#subEntities').css('visibility', 'hidden');
            $('#allAgreements').addClass('d-none');

            $.ajax({
                url: '/loadAllDoc',
                type: 'GET',
                data: json,
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadAllDocuments').html(response);
                }
            });
        } else if (dropdownvalue == 'AllAgreements') {
            $('#allAgreements').removeClass('d-none');
            $('#timelineChanges').addClass('d-none');
            $('#subEntities').css('visibility', 'hidden');
            $('#allDocuments').addClass('d-none');

            $.ajax({
                url: '/loadAllAgr',
                type: 'GET',
                data: json,
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadAllAgreements').html(response);
                }
            });
        } else {
            $('#subEntities').css('visibility', 'hidden');
            $('#timelineChanges').addClass('d-none');
            $('#allDocuments').addClass('d-none');
            $('#allAgreements').addClass('d-none');
        }
    });
}
