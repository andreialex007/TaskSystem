<script>
    export default {
        data() {
            return { errors: [] };
        },
        mounted() {
            this.init();
            this.checkSaved();
        },
        methods: {
            init() {
                
            },
            checkSaved() {
                let isSaved = Cookies.get('isSaved');
                if (!!isSaved) {
                    toastr.info(isSaved, "Success");
                    Cookies.remove('isSaved');
                }
            },
            blockUI: function (options) {
                options = $.extend(true, {}, options);
                var html = '';
                if (options.animate) {
                    html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '">' + '<div class="block-spinner-bar"><div class="bounce1"></div><div class="bounce2"></div><div class="bounce3"></div></div>' + '</div>';
                } else if (options.iconOnly) {
                    html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '"><img src="/src/assets/loading-spinner-grey.gif" align=""></div>';
                } else if (options.textOnly) {
                    html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '"><span>&nbsp;&nbsp;' + (options.message ? options.message : 'LOADING...') + '</span></div>';
                } else {
                    html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '"><img src="/src/assets/loading-spinner-grey.gif" align=""><span>&nbsp;&nbsp;' + (options.message ? options.message : 'LOADING...') + '</span></div>';
                }

                if (options.target) { // element blocking
                    var el = $(options.target);
                    if (el.height() <= ($(window).height())) {
                        options.cenrerY = true;
                    }
                    el.block({
                        message: html,
                        baseZ: options.zIndex ? options.zIndex : 1000,
                        centerY: options.cenrerY !== undefined ? options.cenrerY : false,
                        css: {
                            top: '10%',
                            border: '0',
                            padding: '0',
                            backgroundColor: 'none'
                        },
                        overlayCSS: {
                            backgroundColor: options.overlayColor ? options.overlayColor : '#555',
                            opacity: options.boxed ? 0.05 : 0.1,
                            cursor: 'wait'
                        }
                    });
                } else { // page blocking
                    $.blockUI({
                        message: html,
                        baseZ: options.zIndex ? options.zIndex : 1000,
                        css: {
                            border: '0',
                            padding: '0',
                            backgroundColor: 'none'
                        },
                        overlayCSS: {
                            backgroundColor: options.overlayColor ? options.overlayColor : '#555',
                            opacity: options.boxed ? 0.05 : 0.1,
                            cursor: 'wait'
                        }
                    });
                }
            },
            // wrMetronicer function to  un-block element(finish loading)
            unblockUI: function (target) {
                if (target) {
                    $(target).unblock({
                        onUnblock: function () {
                            $(target).css('position', '');
                            $(target).css('zoom', '');
                        }
                    });
                } else {
                    $.unblockUI();
                }
            },
            replaceOrAddInArray(array, x) {
                let index = array.map(x => x.id).findIndex(u => u == x.id);
                if (index === -1) {
                    array.push(x);
                } else {
                    array[index] = x;
                }
                this.$forceUpdate();
            }
        }
    }
</script>