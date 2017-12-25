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
                table: null,
                tableId: "",
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
                setTimeout(() => {
                    if (this.table) {
                        this.table.fnDestroy();
                        this.table = null;
                    }
                    this.table = $(this.$el).find("table").dataTable(this.options || {});
                    this.table.on('draw', function () {
                        console.log("table-has-been-drawn");
                    });
                },10);
            }
        }
    }
</script>