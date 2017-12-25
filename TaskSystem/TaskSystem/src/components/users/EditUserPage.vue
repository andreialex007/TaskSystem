<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">
                Add User

            </h1>
            <hr />
            <form>
                <div class="alert alert-info" role="alert">
                    <strong>Warning!</strong> All fields are required
                </div>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>First name</label>
                        <input type="text" class="form-control " placeholder="First name" value="">
                    </div>
                    <div class="col-md-6">
                        <label>Last name</label>
                        <input type="text" class="form-control" placeholder="Last name" value="">
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>Phone</label>
                        <input type="text" class="form-control" placeholder="+7(495)123-15-16" value="">
                    </div>
                    <div class="col-md-6">
                        <label>Role</label>
                        <select class="form-control">
                            <option>Please select role</option>
                            <option value="2">Supervisor</option>
                            <option value="2">Technician</option>
                        </select>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>Email</label>
                        <input type="text" class="form-control " placeholder="First name" value="">
                    </div>
                    <div class="col-md-6">
                        <label>Password</label>
                        <input type="password" class="form-control " placeholder="Password" value="">
                    </div>
                </div>

                <br />
                <div class="text-center" >
                    <span class="btn btn-primary">
                        <i class="fa fa-floppy-o" aria-hidden="true"></i>
                        Save
                    </span>
                    <span class="btn btn-danger">
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
                user: {
                    
                }
            };
        },
        mounted() {
            let userId = this.$route.params.id;
        },
        methods: {
            load() {

            }
        }
    }
</script>