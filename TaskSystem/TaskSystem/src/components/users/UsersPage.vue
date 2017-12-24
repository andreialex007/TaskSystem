<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">Users page</h1>
            <hr />
            <data-table v-bind:options="tableOptions">
                <div class="data-table-template" >
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Email</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                    <div class="edit-column-template data-table-template">
                        <a title="edit" class="edit btn default btn-xs blue" href="javascript:;">
                            <i class="fa fa-edit"></i>
                        </a>
                    </div>
                </div>
            </data-table>


        </div>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue";
    import dataTable from "./../common/DataTable.vue"

    export default {
        components: {
            mainLayout,
            dataTable
        },
        data() {
            return {
                tableOptions: {
                    columns: [
                        { "data": "Id" },
                        { "data": "FirstName" },
                        { "data": "LastName" },
                        { "data": "Email" },
                        { "data": "Actions" }
                    ],
                    "aoColumnDefs": [
                        {
                            bSortable: false,
                            sDefaultContent: $("#tickets-list-page-actions-column-template").html(),
                            aTargets: [-1]
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ]
                }
            };
        },
        mounted() {
            /*
             self.table = $('.tickets-list-page table').DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": "/Tickets/Search",
                    "type": "POST",
                    data: function (data) {
                        data.isCurrent = $(".current-filter :checkbox").is(":checked");
                    }
                },
                "columns": [
                    { "data": "PKID" },
                    { "data": "CustomerName" },
                    { "data": "Status" },
                    { "data": "Priority" },
                    { "data": "AssignedTechnician" },
                    { "data": "Actions" }
                ],
                aoColumnDefs: [
                    {
                        "render": function (data, type, row) {
                            return "<span class='priority-color-mark' style='background-color: " + row.PriorityColor + "' ></span>" + data;
                        },
                        "targets": 3
                    },
                    {
                        bSortable: false,
                        sDefaultContent: $("#tickets-list-page-actions-column-template").html(),
                        aTargets: [-1]
                    }
                ],
                order: [
                    [0, "asc"]
                ]
            });

            */



            //  $(".test-table").dataTable();
        }
    }
</script>