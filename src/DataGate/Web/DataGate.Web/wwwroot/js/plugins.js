// Double top scroll plugin

(function ($) {

	jQuery.fn.doubleScroll = function (userOptions) {

		// Default options
		let options = {
			contentElement: undefined, // Widest element, if not specified first child element will be used
			scrollCss: {
				'overflow-x': 'auto',
				'overflow-y': 'hidden',
				'height': '20px'
			},
			contentCss: {
				'overflow-x': 'auto',
				'overflow-y': 'hidden'
			},
			onlyIfScroll: true, // top scrollbar is not shown if the bottom one is not present
			resetOnWindowResize: false, // recompute the top ScrollBar requirements when the window is resized
			timeToWaitForResize: 30 // wait for the last update event (usefull when browser fire resize event constantly during ressing)
		};

		$.extend(true, options, userOptions);

		// do not modify
		// internal stuff
		$.extend(options, {
			topScrollBarMarkup: '<div class="doubleScroll-scroll-wrapper"><div class="doubleScroll-scroll"></div></div>',
			topScrollBarWrapperSelector: '.doubleScroll-scroll-wrapper',
			topScrollBarInnerSelector: '.doubleScroll-scroll'
		});

		let _showScrollBar = function ($self, options) {
			if (options.onlyIfScroll && $self.get(0).scrollWidth <= $self.width()) {
				// content doesn't scroll
				// remove any existing occurrence...
				$self.prev(options.topScrollBarWrapperSelector).remove();
				return;
			}
			// add div that will act as an upper scroll only if not already added to the DOM
			let $topScrollBar = $self.prev(options.topScrollBarWrapperSelector);

			if ($topScrollBar.length == 0) {

				// creating the scrollbar
				// added before in the DOM
				$topScrollBar = $(options.topScrollBarMarkup);
				$self.before($topScrollBar);

				// apply the css
				$topScrollBar.css(options.scrollCss);
				$(options.topScrollBarInnerSelector).css("height", "20px");
				$self.css(options.contentCss);

				// bind upper scroll to bottom scroll
				$topScrollBar.bind('scroll.doubleScroll', function () {
					$self.scrollLeft($topScrollBar.scrollLeft());
				});

				// bind bottom scroll to upper scroll
				let selfScrollHandler = function () {
					$topScrollBar.scrollLeft($self.scrollLeft());
				};
				$self.bind('scroll.doubleScroll', selfScrollHandler);
			}

			// find the content element (should be the widest one)	
			let $contentElement;

			if (options.contentElement !== undefined && $self.find(options.contentElement).length !== 0) {
				$contentElement = $self.find(options.contentElement);
			} else {
				$contentElement = $self.find('>:first-child');
			}

			// set the width of the wrappers
			$(options.topScrollBarInnerSelector, $topScrollBar).width($contentElement.outerWidth());
			$topScrollBar.width($self.width());
			$topScrollBar.scrollLeft($self.scrollLeft());
		}

		return this.each(function () {
			let $self = $(this);

			_showScrollBar($self, options);
			// bind the resize handler 
			// do it once
			if (options.resetOnWindowResize) {
				let id;
				let handler = function (e) {
					_showScrollBar($self, options);
				};

				$(window).bind('resize.doubleScroll', function () {
					// adding/removing/replacing the scrollbar might resize the window
					// so the resizing flag will avoid the infinite loop here...
					clearTimeout(id);
					id = setTimeout(handler, options.timeToWaitForResize);
				});
			}
		});
	}

}(jQuery));

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

/*!
 * jQuery blockUI plugin
 * Version 2.70.0-2014.11.23
 * Requires jQuery v1.7 or later
 *
 * Examples at: http://malsup.com/jquery/block/
 * Copyright (c) 2007-2013 M. Alsup
 * Dual licensed under the MIT and GPL licenses:
 * http://www.opensource.org/licenses/mit-license.php
 * http://www.gnu.org/licenses/gpl.html
 *
 * Thanks to Amir-Hossein Sobhi for some excellent contributions!
 */

