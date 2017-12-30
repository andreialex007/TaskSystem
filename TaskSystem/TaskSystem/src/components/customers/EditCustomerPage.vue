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
        </div>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue";

    export default {
        components: {
            mainLayout
        },
        data() {
            return {
                customer: {},
                errors: [],
                testValue: "testsuper"
            };
        },
        watch: {

        },
        mounted() {
            this.load();
        },
        methods: {
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