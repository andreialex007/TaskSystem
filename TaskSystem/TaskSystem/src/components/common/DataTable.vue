<template>
    <div>
        <slot></slot>
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
                table: null,
                tableId: "",
            }
        },
        mounted() {

        },
        watch: {
            items: {
                handler() {
                    this.initTable();
                },
                deep: true
            },
            options() {
                this.initTable();
            }
        },
        methods: {
            initTable() {
                let component = this;
                if (component.table) {
                    component.table.fnDestroy();
                    component.table = null;
                }
                setTimeout(() => {
                    component.table = $(this.$el).find("table").dataTable(this.options || {});
                    component.table.on('draw', function () {
                        console.log("table-has-been-drawn");
                    });
                }, 1);
            }
        }
    }
</script>