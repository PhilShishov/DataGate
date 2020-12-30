const HTML = {
    FORM_EXTRACT: '#extract-form',
    BTN_EXTRACT_EXCEL: '#btn-extract-excel',
    BTN_EXTRACT_PDF: '#btn-extract-pdf',
    BTN_SAVE_LAYOUT: '#btn-save-layout',
    BTN_DEFAULT_LAYOUT: '#btn-default-layout',
    LI_SELECTED_COLUMNS: 'ui-element',
    FORM_UPDATE: 'update-form',
    CHECKBOX_ACTIVE: 'activeCheckBox',
    TABLE_EXTRACT: 'table-to-extract',
    TBODY_UPDATE_INACTIVE: 'tbody-update-inactive',
};

const SELECTORS = {
    INPUT_TOKEN_EXTRACT: `${HTML.FORM_EXTRACT} input[name=__RequestVerificationToken]`,
};

const CLASSES = {
    INACTIVE: 'inactive-entity'
};

function saveLayout(model) {
    const form = document.getElementById(HTML.FORM_UPDATE);
    const token = $('input[name=__RequestVerificationToken]', form).val();

    $(document).on('click', HTML.BTN_SAVE_LAYOUT, function (event) {
        event.preventDefault();
        const selectedColumns = document.getElementById('container-selected').getElementsByClassName(HTML.LI_SELECTED_COLUMNS);
        let columns = [];

        for (let row of selectedColumns) {
            columns.push(row.innerText.trim());
        }

        model.SelectedColumns = columns;
        $.ajax({
            url: '/Layout/Save',
            type: 'POST',
            data: model,
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            if (data.success) {
                const url = '/Layout/OnSaveLayoutSuccess?controllerOrigin=' + data.controller + '&areaOrigin=' + data.area;
                window.location = url;
                return;
            }
        }).fail(function (request, status, error) {
            swal(request.responseText, {
                icon: "error"
            });
        });
    });
}

// ________________________________________________________
//
// Extract view as excel or pdf
function extract(model) {
    const excelValue = $(HTML.BTN_EXTRACT_EXCEL).attr('value');
    const pdfValue = $(HTML.BTN_EXTRACT_PDF).attr('value');
    const token = $(SELECTORS.INPUT_TOKEN_EXTRACT).val();
    const table = document.getElementById(HTML.TABLE_EXTRACT);

    $(document).on('click', HTML.BTN_EXTRACT_EXCEL, function (event) {
        event.preventDefault();
        let tableValues = [];

        for (let row of table.rows) {
            let tableRows = [];
            for (let cell of row.cells) {
                tableRows.push(cell.innerText);
            }
            tableValues.push(tableRows);
        }
        model.TableValues = tableValues;
        model.Command = excelValue;

        extractRequestHandler(model, token);
    });

    $(document).on('click', HTML.BTN_EXTRACT_PDF, function (event) {
        event.preventDefault();
        let tableValues = [];

        for (let row of table.rows) {
            let tableRows = [];
            for (let cell of row.cells) {
                tableRows.push(cell.innerText);
            }
            tableValues.push(tableRows);
        }
        model.TableValues = tableValues;
        model.Command = pdfValue;

        extractRequestHandler(model, token);
    });

    function extractRequestHandler(model, token) {
        $.blockUI({
            message: $('#blockui-panel'),
            css: {
                border: 'none',
                padding: '15px',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
            },
        });
        $.ajax({
            url: '/Media/GenerateReport',
            type: 'POST',
            data: model,
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            if (!data.success) {
                $.unblockUI();
                swal(data.errorMessage, {
                    icon: "error"
                })
                return;
            }
            setTimeout($.unblockUI, 1000);
            if (data.fileName != '') {
                const url = '/Media/Download?fileName=' + data.fileName;
                window.location = url;
            }
        }).fail(function (request, status, error) {
            $.unblockUI();
            swal(request.responseText, {
                icon: "error"
            });
        });
    }
}

// ________________________________________________________
//
// Submit form on checkbox change - show active and inactive entities
function submitForm() {
    const updateForm = document.getElementById(HTML.FORM_UPDATE);
    const checkbox = document.getElementById(HTML.CHECKBOX_ACTIVE);

    if (checkbox) {
        checkbox.addEventListener('change', submitFormOnChange);

        function submitFormOnChange() {
            updateForm.submit();
        }
    }
};

