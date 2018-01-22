<template>
    <input type="text" v-bind:placeholder="placeholder" v-bind:value="value" class="form-control" />
</template>


<script>
    export default {
        props: {
            options: {
                type: Object, default: () => ({
                    format: "dd.mm.yyyy",
                    autoclose: true
                })
            },
            value: { type: String },
            placeholder: { type: String }
        },
        watch: {
            value() {
                $(this.$el).datepicker('update', !!this.value ? moment(this.value, "DD.MM.YYYY").toDate() : null);
            }
        },
        data() {
            return {
            }
        },
        mounted() {
            let component = this;
            $(this.$el).datepicker(this.options)
                .on("changeDate", function (event, b, c) {
                    component.$emit("update:value", moment(event.date).format("DD.MM.YYYY"));
                })

            $(this.$el).datepicker('update', !!this.value ? moment(this.value, "DD.MM.YYYY").toDate() : null);
        },
        beforeDestroy() {
            $(this.$el).datepicker("destroy");
        }
    }
</script>