; (function () {
	/*jshint eqeqeq:false curly:false latedef:false */
	"use strict";

	function setup($) {
		$.fn._fadeIn = $.fn.fadeIn;

		var noOp = $.noop || function () { };

		// this bit is to ensure we don't call setExpression when we shouldn't (with extra muscle to handle
		// confusing userAgent strings on Vista)
		var msie = /MSIE/.test(navigator.userAgent);
		var ie6 = /MSIE 6.0/.test(navigator.userAgent) && ! /MSIE 8.0/.test(navigator.userAgent);
		var mode = document.documentMode || 0;
		var setExpr = $.isFunction(document.createElement('div').style.setExpression);

		// global $ methods for blocking/unblocking the entire page
		$.blockUI = function (opts) { install(window, opts); };
		$.unblockUI = function (opts) { remove(window, opts); };

		// convenience method for quick growl-like notifications  (http://www.google.com/search?q=growl)
		$.growlUI = function (title, message, timeout, onClose) {
			var $m = $('<div class="growlUI"></div>');
			if (title) $m.append('<h1>' + title + '</h1>');
			if (message) $m.append('<h2>' + message + '</h2>');
			if (timeout === undefined) timeout = 3000;

			// Added by konapun: Set timeout to 30 seconds if this growl is moused over, like normal toast notifications
			var callBlock = function (opts) {
				opts = opts || {};

				$.blockUI({
					message: $m,
					fadeIn: typeof opts.fadeIn !== 'undefined' ? opts.fadeIn : 700,
					fadeOut: typeof opts.fadeOut !== 'undefined' ? opts.fadeOut : 1000,
					timeout: typeof opts.timeout !== 'undefined' ? opts.timeout : timeout,
					centerY: false,
					showOverlay: false,
					onUnblock: onClose,
					css: $.blockUI.defaults.growlCSS
				});
			};

			callBlock();
			var nonmousedOpacity = $m.css('opacity');
			$m.mouseover(function () {
				callBlock({
					fadeIn: 0,
					timeout: 30000
				});

				var displayBlock = $('.blockMsg');
				displayBlock.stop(); // cancel fadeout if it has started
				displayBlock.fadeTo(300, 1); // make it easier to read the message by removing transparency
			}).mouseout(function () {
				$('.blockMsg').fadeOut(1000);
			});
			// End konapun additions
		};

		// plugin method for blocking element content
		$.fn.block = function (opts) {
			if (this[0] === window) {
				$.blockUI(opts);
				return this;
			}
			var fullOpts = $.extend({}, $.blockUI.defaults, opts || {});
			this.each(function () {
				var $el = $(this);
				if (fullOpts.ignoreIfBlocked && $el.data('blockUI.isBlocked'))
					return;
				$el.unblock({ fadeOut: 0 });
			});

			return this.each(function () {
				if ($.css(this, 'position') == 'static') {
					this.style.position = 'relative';
					$(this).data('blockUI.static', true);
				}
				this.style.zoom = 1; // force 'hasLayout' in ie
				install(this, opts);
			});
		};

		// plugin method for unblocking element content
		$.fn.unblock = function (opts) {
			if (this[0] === window) {
				$.unblockUI(opts);
				return this;
			}
			return this.each(function () {
				remove(this, opts);
			});
		};

		$.blockUI.version = 2.70; // 2nd generation blocking at no extra cost!

		// override these in your code to change the default behavior and style
		$.blockUI.defaults = {
			// message displayed when blocking (use null for no message)
			message: '<h1>Please wait...</h1>',

			title: null,		// title string; only used when theme == true
			draggable: true,	// only used when theme == true (requires jquery-ui.js to be loaded)

			theme: false, // set to true to use with jQuery UI themes

			// styles for the message when blocking; if you wish to disable
			// these and use an external stylesheet then do this in your code:
			// $.blockUI.defaults.css = {};
			css: {
				padding: 0,
				margin: 0,
				width: '30%',
				top: '40%',
				left: '35%',
				textAlign: 'center',
				color: '#000',
				border: '3px solid #aaa',
				backgroundColor: '#fff',
				cursor: 'wait'
			},

			// minimal style set used when themes are used
			themedCSS: {
				width: '30%',
				top: '40%',
				left: '35%'
			},

			// styles for the overlay
			overlayCSS: {
				backgroundColor: '#000',
				opacity: 0.6,
				cursor: 'wait'
			},

			// style to replace wait cursor before unblocking to correct issue
			// of lingering wait cursor
			cursorReset: 'default',

			// styles applied when using $.growlUI
			growlCSS: {
				width: '350px',
				top: '10px',
				left: '',
				right: '10px',
				border: 'none',
				padding: '5px',
				opacity: 0.6,
				cursor: 'default',
				color: '#fff',
				backgroundColor: '#000',
				'-webkit-border-radius': '10px',
				'-moz-border-radius': '10px',
				'border-radius': '10px'
			},

			// IE issues: 'about:blank' fails on HTTPS and javascript:false is s-l-o-w
			// (hat tip to Jorge H. N. de Vasconcelos)
			/*jshint scripturl:true */
			iframeSrc: /^https/i.test(window.location.href || '') ? 'javascript:false' : 'about:blank',

			// force usage of iframe in non-IE browsers (handy for blocking applets)
			forceIframe: false,

			// z-index for the blocking overlay
			baseZ: 1000,

			// set these to true to have the message automatically centered
			centerX: true, // <-- only effects element blocking (page block controlled via css above)
			centerY: true,

			// allow body element to be stetched in ie6; this makes blocking look better
			// on "short" pages.  disable if you wish to prevent changes to the body height
			allowBodyStretch: true,

			// enable if you want key and mouse events to be disabled for content that is blocked
			bindEvents: true,

			// be default blockUI will supress tab navigation from leaving blocking content
			// (if bindEvents is true)
			constrainTabKey: true,

			// fadeIn time in millis; set to 0 to disable fadeIn on block
			fadeIn: 200,

			// fadeOut time in millis; set to 0 to disable fadeOut on unblock
			fadeOut: 400,

			// time in millis to wait before auto-unblocking; set to 0 to disable auto-unblock
			timeout: 0,

			// disable if you don't want to show the overlay
			showOverlay: true,

			// if true, focus will be placed in the first available input field when
			// page blocking
			focusInput: true,

			// elements that can receive focus
			focusableElements: ':input:enabled:visible',

			// suppresses the use of overlay styles on FF/Linux (due to performance issues with opacity)
			// no longer needed in 2012
			// applyPlatformOpacityRules: true,

			// callback method invoked when fadeIn has completed and blocking message is visible
			onBlock: null,

			// callback method invoked when unblocking has completed; the callback is
			// passed the element that has been unblocked (which is the window object for page
			// blocks) and the options that were passed to the unblock call:
			//	onUnblock(element, options)
			onUnblock: null,

			// callback method invoked when the overlay area is clicked.
			// setting this will turn the cursor to a pointer, otherwise cursor defined in overlayCss will be used.
			onOverlayClick: null,

			// don't ask; if you really must know: http://groups.google.com/group/jquery-en/browse_thread/thread/36640a8730503595/2f6a79a77a78e493#2f6a79a77a78e493
			quirksmodeOffsetHack: 4,

			// class name of the message block
			blockMsgClass: 'blockMsg',

			// if it is already blocked, then ignore it (don't unblock and reblock)
			ignoreIfBlocked: false
		};

		// private data and functions follow...

		var pageBlock = null;
		var pageBlockEls = [];

		function install(el, opts) {
			var css, themedCSS;
			var full = (el == window);
			var msg = (opts && opts.message !== undefined ? opts.message : undefined);
			opts = $.extend({}, $.blockUI.defaults, opts || {});

			if (opts.ignoreIfBlocked && $(el).data('blockUI.isBlocked'))
				return;

			opts.overlayCSS = $.extend({}, $.blockUI.defaults.overlayCSS, opts.overlayCSS || {});
			css = $.extend({}, $.blockUI.defaults.css, opts.css || {});
			if (opts.onOverlayClick)
				opts.overlayCSS.cursor = 'pointer';

			themedCSS = $.extend({}, $.blockUI.defaults.themedCSS, opts.themedCSS || {});
			msg = msg === undefined ? opts.message : msg;

			// remove the current block (if there is one)
			if (full && pageBlock)
				remove(window, { fadeOut: 0 });

			// if an existing element is being used as the blocking content then we capture
			// its current place in the DOM (and current display style) so we can restore
			// it when we unblock
			if (msg && typeof msg != 'string' && (msg.parentNode || msg.jquery)) {
				var node = msg.jquery ? msg[0] : msg;
				var data = {};
				$(el).data('blockUI.history', data);
				data.el = node;
				data.parent = node.parentNode;
				data.display = node.style.display;
				data.position = node.style.position;
				if (data.parent)
					data.parent.removeChild(node);
			}

			$(el).data('blockUI.onUnblock', opts.onUnblock);
			var z = opts.baseZ;

			// blockUI uses 3 layers for blocking, for simplicity they are all used on every platform;
			// layer1 is the iframe layer which is used to supress bleed through of underlying content
			// layer2 is the overlay layer which has opacity and a wait cursor (by default)
			// layer3 is the message content that is displayed while blocking
			var lyr1, lyr2, lyr3, s;
			if (msie || opts.forceIframe)
				lyr1 = $('<iframe class="blockUI" style="z-index:' + (z++) + ';display:none;border:none;margin:0;padding:0;position:absolute;width:100%;height:100%;top:0;left:0" src="' + opts.iframeSrc + '"></iframe>');
			else
				lyr1 = $('<div class="blockUI" style="display:none"></div>');

			if (opts.theme)
				lyr2 = $('<div class="blockUI blockOverlay ui-widget-overlay" style="z-index:' + (z++) + ';display:none"></div>');
			else
				lyr2 = $('<div class="blockUI blockOverlay" style="z-index:' + (z++) + ';display:none;border:none;margin:0;padding:0;width:100%;height:100%;top:0;left:0"></div>');

			if (opts.theme && full) {
				s = '<div class="blockUI ' + opts.blockMsgClass + ' blockPage ui-dialog ui-widget ui-corner-all" style="z-index:' + (z + 10) + ';display:none;position:fixed">';
				if (opts.title) {
					s += '<div class="ui-widget-header ui-dialog-titlebar ui-corner-all blockTitle">' + (opts.title || '&nbsp;') + '</div>';
				}
				s += '<div class="ui-widget-content ui-dialog-content"></div>';
				s += '</div>';
			}
			else if (opts.theme) {
				s = '<div class="blockUI ' + opts.blockMsgClass + ' blockElement ui-dialog ui-widget ui-corner-all" style="z-index:' + (z + 10) + ';display:none;position:absolute">';
				if (opts.title) {
					s += '<div class="ui-widget-header ui-dialog-titlebar ui-corner-all blockTitle">' + (opts.title || '&nbsp;') + '</div>';
				}
				s += '<div class="ui-widget-content ui-dialog-content"></div>';
				s += '</div>';
			}
			else if (full) {
				s = '<div class="blockUI ' + opts.blockMsgClass + ' blockPage" style="z-index:' + (z + 10) + ';display:none;position:fixed"></div>';
			}
			else {
				s = '<div class="blockUI ' + opts.blockMsgClass + ' blockElement" style="z-index:' + (z + 10) + ';display:none;position:absolute"></div>';
			}
			lyr3 = $(s);

			// if we have a message, style it
			if (msg) {
				if (opts.theme) {
					lyr3.css(themedCSS);
					lyr3.addClass('ui-widget-content');
				}
				else
					lyr3.css(css);
			}

			// style the overlay
			if (!opts.theme /*&& (!opts.applyPlatformOpacityRules)*/)
				lyr2.css(opts.overlayCSS);
			lyr2.css('position', full ? 'fixed' : 'absolute');

			// make iframe layer transparent in IE
			if (msie || opts.forceIframe)
				lyr1.css('opacity', 0.0);

			//$([lyr1[0],lyr2[0],lyr3[0]]).appendTo(full ? 'body' : el);
			var layers = [lyr1, lyr2, lyr3], $par = full ? $('body') : $(el);
			$.each(layers, function () {
				this.appendTo($par);
			});

			if (opts.theme && opts.draggable && $.fn.draggable) {
				lyr3.draggable({
					handle: '.ui-dialog-titlebar',
					cancel: 'li'
				});
			}

			// ie7 must use absolute positioning in quirks mode and to account for activex issues (when scrolling)
			var expr = setExpr && (!$.support.boxModel || $('object,embed', full ? null : el).length > 0);
			if (ie6 || expr) {
				// give body 100% height
				if (full && opts.allowBodyStretch && $.support.boxModel)
					$('html,body').css('height', '100%');

				// fix ie6 issue when blocked element has a border width
				if ((ie6 || !$.support.boxModel) && !full) {
					var t = sz(el, 'borderTopWidth'), l = sz(el, 'borderLeftWidth');
					var fixT = t ? '(0 - ' + t + ')' : 0;
					var fixL = l ? '(0 - ' + l + ')' : 0;
				}

				// simulate fixed position
				$.each(layers, function (i, o) {
					var s = o[0].style;
					s.position = 'absolute';
					if (i < 2) {
						if (full)
							s.setExpression('height', 'Math.max(document.body.scrollHeight, document.body.offsetHeight) - (jQuery.support.boxModel?0:' + opts.quirksmodeOffsetHack + ') + "px"');
						else
							s.setExpression('height', 'this.parentNode.offsetHeight + "px"');
						if (full)
							s.setExpression('width', 'jQuery.support.boxModel && document.documentElement.clientWidth || document.body.clientWidth + "px"');
						else
							s.setExpression('width', 'this.parentNode.offsetWidth + "px"');
						if (fixL) s.setExpression('left', fixL);
						if (fixT) s.setExpression('top', fixT);
					}
					else if (opts.centerY) {
						if (full) s.setExpression('top', '(document.documentElement.clientHeight || document.body.clientHeight) / 2 - (this.offsetHeight / 2) + (blah = document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop) + "px"');
						s.marginTop = 0;
					}
					else if (!opts.centerY && full) {
						var top = (opts.css && opts.css.top) ? parseInt(opts.css.top, 10) : 0;
						var expression = '((document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop) + ' + top + ') + "px"';
						s.setExpression('top', expression);
					}
				});
			}

			// show the message
			if (msg) {
				if (opts.theme)
					lyr3.find('.ui-widget-content').append(msg);
				else
					lyr3.append(msg);
				if (msg.jquery || msg.nodeType)
					$(msg).show();
			}

			if ((msie || opts.forceIframe) && opts.showOverlay)
				lyr1.show(); // opacity is zero
			if (opts.fadeIn) {
				var cb = opts.onBlock ? opts.onBlock : noOp;
				var cb1 = (opts.showOverlay && !msg) ? cb : noOp;
				var cb2 = msg ? cb : noOp;
				if (opts.showOverlay)
					lyr2._fadeIn(opts.fadeIn, cb1);
				if (msg)
					lyr3._fadeIn(opts.fadeIn, cb2);
			}
			else {
				if (opts.showOverlay)
					lyr2.show();
				if (msg)
					lyr3.show();
				if (opts.onBlock)
					opts.onBlock.bind(lyr3)();
			}

			// bind key and mouse events
			bind(1, el, opts);

			if (full) {
				pageBlock = lyr3[0];
				pageBlockEls = $(opts.focusableElements, pageBlock);
				if (opts.focusInput)
					setTimeout(focus, 20);
			}
			else
				center(lyr3[0], opts.centerX, opts.centerY);

			if (opts.timeout) {
				// auto-unblock
				var to = setTimeout(function () {
					if (full)
						$.unblockUI(opts);
					else
						$(el).unblock(opts);
				}, opts.timeout);
				$(el).data('blockUI.timeout', to);
			}
		}

		// remove the block
		function remove(el, opts) {
			var count;
			var full = (el == window);
			var $el = $(el);
			var data = $el.data('blockUI.history');
			var to = $el.data('blockUI.timeout');
			if (to) {
				clearTimeout(to);
				$el.removeData('blockUI.timeout');
			}
			opts = $.extend({}, $.blockUI.defaults, opts || {});
			bind(0, el, opts); // unbind events

			if (opts.onUnblock === null) {
				opts.onUnblock = $el.data('blockUI.onUnblock');
				$el.removeData('blockUI.onUnblock');
			}

			var els;
			if (full) // crazy selector to handle odd field errors in ie6/7
				els = $('body').children().filter('.blockUI').add('body > .blockUI');
			else
				els = $el.find('>.blockUI');

			// fix cursor issue
			if (opts.cursorReset) {
				if (els.length > 1)
					els[1].style.cursor = opts.cursorReset;
				if (els.length > 2)
					els[2].style.cursor = opts.cursorReset;
			}

			if (full)
				pageBlock = pageBlockEls = null;

			if (opts.fadeOut) {
				count = els.length;
				els.stop().fadeOut(opts.fadeOut, function () {
					if (--count === 0)
						reset(els, data, opts, el);
				});
			}
			else
				reset(els, data, opts, el);
		}

		// move blocking element back into the DOM where it started
		function reset(els, data, opts, el) {
			var $el = $(el);
			if ($el.data('blockUI.isBlocked'))
				return;

			els.each(function (i, o) {
				// remove via DOM calls so we don't lose event handlers
				if (this.parentNode)
					this.parentNode.removeChild(this);
			});

			if (data && data.el) {
				data.el.style.display = data.display;
				data.el.style.position = data.position;
				data.el.style.cursor = 'default'; // #59
				if (data.parent)
					data.parent.appendChild(data.el);
				$el.removeData('blockUI.history');
			}

			if ($el.data('blockUI.static')) {
				$el.css('position', 'static'); // #22
			}

			if (typeof opts.onUnblock == 'function')
				opts.onUnblock(el, opts);

			// fix issue in Safari 6 where block artifacts remain until reflow
			var body = $(document.body), w = body.width(), cssW = body[0].style.width;
			body.width(w - 1).width(w);
			body[0].style.width = cssW;
		}

		// bind/unbind the handler
		function bind(b, el, opts) {
			var full = el == window, $el = $(el);

			// don't bother unbinding if there is nothing to unbind
			if (!b && (full && !pageBlock || !full && !$el.data('blockUI.isBlocked')))
				return;

			$el.data('blockUI.isBlocked', b);

			// don't bind events when overlay is not in use or if bindEvents is false
			if (!full || !opts.bindEvents || (b && !opts.showOverlay))
				return;

			// bind anchors and inputs for mouse and key events
			var events = 'mousedown mouseup keydown keypress keyup touchstart touchend touchmove';
			if (b)
				$(document).bind(events, opts, handler);
			else
				$(document).unbind(events, handler);

			// former impl...
			//		var $e = $('a,:input');
			//		b ? $e.bind(events, opts, handler) : $e.unbind(events, handler);
		}

		// event handler to suppress keyboard/mouse events when blocking
		function handler(e) {
			// allow tab navigation (conditionally)
			if (e.type === 'keydown' && e.keyCode && e.keyCode == 9) {
				if (pageBlock && e.data.constrainTabKey) {
					var els = pageBlockEls;
					var fwd = !e.shiftKey && e.target === els[els.length - 1];
					var back = e.shiftKey && e.target === els[0];
					if (fwd || back) {
						setTimeout(function () { focus(back); }, 10);
						return false;
					}
				}
			}
			var opts = e.data;
			var target = $(e.target);
			if (target.hasClass('blockOverlay') && opts.onOverlayClick)
				opts.onOverlayClick(e);

			// allow events within the message content
			if (target.parents('div.' + opts.blockMsgClass).length > 0)
				return true;

			// allow events for content that is not being blocked
			return target.parents().children().filter('div.blockUI').length === 0;
		}

		function focus(back) {
			if (!pageBlockEls)
				return;
			var e = pageBlockEls[back === true ? pageBlockEls.length - 1 : 0];
			if (e)
				e.focus();
		}

		function center(el, x, y) {
			var p = el.parentNode, s = el.style;
			var l = ((p.offsetWidth - el.offsetWidth) / 2) - sz(p, 'borderLeftWidth');
			var t = ((p.offsetHeight - el.offsetHeight) / 2) - sz(p, 'borderTopWidth');
			if (x) s.left = l > 0 ? (l + 'px') : '0';
			if (y) s.top = t > 0 ? (t + 'px') : '0';
		}

		function sz(el, p) {
			return parseInt($.css(el, p), 10) || 0;
		}

	}


	/*global define:true */
	if (typeof define === 'function' && define.amd && define.amd.jQuery) {
		define(['jquery'], setup);
	} else {
		setup(jQuery);
	}

})();