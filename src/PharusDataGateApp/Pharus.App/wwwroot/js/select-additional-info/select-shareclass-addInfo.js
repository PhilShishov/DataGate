// ________________________________________________________
//
// Select menu for fund additional information -
// subentities, timeline changes, all documents
// Get selected value and keep select option open

$('#shareClassAdditionalInfSelect option').each(function () {
    if (this.selected) {
        const dropdownvalue = $("#shareClassAdditionalInfSelect option:selected").val();
        if (dropdownvalue == 'TimelineChanges') {
            $("#timelineChanges").removeClass('d-none');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'AllDocuments') {
            $("#allDocuments").removeClass('d-none');
            $("#timelineChanges").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'AllAgreements') {
            $("#allAgreements").removeClass('d-none');
            $("#timelineChanges").addClass('d-none');
            $("#allDocuments").addClass('d-none');
        } else {
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

$("#shareClassAdditionalInfSelect").on('change', function () {
    const dropdownvalue = $("#shareClassAdditionalInfSelect option:selected").val();
    if (dropdownvalue == 'TimelineChanges') {
        $("#timelineChanges").removeClass('d-none');
        $("#allDocuments").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    } else if (dropdownvalue == 'AllDocuments') {
        $("#allDocuments").removeClass('d-none');
        $("#timelineChanges").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    } else if (dropdownvalue == 'AllAgreements') {
        $("#allAgreements").removeClass('d-none');
        $("#timelineChanges").addClass('d-none');
        $("#allDocuments").addClass('d-none')
    } else {
        $("#timelineChanges").addClass('d-none');
        $("#allDocuments").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    }
});