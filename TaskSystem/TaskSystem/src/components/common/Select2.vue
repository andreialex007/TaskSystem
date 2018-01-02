<template>
    <select ></select>
</template>


<script>
    export default {
        props: {
            options: {
                type: Object, default: () => ({
                    placeholder: "Please select item",
                    width: "100%"
                })
            },
            value: { type: String }
        },
        data() {
            return {

            }
        },
        watch: {
            value: function (value) {
                $(this.$el).val(value)
            },
            options: function (options) {
                $(this.$el).empty().select2({ data: options })
            }
        },
        mounted() {
            var vm = this
            $(this.$el)
                .select2(this.options)
                .val(this.value)
                .trigger('change')
                .on('change', function () {
                    vm.$emit('input', this.value)
                })
        },
        beforeDestroy() {
            $(this.$el).off().select2('destroy');
        }
    }
</script>