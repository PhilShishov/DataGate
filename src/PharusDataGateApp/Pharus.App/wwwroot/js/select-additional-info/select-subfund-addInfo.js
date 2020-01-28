// ________________________________________________________
//
// Select menu for fund additional information -
// subentities, timeline changes, all documents
// Get selected value and keep select option open

$('#subFundAdditionalInfSelect option').each(function () {
    if (this.selected) {
        const dropdownvalue = $("#subFundAdditionalInfSelect option:selected").val();
        if (dropdownvalue == 'ShareClasses') {
            $("#subEntities").css('visibility', 'visible');
            $("#timelineChanges").css('visibility', 'hidden');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'TimelineChanges') {
            $("#timelineChanges").css('visibility', 'visible');
            $("#subEntities").css('visibility', 'hidden');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'AllDocuments') {
            $("#allDocuments").removeClass('d-none');
            $("#timelineChanges").css('visibility', 'hidden');
            $("#subEntities").css('visibility', 'hidden');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'AllAgreements') {
            $("#allAgreements").removeClass('d-none');
            $("#timelineChanges").css('visibility', 'hidden');
            $("#subEntities").css('visibility', 'hidden');
            $("#allDocuments").addClass('d-none');
        } else {
            $("#subEntities").css('visibility', 'hidden');
            $("#timelineChanges").css('visibility', 'hidden');
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

$("#subFundAdditionalInfSelect").on('change', function () {
    const dropdownvalue = $("#subFundAdditionalInfSelect option:selected").val();
    if (dropdownvalue == 'ShareClasses') {
        $("#subEntities").css('visibility', 'visible');
        $("#timelineChanges").css('visibility', 'hidden');
        $("#allDocuments").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    } else if (dropdownvalue == 'TimelineChanges') {
        $("#timelineChanges").css('visibility', 'visible');
        $("#subEntities").css('visibility', 'hidden');
        $("#allDocuments").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    } else if (dropdownvalue == 'AllDocuments') {
        $("#allDocuments").removeClass('d-none');
        $("#timelineChanges").css('visibility', 'hidden');
        $("#subEntities").css('visibility', 'hidden');
        $("#allAgreements").addClass('d-none');
    } else if (dropdownvalue == 'AllAgreements') {
        $("#allAgreements").removeClass('d-none');
        $("#timelineChanges").css('visibility', 'hidden');
        $("#subEntities").css('visibility', 'hidden');
        $("#allDocuments").addClass('d-none');
    } else {
        $("#subEntities").css('visibility', 'hidden');
        $("#timelineChanges").css('visibility', 'hidden');
        $("#allDocuments").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    }
});