<template>
    <main-layout ref="mainLayout">
        <div class="col-lg-12">
            <h1 class="mt-5">
                Users page
                <span v-on:click="addItem" class="btn btn-success pull-right">
                    <i class="fa fa-user-plus" aria-hidden="true"></i>
                    Add user
                </span>
            </h1>
            <hr />
            <data-table v-bind:items="items" v-bind:options="tableOptions">
                <div class="data-table-template">
                    <table class="table table-bordered table-striped">
                        <thead class="thead-dark">
                            <tr>
                                <th>Id</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Email</th>
                                <th>Phone</th>
                                <th>Role</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="item in items">
                                <th>{{ item.id }}</th>
                                <th>{{ item.firstName }}</th>
                                <th>{{ item.lastName }}</th>
                                <th>{{ item.email }}</th>
                                <th>{{ item.phone }}</th>
                                <th>{{ item.roleName }}</th>
                                <th>
                                    <a title="edit" v-on:click="editItem(item)" class="edit btn btn-primary btn-sm" href="javascript:;">
                                        <i class="fa fa-edit"></i>
                                        Edit
                                    </a>
                                    <a title="edit" v-on:click="deleteItem(item)" class="edit btn btn-danger btn-sm" href="javascript:;">
                                        <i class="fa fa-times"></i>
                                        Delete
                                    </a>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </data-table>
        </div>
        <confirm-modal ref="confirmModal" title="Are you sure?">
            <span>Are you really want to delete this user?</span>
        </confirm-modal>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue";
    import dataTable from "./../common/DataTable.vue"
    import confirmModal from "./../common/ConfirmModal.vue"
    import pageBase from "./../common/PageBase.vue"


    export default {
        extends: pageBase,
        components: {
            mainLayout,
            dataTable,
            confirmModal
        },
        data() {
            return {
                tableOptions: {
                    "aoColumnDefs": [
                        {
                            bSortable: false,
                            aTargets: [-1]
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ]
                },
                items: []
            };
        },
        mounted() {

            let isSaved = Cookies.get('isSaved');
            if (!!isSaved) {
                toastr.info(isSaved, "Success");
                Cookies.remove('isSaved');
            }

            this.load();
        },
        methods: {
            editItem(item) {
                this.$router.push({ path: "/users/" + item.id })
            },
            deleteItem(item) {
                let component = this;
                this.$refs.confirmModal.show(function () {
                    console.log("delete");
                    component.blockUI({
                        message: 'Deletion, please wait...'
                    });
                    component.$http.post("/users/delete/" + item.id)
                        .then(component.deleteItemCompleted)
                });
            },
            deleteItemCompleted() {
                this.unblockUI();
                this.load();
            },
            addItem() {
                this.$router.push({ name: "addUser" })
            },
            load() {
                this.$http.post("/Users/All")
                    .then(this.loadCompleted);
            },
            loadCompleted(result) {
                this.items = result.body;
            }
        }
    }
</script>