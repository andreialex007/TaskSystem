<template>
    <div>
        <slot ></slot>
    </div>
</template>


<script>
    export default {
        props: {
            options: { type: Object },
            items: { type: Array }
        },
        data() {
            return {
                table: null
            }
        },
        mounted() {
            
        },
        watch: {
            items() {
                this.initTable();
            },
            options() {
                this.initTable();
            }
        },
        methods: {
            initTable() {
                this.table = $(this.$el).find("table").dataTable(this.options || {});
            }
        }
    }
</script>