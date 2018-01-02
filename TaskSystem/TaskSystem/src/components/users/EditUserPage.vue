<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">
                <template v-if="!$route.params.id">
                    Create
                </template>
                <template v-if="!!$route.params.id">
                    <span class="badge badge-success">#{{$route.params.id}}</span>    Edit


                </template>
                User

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

                <div class="alert alert-info" role="alert">
                    <strong>Warning!</strong> All fields are required
                </div>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>First name</label>
                        <input type="text" class="form-control" v-model="user.firstName" placeholder="First name" value="">
                    </div>
                    <div class="col-md-6">
                        <label>Last name</label>
                        <input type="text" class="form-control" v-model="user.lastName" placeholder="Last name" value="">
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>Phone</label>
                        <input type="text" class="form-control" v-model="user.phone" placeholder="+7(495)123-15-16" value="">
                    </div>
                    <div class="col-md-6">
                        <label>Role</label>
                        <select v-model="user.role" class="form-control">
                            <option value="">Please select role</option>
                            <template v-for="role in user.avaliableRoles">
                                <option v-bind:value="role.key">{{ role.value }}</option>
                            </template>
                        </select>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>Email</label>
                        <input type="text" v-model="user.email" class="form-control " placeholder="First name" value="">
                    </div>
                    <div class="col-md-6">
                        <label>Password</label>
                        <input type="password" v-model="user.password" class="form-control " placeholder="Password" value="">
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
    import uiBase from "./../common/UiBase.vue"

    export default {
        extends: uiBase,
        components: {
            mainLayout
        },
        data() {
            return {
                user: {

                }
            };
        },
        mounted() {
            this.load();
        },
        methods: {
            load() {
                this.$http.post(`/users/edit/${this.$route.params.id}`)
                    .then(this.loadCompleted);
            },
            loadCompleted(result) {
                this.user = result.body;
                this.user.role = this.user.role || "";
            },
            back() {
                this.$router.go(-1);
            },
            save() {
                var component = this;

                this.$http.post("/users/save", this.user)
                    .then(function (response) {
                        Cookies.set('isSaved', `User #${response.body.id} Saved`, { expires: 7, path: '/' });
                        this.$router.push({ path: `/users` });
                    })
                    .catch(x => {
                        component.errors = x.body.errors
                    });
            }
        }
    }
</script>