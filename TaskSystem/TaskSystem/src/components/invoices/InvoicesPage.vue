<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">
                Invoices
            </h1>

            <ajax-data-table v-bind:options="tableOptions" v-bind:action-func="action">
                <div slot="root">
                    <table class="table table-bordered table-hover table-striped">
                        <thead class="thead-dark">
                            <tr>
                                <th>Id</th>
                                <th>Task Name</th>
                                <th>Customer Name</th>
                                <th>Customer User Name</th>
                                <th>Created</th>
                                <th>Remarks</th>
                                <th>Paid</th>
                                <th class="actions">Actions</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div slot="actions">
                    <span data-action="edit" class="btn btn-primary btn-xs">
                        <i class="fa fa-pencil-square-o"></i>
                        Edit
                    </span>
                </div>
            </ajax-data-table>
        </div>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue"
    import dataTable from "./../common/DataTable.vue"
    import ajaxDataTable from "./../common/AjaxDataTable.vue"
    import confirmModal from "./../common/ConfirmModal.vue"
    import uiBase from "./../common/UiBase.vue"

    export default {
        extends: uiBase,
        components: {
            mainLayout,
            dataTable,
            confirmModal,
            ajaxDataTable
        },
        data() {
            return {
                tableOptions: {
                    "processing": true,
                    "serverSide": true,
                    "ajax": {
                        "url": window.appRoot + "/Invoices/Search",
                        "type": "POST",
                        data: function (data) {
                            let order = data.order[0];
                            data.isAsc = order.dir == "asc";
                            let col = data.columns[order.column];
                            data.orderBy = col.data.charAt(0).toUpperCase() + col.data.slice(1);
                            data.take = data.length;
                            data.skip = data.start;
                            data.term = data.search.value;
                        }
                    },
                    "columns": [
                        { "data": "id" },
                        { "data": "taskName" },
                        { "data": "customerName" },
                        { "data": "customerUserName" },
                        { "data": "created" },
                        { "data": "remarks" },
                        { "data": "paid" },
                        { "data": "Actions" }
                    ],
                    aoColumnDefs: [
                        {
                            bSortable: false,
                            aTargets: [-1]
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ]
                }
            };
        },
        methods: {
            action(type, data) {
                if (type == "edit") {
                    this.edit(data);
                }
            },
            edit(data) {
                this.$router.push({ path: "/invoices/" + data.id })
            }
        }
    }
</script>