// ________________________________________________________
//
// Datatables - sort, search, pagination
function dataTableInitializationHandler(controller, language) {
    $('.table-view-datagate').removeAttr('hidden');
    $.fn.dataTable.moment('DD/MM/YYYY');

    if (controller === 'Funds') {
        $('.table-view-datagate').DataTable({
            "dom": '<"top">rt<"bottom"><"clear">',
            "pageLength": 50,
            "autoWidth": false,
            "scrollX": true,
            "columnDefs": [
                { type: 'natural', targets: 0 }
            ]
        });
    } else {
        let cultureObj = {};
        let lengthMenuArr = [[-1, 10, 25, 50], ["All", 10, 25, 50]];

        if (language === 'it-IT') {
            cultureObj = {
                "sEmptyTable": "Nessun dato presente nella tabella",
                "sInfo": "Vista da _START_ a _END_ di _TOTAL_ elementi",
                "sInfoEmpty": "Vista da 0 a 0 di 0 elementi",
                "sInfoFiltered": "(filtrati da _MAX_ elementi totali)",
                "sInfoPostFix": "",
                "sInfoThousands": ",",
                "sLengthMenu": "Visualizza _MENU_ elementi",
                "sLoadingRecords": "Caricamento...",
                "sProcessing": "Elaborazione...",
                "sSearch": "Cerca:",
                "sZeroRecords": "La ricerca non ha portato alcun risultato.",
                "oPaginate": {
                    "sFirst": "Inizio",
                    "sPrevious": "Precedente",
                    "sNext": "Successivo",
                    "sLast": "Fine"
                },
                "oAria": {
                    "sSortAscending": ": attiva per ordinare la colonna in ordine crescente",
                    "sSortDescending": ": attiva per ordinare la colonna in ordine decrescente"
                }
            };

            lengthMenuArr = [[-1, 10, 25, 50], ["Tutti", 10, 25, 50]];

        }

        $('.table-view-datagate').DataTable({
            "dom": '<"top"lf>rt<"bottom"ip><"clear">',
            "lengthMenu": lengthMenuArr,
            stateSave: true,
            "autoWidth": false,
            "scrollX": true,
            "language": cultureObj,
            "columnDefs": [
                { type: 'natural', targets: 0 }
            ]
        });
    }

    $(".dataTables_length select").chosen({
        disable_search_threshold: 10,

        width: "68px",
        placeholder_text_single: ""
    });

    setTimeout($.unblockUI, 500);
}

// ________________________________________________________
//
// Add inactive class to entities that have inactive status
(function () {
    const tbody = document.getElementById(HTML.TBODY_UPDATE_INACTIVE);

    if (tbody) {
        const rows = tbody.getElementsByTagName('tr');

        for (var row of rows) {
            const cells = row.getElementsByTagName('td');
            for (var cell of cells) {
                if (cell.textContent.includes('Inactive')) {
                    row.classList.add(CLASSES.INACTIVE);
                }
            }
        }
    }
})();

/*** Handle jQuery plugin naming conflict between jQuery UI and Bootstrap ***/

$.widget.bridge('uitooltip', $.ui.tooltip);

$(function () {
    // ________________________________________________________
    //
    // Additional information about headers
    $('[data-toggle="tooltip"]').uitooltip({
        position: { my: "center bottom", at: "center top" },
        html: true
    })

    // ________________________________________________________
    //
    // Modal multiselect for column selection
    $('.multiselect').multiselect();
});

