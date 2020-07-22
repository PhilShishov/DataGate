const HTML = {
    FORM_EXTRACT: '#extract-form',
    BTN_EXTRACT_EXCEL: '#btn-extract-excel',
    BTN_EXTRACT_PDF: '#btn-extract-pdf',
    FORM_UPDATE: 'update-form',
    CHECKBOX_ACTIVE: 'activeCheckBox',
    TABLE_EXTRACT: 'table-to-extract',
    TBODY_UPDATE_INACTIVE: 'tbody-update-inactive',
    BTN_RESET: 'btn-reset',
};

const SELECTORS = {
    INPUT_TOKEN_EXTRACT: `${HTML.FORM_EXTRACT} input[name=__RequestVerificationToken]`
};

const CLASSES = {
    INACTIVE: 'inactive-entity'
};

const MESSAGES = {
    BLOCKUI_USER_MESSAGE: 'Please wait a moment...'
};

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
        $.blockUI({ message: `<h3>${MESSAGES.BLOCKUI_USER_MESSAGE}</h3>` });
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

function reload() {
    const resetBtns = document.getElementsByClassName(HTML.BTN_RESET);

    if (resetBtns) {
        for (let btn of resetBtns) {
            btn.addEventListener('click', () => {
                document.location.reload(true);
            });
        }
    }
};

// ________________________________________________________
//
// Datatables - sort, search, pagination
function dataTableInitializationHandler(controller) {
    $('.table-view-pharus').removeAttr('hidden');
    $.fn.dataTable.moment('DD/MM/YYYY');

    if (controller === 'Funds') {
        $('.table-view-pharus').DataTable({
            "dom": '<"top">rt<"bottom"><"clear">',
            stateSave: true,
            "autoWidth": false,
            "scrollX": true,
        });
    } else {
        $('.table-view-pharus').DataTable({
            "dom": '<"top"lf>rt<"bottom"ip><"clear">',
            "lengthMenu": [[-1, 10, 25, 50], ["All", 10, 25, 50]],
            stateSave: true,
            "autoWidth": false,
            "scrollX": true,
        });
    }

    $(".dataTables_length select").chosen({
        disable_search_threshold: 10,
        width: "55px",
        placeholder_text_single: ""
    });
}

// ________________________________________________________
//
// Datatables for reports - sort, search, pagination and total result
function dataTableReportHandler(type) {
    $.fn.dataTable.moment('DD/MM/YYYY');

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'EUR',
    });

    // Remove the formatting to get aum data for total
    let aumValue = function (input) {
        return typeof input === 'string' && input != 'Not available' ?
            input.replace(/[\€,]/g, '') * 1 :
            typeof input === 'number' ?
                input : 0;
    };

    jQuery.extend(jQuery.fn.dataTableExt.oSort, {
        "formatted-num-pre": function (a) {
            a = (a === "-" || a === "") ? 0 : a.replace(/[^\d\-\.]/g, "");
            return parseFloat(a);
        },
        "formatted-num-asc": function (a, b) {
            return a - b;
        },
        "formatted-num-desc": function (a, b) {
            return b - a;
        }
    });

    if (type === 'Fund') {
        $('.table-view-pharus').DataTable({
            "dom": '<"top">t<"bottom"><"clear">',
            columnDefs: [
                { type: 'formatted-num', targets: "_all" }
            ],
            "pageLength": 50,
            "scrollX": true,
            stateSave: true,
            "footerCallback": function (row, data, start, end, display) {
                var api = this.api(), data;

                const colCount = $(this).find("tr:first td").length;

                for (let i = 1; i < colCount; i++) {
                    total = api
                        .column(i)
                        .data()
                        .reduce(function (a, b) {
                            return aumValue(a) + aumValue(b);
                        }, 0);

                    // Update footer
                    $(api.column(i).footer()).html(formatter.format(total));
                }

            }
        });
    } else {
        $('.table-view-pharus').DataTable({
            "dom": '<"top"lf>rt<"bottom"ip><"clear">',
            "lengthMenu": [[-1, 10, 25, 50], ["All", 10, 25, 50]],
            "scrollX": true,
            "autoWidth": false,
            stateSave: true,
            "footerCallback": function (row, data, start, end, display) {
                var api = this.api(), data;

                // Total over this page
                pageTotal = api
                    .column(6, { page: 'current' })
                    .data()
                    .reduce(function (a, b) {
                        return aumValue(a) + aumValue(b);
                    }, 0);

                // Total over all pages
                total = api
                    .column(6)
                    .data()
                    .reduce(function (a, b) {
                        return aumValue(a) + aumValue(b);
                    }, 0);

                // Update footer
                $(api.column(6).footer()).html(formatter.format(pageTotal) + ' | ' + formatter.format(total) + ' total |');
            }
        });
    }

    $(".dataTables_length select").chosen({
        disable_search_threshold: 10,
        width: "55px",
    });
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
            sortable: true,
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
            this.selectedContainer = $('<div class="selected" id="selectedContainerPharus"></div>').appendTo(this.container);
            this.availableContainer = $('<div class="available" id="availableContainerPharus"></div>')[this.options.availableFirst ? 'prependTo' : 'appendTo'](this.container);
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
