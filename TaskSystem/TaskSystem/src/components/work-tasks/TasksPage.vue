<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">
                Work tasks
                <span v-on:click="add()" class="btn btn-success pull-right">
                    <i class="fa fa-plus"></i>
                    Add work task
                </span>
            </h1>

            <ajax-data-table v-bind:options="tableOptions" v-bind:action-func="action">
                <div slot="root">
                    <table class="table table-bordered table-hover table-striped">
                        <thead class="thead-dark">
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Status</th>
                                <th>Priority</th>
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
                        "url": window.appRoot + "/WorkTasks/Search",
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
                        { "data": "status" },
                        { "data": "priority" },
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
                this.$router.push({ path: "/WorkTasks/" + data.id })
            },
            add() {
                this.$router.push({ path: "/worktasks/add" })
            }
        }
    }
</script>