// ________________________________________________________
//
// Multiselect plugin
(function ($) {

    $.widget("ui.multiselect", {
        options: {
            searchable: true,
            doubleClickable: true,
            animated: 'fast',
            show: 'slideDown',
            hide: 'slideUp',
            dividerLocation: 0.6,
            availableFirst: false,
            nodeComparator: function (node1, node2) {
                var text1 = node1.text(),
                    text2 = node2.text();
                return text1 == text2 ? 0 : (text1 < text2 ? -1 : 1);
            }
        },
        _create: function () {
            this.element.hide();
            this.id = this.element.attr("id");
            this.container = $('<div class="ui-multiselect"></div>').insertAfter(this.element);
            this.count = 0; // number of currently selected options
            this.selectedContainer = $('<div class="selected" id="container-selected"></div>').appendTo(this.container);
            this.availableContainer = $('<div class="available" id="container-available"></div>')[this.options.availableFirst ? 'prependTo' : 'appendTo'](this.container);
            this.selectedActions = $('<div class="actions ui-widget-header ui-helper-clearfix"><span class="count">0 ' + $.ui.multiselect.locale.itemsCount + '</span><a href="#" class="remove-all">' + $.ui.multiselect.locale.removeAll + '</a></div>').appendTo(this.selectedContainer);
            this.availableActions = $('<div class="actions ui-widget-header ui-helper-clearfix"><input type="text" class="search empty ui-widget-content ui-corner-all"/><a href="#" class="add-all">' + $.ui.multiselect.locale.addAll + '</a></div>').appendTo(this.availableContainer);
            this.selectedList = $('<ul class="selected connected-list"><li class="ui-helper-hidden-accessible"></li></ul>').bind('selectstart', function () { return false; }).appendTo(this.selectedContainer);
            this.availableList = $('<ul class="available connected-list"><li class="ui-helper-hidden-accessible"></li></ul>').bind('selectstart', function () { return false; }).appendTo(this.availableContainer);

            var that = this;

            //// set dimensions
            //this.container.width('60%');
            //this.selectedContainer.width('49%');
            //this.availableContainer.width('49%');

            // fix list height to match <option> depending on their individual header's heights
            //this.selectedList.height('50%');
            //      this.availableList.height('50%');

            if (!this.options.animated) {
                this.options.show = 'show';
                this.options.hide = 'hide';
            }

            // init lists
            this._populateLists(this.element.find('option'));

            // make selection sortable
            if (this.options.sortable) {
                this.selectedList.sortable({
                    placeholder: 'ui-state-highlight',
                    axis: 'y',
                    update: function (event, ui) {
                        // apply the new sort order to the original selectbox
                        that.selectedList.find('li').each(function () {
                            if ($(this).data('optionLink'))
                                $(this).data('optionLink').remove().appendTo(that.element);
                        });
                    },
                    receive: function (event, ui) {
                        ui.item.data('optionLink').attr('selected', true);
                        // increment count
                        that.count += 1;
                        that._updateCount();
                        // workaround, because there's no way to reference 
                        // the new element, see http://dev.jqueryui.com/ticket/4303
                        that.selectedList.children('.ui-draggable').each(function () {
                            $(this).removeClass('ui-draggable');
                            $(this).data('optionLink', ui.item.data('optionLink'));
                            $(this).data('idx', ui.item.data('idx'));
                            that._applyItemState($(this), true);
                        });

                        // workaround according to http://dev.jqueryui.com/ticket/4088
                        setTimeout(function () { ui.item.remove(); }, 1);
                    }
                });
            }

            // set up livesearch
            if (this.options.searchable) {
                this._registerSearchEvents(this.availableContainer.find('input.search'));
            } else {
                $('.search').hide();
            }

            // batch actions
            this.container.find(".remove-all").click(function () {
                that._populateLists(that.element.find('option').removeAttr('selected'));
                return false;
            });

            this.container.find(".add-all").click(function () {
                var options = that.element.find('option').not(":selected");
                if (that.availableList.children('li:hidden').length > 1) {
                    that.availableList.children('li').each(function (i) {
                        if ($(this).is(":visible")) $(options[i - 1]).attr('selected', 'selected');
                    });
                } else {
                    options.attr('selected', 'selected');
                }
                that._populateLists(that.element.find('option'));
                return false;
            });
        },
        destroy: function () {
            this.element.show();
            this.container.remove();

            $.Widget.prototype.destroy.apply(this, arguments);
        },
        _populateLists: function (options) {
            this.selectedList.children('.ui-element').remove();
            this.availableList.children('.ui-element').remove();
            this.count = 0;

            var that = this;
            var items = $(options.map(function (i) {
                var item = that._getOptionNode(this).appendTo(this.selected ? that.selectedList : that.availableList).show();

                if (this.selected) that.count += 1;
                that._applyItemState(item, this.selected);
                item.data('idx', i);
                return item[0];
            }));

            // update count
            this._updateCount();
            that._filter.apply(this.availableContainer.find('input.search'), [that.availableList]);
        },
        _updateCount: function () {
            this.element.trigger('change');
            this.selectedContainer.find('span.count').text(this.count + " " + $.ui.multiselect.locale.itemsCount);
        },
        _getOptionNode: function (option) {
            option = $(option);
            var node = $('<li class="ui-state-default ui-element" title="' + option.text() + '" data-selected-value="' + option.val() + '"><span class="ui-icon"/>' + option.text() + '<a href="#" class="action"><span class="ui-corner-all ui-icon"/></a></li>').hide();
            node.data('optionLink', option);
            return node;
        },
        // clones an item with associated data
        // didn't find a smarter away around this
        _cloneWithData: function (clonee) {
            var clone = clonee.clone(false, false);
            clone.data('optionLink', clonee.data('optionLink'));
            clone.data('idx', clonee.data('idx'));
            return clone;
        },
        _setSelected: function (item, selected) {
            item.data('optionLink').attr('selected', selected);

            if (selected) {
                var selectedItem = this._cloneWithData(item);
                item[this.options.hide](this.options.animated, function () { $(this).remove(); });
                selectedItem.appendTo(this.selectedList).hide()[this.options.show](this.options.animated);

                this._applyItemState(selectedItem, true);
                return selectedItem;
            } else {

                // look for successor based on initial option index
                var items = this.availableList.find('li'), comparator = this.options.nodeComparator;
                var succ = null, i = item.data('idx'), direction = comparator(item, $(items[i]));

                if (direction) {
                    while (i >= 0 && i < items.length) {
                        direction > 0 ? i++ : i--;
                        if (direction != comparator(item, $(items[i]))) {
                            // going up, go back one item down, otherwise leave as is
                            succ = items[direction > 0 ? i : i + 1];
                            break;
                        }
                    }
                } else {
                    succ = items[i];
                }

                var availableItem = this._cloneWithData(item);
                succ ? availableItem.insertBefore($(succ)) : availableItem.appendTo(this.availableList);
                item[this.options.hide](this.options.animated, function () { $(this).remove(); });
                availableItem.hide()[this.options.show](this.options.animated);

                this._applyItemState(availableItem, false);
                return availableItem;
            }
        },
        _applyItemState: function (item, selected) {
            if (selected) {
                if (this.options.sortable)
                    item.children('span').addClass('ui-icon-arrowthick-2-n-s').removeClass('ui-helper-hidden').addClass('ui-icon');
                else
                    item.children('span').removeClass('ui-icon-arrowthick-2-n-s').addClass('ui-helper-hidden').removeClass('ui-icon');
                item.find('a.action span').addClass('ui-icon-minus').removeClass('ui-icon-plus');
                this._registerRemoveEvents(item.find('a.action'));

            } else {
                item.children('span').removeClass('ui-icon-arrowthick-2-n-s').addClass('ui-helper-hidden').removeClass('ui-icon');
                item.find('a.action span').addClass('ui-icon-plus').removeClass('ui-icon-minus');
                this._registerAddEvents(item.find('a.action'));
            }

            this._registerDoubleClickEvents(item);
            this._registerHoverEvents(item);
        },

        _filter: function (list) {
            var input = $(this);
            var rows = list.children('li'),
                cache = rows.map(function () {

                    return $(this).text().toLowerCase();
                });

            var term = $.trim(input.val().toLowerCase()), scores = [];

            if (!term) {
                rows.show();
            } else {
                rows.hide();

                cache.each(function (i) {
                    if (this.indexOf(term) > -1) { scores.push(i); }
                });

                $.each(scores, function () {
                    $(rows[this]).show();
                });
            }
        },
        _registerDoubleClickEvents: function (elements) {
            if (!this.options.doubleClickable) return;
            elements.dblclick(function (ev) {
                if ($(ev.target).closest('.action').length === 0) {
                    // This may be triggered with rapid clicks on actions as well. In that
                    // case don't trigger an additional click.
                    elements.find('a.action').click();
                }
            });
        },
        _registerHoverEvents: function (elements) {
            elements.removeClass('ui-state-hover');
            elements.mouseover(function () {
                $(this).addClass('ui-state-hover');
            });
            elements.mouseout(function () {
                $(this).removeClass('ui-state-hover');
            });
        },
        _registerAddEvents: function (elements) {
            var that = this;
            elements.click(function () {
                var item = that._setSelected($(this).parent(), true);
                that.count += 1;
                that._updateCount();
                return false;
            });

            // make draggable
            if (this.options.sortable) {
                elements.each(function () {
                    $(this).parent().draggable({
                        connectToSortable: that.selectedList,
                        helper: function () {
                            var selectedItem = that._cloneWithData($(this)).width($(this).width() - 50);
                            selectedItem.width($(this).width());
                            return selectedItem;
                        },
                        appendTo: that.container,
                        containment: that.container,
                        revert: 'invalid'
                    });
                });
            }
        },
        _registerRemoveEvents: function (elements) {
            var that = this;
            elements.click(function () {
                that._setSelected($(this).parent(), false);
                that.count -= 1;
                that._updateCount();
                return false;
            });
        },
        _registerSearchEvents: function (input) {
            var that = this;

            input.focus(function () {
                $(this).addClass('ui-state-active');
            })
                .blur(function () {
                    $(this).removeClass('ui-state-active');
                })
                .keypress(function (e) {
                    if (e.keyCode == 13)
                        return false;
                })
                .keyup(function () {
                    that._filter.apply(this, [that.availableList]);
                });
        }
    });

    $.extend($.ui.multiselect, {
        locale: {
            addAll: 'Add all',
            removeAll: 'Remove all',
            itemsCount: 'items selected'
        }
    });
})(jQuery);
