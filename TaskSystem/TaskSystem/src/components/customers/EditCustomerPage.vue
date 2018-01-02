<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">
                <template v-if="!$route.params.id">
                    Create
                </template>
                <template v-if="!!$route.params.id">
                    <span class="badge badge-success">#{{$route.params.id}}</span>
                    Edit
                </template>
                Customer
            </h1>
            <hr />
            <form>
                <div v-show="errors.length > 0" class="alert alert-danger" role="alert">
                    <strong>Errors found!</strong>
                    <ul>
                        <li v-for="item in errors">
                            {{ item.errorMessage }}
                        </li>
                    </ul>
                </div>
                <div class="row form-group">
                    <div class="col-md-12">
                        <label>Address</label>
                        <google-autocomplete v-bind:address.sync="customer.address"></google-autocomplete>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>Name</label>
                        <input type="text" class="form-control" v-model="customer.name" placeholder="Please provide full customer name" value="">
                    </div>
                    <div class="col-md-6">
                        <label>Phone</label>
                        <input type="text" class="form-control" v-model="customer.phone" placeholder="+7(495)123-15-16" value="">
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-12">
                        <label>Notes</label>
                        <br />
                        <summer-note v-bind:value.sync="customer.notes"></summer-note>
                    </div>
                </div>

                <br />
                <div class="text-center">
                    <span v-on:click="save" class="btn btn-primary">
                        <i class="fa fa-floppy-o" aria-hidden="true"></i>
                        Save
                    </span>
                    <span v-on:click="back" class="btn btn-danger">
                        <i class="fa fa-reply" aria-hidden="true"></i>
                        Back
                    </span>
                </div>
            </form>
            <div v-show="customer.id > 0">
                <h3>Customer Users <a href="javascript:;" v-on:click="editItem(null)" class="btn btn-sm btn-primary">Add New</a></h3>
                <data-table v-bind:items="customer.users" v-bind:options="tableOptions">
                    <div class="data-table-template">
                        <table class="table table-bordered table-striped">
                            <thead class="thead-dark">
                                <tr>
                                    <th>Id</th>
                                    <th>Name</th>
                                    <th>Title</th>
                                    <th>Phone</th>
                                    <th>Email</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in customer.users">
                                    <th>{{ item.id }}</th>
                                    <th>{{ item.name }}</th>
                                    <th>{{ item.title }}</th>
                                    <th>{{ item.phone }}</th>
                                    <th>{{ item.email }}</th>
                                    <th>
                                        <a title="edit" v-on:click="editItem(item.id)" class="edit btn btn-primary btn-sm" href="javascript:;">
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
        </div>
        <customer-user-modal ref="editCustomerUserModal"
                             v-bind:customerId="$route.params.id"
                             v-bind:entityId="editedCustomerUserId"></customer-user-modal>
        <confirm-modal ref="confirmModal" title="Are you sure?">
            <span>Are you really want to delete this customer user?</span>
        </confirm-modal>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue";
    import dataTable from "./../common/DataTable.vue"
    import confirmModal from "./../common/ConfirmModal.vue"
    import uiBase from "./../common/UiBase.vue"
    import customerUserModal from "./../customers/EditCustomerUserModal.vue"

    export default {
        extends: uiBase,
        components: {
            mainLayout,
            dataTable,
            confirmModal,
            customerUserModal
        },
        data() {
            return {
                customer: {},
                errors: [],
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
                editedCustomerUserId: 0
            };
        },
        watch: {

        },
        mounted() {
            this.load();
        },
        methods: {
            editItem(id) {
                this.editedCustomerUserId = id;
                this.$refs.editCustomerUserModal.show(this.customerUserSavedFunc);
            },
            customerUserSavedFunc(x) {
                let index = this.customer.users.map(x => x.id).findIndex(u => u == x.id);
                if (index === -1) {
                    this.customer.users.push(x);
                } else {
                    this.customer.users[index] = x;
                }
                this.$forceUpdate();
            },
            deleteItem(item) {
                let component = this;
                this.$refs.confirmModal.show(function () {
                    console.log("delete");
                    component.blockUI({
                        message: 'Deletion, please wait...'
                    });
                    component.$http.post("/customers/deletecustomeruser/" + item.id)
                        .then(function () {
                            component.deleteItemCompleted(item.id)
                        })
                });
            },
            deleteItemCompleted(id) {
                this.customer.users.filter(x => x.id != id);
                this.$forceUpdate();
                this.unblockUI();
                toastr.info("User deleted", "Success");
            },
            load() {
                this.$http.post(`/customers/edit/${this.$route.params.id}`)
                    .then(this.loadCompleted);
            },
            loadCompleted(result) {
                this.customer = result.body;
            },
            back() {
                this.$router.go(-1);
            },
            save() {
                var component = this;
                this.$http.post("/customers/save", this.customer)
                    .then(function (response) {
                        Cookies.set('isSaved', `Customer #${response.body.id} Saved`, { expires: 7, path: '/' });
                        this.$router.push({ path: `/customers` });
                    })
                    .catch(x => {
                        component.errors = x.body.errors
                    });
            }
        }
    }
</script>