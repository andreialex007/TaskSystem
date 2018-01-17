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
                Invoice
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
                    <div class="col-md-4 task-col">
                        <label>Task</label>
                        <input type="text" class="form-control" v-model="invoice.taskName" readonly placeholder="Task Name" >
                        <span class="badge badge-primary task-id-badge"  >#{{ invoice.taskId }}</span>
                    </div>
                    <div class="col-md-4">
                        <label>Customer Name</label>
                        <input type="text" class="form-control" v-model="invoice.customerName" readonly placeholder="Customer Name" >
                    </div>
                    <div class="col-md-4">
                        <label>Customer User Name</label>
                        <input type="text" class="form-control" v-model="invoice.customerUserName" readonly placeholder="Customer User Name" >
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-12">
                        <label>Remarks</label>
                        <br />
                        <textarea v-model="invoice.remarks" placeholder="put your remarks here (required)" class="form-control" ></textarea>
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
        </div>
        
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue"
    import uiBase from "./../common/UiBase.vue"

    export default {
        extends: uiBase,
        components: {
            mainLayout
        },
        data() {
            return {
                invoice: {

                }
            };
        },
        mounted() {
            this.load();
            this.checkSaved();
        },
        methods: {
            load() {
                if (!this.$route.params.id) {
                    this.$http
                        .post(`/invoices/task${this.$route.params.taskId}/add`)
                        .then(this.loadCompleted);
                } else {
                    this.$http
                        .post(`/invoices/${this.$route.params.id}`)
                        .then(this.loadCompleted);
                }
            },
            loadCompleted(result) {
                this.invoice = result.body;
            },
            back() {
                this.$router.go(-1);
            },
            save() {
                var component = this;
                this.$http.post("/invoices/save", this.invoice)
                    .then(function (response) {
                        Cookies.set('isSaved', `Invoice #${response.body.id} Saved`, { expires: 7, path: '/' });
                        this.$router.push({ path: `/invoices/${response.body.id}` });
                        this.checkSaved();
                    })
                    .catch(x => {
                        component.errors = x.body.errors
                    });
            }
        }
    }
</script>