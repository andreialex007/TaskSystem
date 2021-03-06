<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">
                Customers
                <span v-on:click="add()" class="btn btn-success pull-right">
                    <i class="fa fa-plus"></i>
                    Add customer
                </span>
            </h1>

            <ajax-data-table v-bind:options="tableOptions" v-bind:action-func="action">
                <div slot="root">
                    <table class="table table-bordered table-hover table-striped">
                        <thead class="thead-dark">
                            <tr>
                                <th>Id</th>
                                <th>Customer Name</th>
                                <th>Address</th>
                                <th>Phone</th>
                                <th class="actions">Actions</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div slot="actions">
                    <span data-action="edit" class="btn btn-primary btn-sm">
                        <i class="fa fa-pencil-square-o"></i>
                        Edit
                    </span>
                    <span data-action="delete" class="btn btn-danger btn-sm">
                        <i class="fa fa-times"></i>
                        Delete
                    </span>
                </div>
            </ajax-data-table>
        </div>
        <confirm-modal ref="confirmModal" title="Are you sure?">
            <span>Are you really want to delete this customer?</span>
        </confirm-modal>
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
                        "url": window.appRoot + "/Customers/Search",
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
                        { "data": "name" },
                        { "data": "address" },
                        { "data": "phone" },
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
                if (type == "delete") {
                    this.deleteItem(data);
                }
            },
            edit(data) {
                this.$router.push({ path: "/customers/" + data.id })
            },
            add() {
                this.$router.push({ path: "/customers/add" })
            },
            deleteItem(item) {
                let component = this;
                this.$refs.confirmModal.show(function () {
                    console.log("delete");
                    component.blockUI({
                        message: 'Deletion, please wait...'
                    });
                    component.$http.post("/customers/delete/" + item.id)
                        .then(component.deleteItemCompleted)
                });
            },
            deleteItemCompleted() {
                this.unblockUI();
                this.$router.go();
            },
        }
    }
</script>