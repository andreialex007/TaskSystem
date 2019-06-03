<template>
    <select>
        <slot></slot>
    </select>
</template>


<script>
    export default {
        props: {
            options: { type: Object, default: () => ({}) },
            value: {}
        },
        data() {
            return {

            }
        },
        watch: {
            value: function (value) {
                this.init();
            },
            options: {
                deep: true,
                handler() {
                    this.init();
                }
            }
        },
        mounted() {
            this.init();
        },
        methods: {
            init() {
                try {
                    var vm = this
                    $(this.$el)
                        .select2(this.options)
                        .val(this.value)
                        .trigger('change')
                        .on('change', function () {
                            vm.$emit('update:value', this.value)
                        }).on("select2:select", function () {
                            console.log("select-select2");
                        })
                } catch (ex) {

                }
            }
        },
        beforeDestroy() {
            $(this.$el).off().select2('destroy');
        }
    }
</script>