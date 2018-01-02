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
                Work task
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
                <h4>Main Info</h4>
                <div class="row form-group">
                    <div class="col-md-12">
                        <label>Work task name</label>
                        <input type="text" class="form-control" v-model="task.name" placeholder="Task name (Required)" value="">
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-12">
                        <label>Description</label>
                        <br />
                        <summer-note v-bind:value.sync="task.description"></summer-note>
                    </div>
                </div>
                <h4>Task properties and customer info</h4>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>Priority</label>
                        <select v-model="task.priority" class="form-control" >
                            <option v-for="priority in task.avaliablePriorities" v-bind:value="priority.key">{{ priority.value }}</option>
                        </select>
                    </div>
                    <div class="col-md-6">
                        <label>Status</label>
                        <select  v-model="task.status"  class="form-control" >
                            <option v-for="item in task.avaliableStatuses" v-bind:value="item.key">{{ item.value }}</option>
                        </select>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-4">
                        <label>Customer</label>
                        <select class="form-control" >
                            <option value="" >Please select item</option>
                        </select>
                    </div>
                    <div class="col-md-4">
                        <label>Customer user</label>
                        <select class="form-control" >
                            <option value="" >Please select item</option>
                        </select>
                    </div>
                    <div class="col-md-4">
                        <label>Assigned Technician</label>
                        <select class="form-control" >
                            <option value="" >Please select item</option>
                        </select>
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
                <br />

                <div class="sub-entities" >
                    <!-- Nav tabs -->
                    <ul class="nav nav-pills" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" href="#home" role="tab">Notes</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#profile" role="tab">Documents</a>
                        </li>
                    </ul>

                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div class="tab-pane active" id="home" role="tabpanel">notes content</div>
                        <div class="tab-pane" id="profile" role="tabpanel">documents list</div>
                    </div>
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
                task: {

                }
            };
        },
        mounted() {
            this.load();
        },
        methods: {
            load() {
                this.$http.post(`/worktasks/edit/${this.$route.params.id || ""}`)
                    .then(this.loadCompleted);
            },
            loadCompleted(result) {
                this.task = result.body;
            },
            back() {
                this.$router.go(-1);
            },
            save() {
                var component = this;

                this.$http.post("/worktasks/save", this.task)
                    .then(function (response) {
                        Cookies.set('isSaved', `Work task #${response.body.id} Saved`, { expires: 7, path: '/' });
                        this.$router.push({ path: `/worktasks` });
                    })
                    .catch(x => {
                        component.errors = x.body.errors
                    });
            }
        }
    }
</script>