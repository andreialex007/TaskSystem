<template>
    <div class="ajax-data-table data-table-template">
        <slot name="root"></slot>
        <div class="actions-slot">
            <slot name="actions"></slot>
        </div>
    </div>
</template>


<script>
    export default {
        props: {
            options: { type: Object },
            actionFunc: { type: Function }
        },
        data() {
            return {
                table: null,
                tableId: ""
            }
        },
        mounted() {
            let component = this;
            this.tableId = Math.random().toString(36).substr(2, 10);
            $(this.$el).attr("id", this.tableId);
            this.options.aoColumnDefs.filter(x => x.aTargets[0] == -1)[0].sDefaultContent = $(".actions-slot").html();
            let lastColumn = $(this.options.aoColumnDefs).last();
            this.table = $(this.$el).find("table").DataTable(this.options);

            $(document).on("click", "#" + this.tableId + " [data-action]", function (event) {
                let action = $(this).data("action");
                let rowData = component.table.row($(event.target).closest("tr").index()).data();
                component.actionFunc(action, rowData);
            });
        },
        watch: {
        },
        methods: {
           
        }
    }
</script>