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
                <div>
                    <label>
                        <label class="switch">
                            <input v-model="task.isTemporaryTask" type="checkbox">
                            <span class="slider round"></span>
                        </label>
                        <span class="mt-1 d-inline-block float-right ml-2" >Is Temporary Task</span>
                    </label>
                </div>
                <div class="row form-group">
                    <div class="col-md-6">
                        <label>Priority</label>
                        <div>
                            <template v-for="priority in task.avaliablePriorities">
                                <label v-bind:class="{ 'active' : priority.key == task.priority }" class="btn btn-secondary ">
                                    <input type="radio" v-bind:value="priority.key" name="priority" v-model="task.priority">{{ priority.value }}
                                </label>
                            </template>
                            <div class="btn-group btn-group-toggle" data-toggle="buttons">

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label>Status</label>
                        <select v-model="task.status" class="form-control">
                            <option v-for="item in task.avaliableStatuses" v-bind:value="item.key">{{ item.value }}</option>
                        </select>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-4">
                        <label>Customer</label>
                        <select2 v-bind:options="customerOptions" v-bind:value.sync="task.customerId">
                        </select2>
                    </div>
                    <div class="col-md-4">
                        <label>Customer user</label>
                        <select2 v-bind:options="customerUserOptions" v-bind:value.sync="task.customerUserId">

                        </select2>
                    </div>
                    <div class="col-md-4">
                        <label>Assigned Technician</label>
                        <select2 v-bind:options="{ data: task.avaliableUsers }" v-bind:value.sync="task.userId"></select2>
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


            </form>

            <div v-show="task.id > 0" class="sub-entities">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="tab" href="#tasknotes" role="tab">Notes</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#documents" role="tab">Documents</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#invoices" role="tab">Invoices</a>
                    </li>
                </ul>

                <!-- Tab panes -->
                <div class="tab-content">
                    <div class="tab-pane active" id="tasknotes" role="tabpanel">
                        <div class="row">
                            <div class="col-md-12">
                                <br />
                                <summer-note v-bind:value.sync="newNoteText"></summer-note>
                                <br />
                                <a v-on:click="addNote" class="pull-right btn btn-primary" href="javascript:;">Add Note</a>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12 notes-list">
                                <template v-for="note in task.workTaskNoteItems">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong>{{ note.userName }}</strong>
                                            <em>{{ note.dateAdded }}</em>
                                            <a v-on:click="deleteNote(note.id)" class="pull-right btn btn-danger btn-xs delete-note" href="javascript:;">
                                                <i class="fa fa-times"></i>
                                                delete
                                            </a>
                                        </div>
                                        <div v-html="note.note" class="card-block"></div>
                                    </div>
                                </template>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane js" id="documents" role="tabpanel">
                        <form method="post" action="https://css-tricks.com/examples/DragAndDropFileUploading//?"
                              v-bind:class="{ 'is-uploading' : isUploading }"
                              enctype="multipart/form-data"
                              novalidate class="box has-advanced-upload">
                            <div class="box__input">
                                <svg class="box__icon" xmlns="http://www.w3.org/2000/svg" width="50" height="43" viewBox="0 0 50 43">
                                    <path d="M48.4 26.5c-.9 0-1.7.7-1.7 1.7v11.6h-43.3v-11.6c0-.9-.7-1.7-1.7-1.7s-1.7.7-1.7 1.7v13.2c0 .9.7 1.7 1.7 1.7h46.7c.9 0 1.7-.7 1.7-1.7v-13.2c0-1-.7-1.7-1.7-1.7zm-24.5 6.1c.3.3.8.5 1.2.5.4 0 .9-.2 1.2-.5l10-11.6c.7-.7.7-1.7 0-2.4s-1.7-.7-2.4 0l-7.1 8.3v-25.3c0-.9-.7-1.7-1.7-1.7s-1.7.7-1.7 1.7v25.3l-7.1-8.3c-.7-.7-1.7-.7-2.4 0s-.7 1.7 0 2.4l10 11.6z" />
                                </svg>
                                <input v-on:change="fileSelected" type="file" name="files[]" id="work-task-edit-documents" class="box__file" />
                                <label for="file"><strong>Choose a file</strong><span class="box__dragndrop"> or drag it here</span>.</label>
                                <button type="submit" class="box__button">Upload</button>
                            </div>
                            <div class="box__uploading">Uploading&hellip;</div>
                            <div class="box__success">Done! <a href="https://css-tricks.com/examples/DragAndDropFileUploading//?" class="box__restart" role="button">Upload more?</a></div>
                            <div class="box__error">Error! <span></span>. <a href="https://css-tricks.com/examples/DragAndDropFileUploading//?" class="box__restart" role="button">Try again!</a></div>
                        </form>
                        <div v-if="!!task.documents && task.documents.length > 0">
                            <br />
                            <h4>Uploaded documents</h4>
                            <div>
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th>Id</th>
                                            <th>File Name</th>
                                            <th>Uploaded by</th>
                                            <th>Uploaded Date</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="document in task.documents">
                                            <th>{{ document.id }}</th>
                                            <th><a target="_blank" v-bind:href="generateUrl(document)">{{ document.name }}</a></th>
                                            <th>{{ document.userName }}</th>
                                            <th>{{ document.uploadedDate }}</th>
                                            <th><a href="javascript:;" v-on:click="deleteDocument(document)" class="btn btn-danger btn-xs"><i class="fa fa-times"></i> Delete</a></th>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div id="invoices" class="tab-pane">
                        <h4>Invoices of task</h4>
                        <a href="javascript:;" v-on:click="createInvoice" class="btn btn-primary">Create invoice</a>
                        <div>
                            <div class="list-group">
                                <div v-for="invoice in task.invoices" href="#" class="list-group-item list-group-item-action flex-column align-items-start invoice-item">
                                    <div class="d-flex w-100 justify-content-between">
                                        <h5 class="mb-1"><a v-bind:href="'/invoices/' + invoice.id">Invoice #{{ invoice.id }}</a></h5>

                                        <div class="right-actions">
                                            <small>{{ invoice.created }}</small>
                                            <br />
                                            <a class="btn btn-danger btn-xs" v-on:click="deleteInvoice(invoice)" href="javascript:;">
                                                <i class="fa fa-times"></i>
                                                Delete
                                            </a>
                                        </div>
                                    </div>
                                    <p class="mb-1">{{ invoice.remarks }}</p>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
        <confirm-modal ref="confirmDeleteNoteModal" title="Are you sure?">
            <span>Are you really want to delete this note?</span>
        </confirm-modal>
        <confirm-modal ref="confirmDeleteFileModal" title="Are you sure?">
            <span>Are you really want to delete this document?</span>
        </confirm-modal>
        <confirm-modal ref="invoiceDeleteModal" title="Are you sure?">
            <span>Are you really want to delete this invoice?</span>
        </confirm-modal>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue";
    import uiBase from "./../common/UiBase.vue"
    import confirmModal from "./../common/ConfirmModal.vue"

    export default {
        extends: uiBase,
        components: {
            mainLayout,
            confirmModal
        },
        data() {
            return {
                newNoteText: "",
                isUploading: false,
                task: {

                }
            };
        },
        computed: {
            customerOptions() {
                return {
                    ajax: {
                        url: window.appRoot + '/worktasks/SearchCustomer',
                        type: "post",
                        dataType: "json"
                    },
                    data: this.task.avaliableCustomers
                };
            },
            customerUserOptions() {
                return {
                    ajax: {
                        url: window.appRoot + '/worktasks/SearchCustomerUsers/' + (this.task.customerId || ""),
                        type: "post",
                        dataType: "json"
                    },
                    data: this.task.avaliableCustomerUsers
                };
            }
        },
        mounted() {
            this.load();
        },
        watch: {
            'task.customerId'(newVal, oldVal) {
                if (newVal != oldVal && !!oldVal) {
                    this.task.customerUserId = null;
                    this.task.avaliableCustomerUsers = [];
                }
            }
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
            generateUrl(doc) {
                return window.appRoot + "/worktasks/downloaddocument/?path=" + encodeURI(doc.path);
            },
            createInvoice() {
                this.$router.push({ path: `/invoices/task${this.task.id}/add` })
            },
            deleteInvoice(invoice) {
                let component = this;

                this.$refs.invoiceDeleteModal.show(function () {
                    component.blockUI({
                        message: 'Deletion, please wait...'
                    });
                    component.$http.post("/invoices/delete/" + invoice.id)
                        .then(function (response) {
                            component.unblockUI();
                            toastr.info("Invoice deleted", "Success");
                            component.task.invoices = component.task.invoices.filter(x => x.id != invoice.id);
                        })
                        .catch(x => {
                            alert("errors");
                        });
                });
            },
            deleteDocument(doc) {
                let component = this;

                this.$refs.confirmDeleteFileModal.show(function () {
                    component.blockUI({
                        message: 'Deletion, please wait...'
                    });
                    component.$http.post("/worktasks/deletedocument/" + doc.id)
                        .then(function (response) {
                            component.unblockUI();
                            toastr.info("File deleted", "Success");
                            component.task.documents = component.task.documents.filter(x => x.id != doc.id);
                        })
                        .catch(x => {
                            alert("errors");
                        });
                });
            },
            fileSelected() {
                let component = this;
                var xhr = new XMLHttpRequest();
                var fd = new FormData();
                fd.append("file", document.getElementById('work-task-edit-documents').files[0]);
                xhr.open("POST", window.appRoot + "/WorkTasks/UploadDocument/" + this.task.id, true);
                xhr.setRequestHeader("Authorization", `Bearer ${localStorage.authToken}`);
                xhr.send(fd);
                xhr.addEventListener("load", function (event) {
                    component.task.documents.push(JSON.parse(event.target.response));
                }, false);
            },
            save() {
                let component = this;
                this.$http.post("/worktasks/save", this.task)
                    .then(function (response) {
                        Cookies.set('isSaved', `Customer #${response.body.id} Saved`, { expires: 7, path: '/' });
                        component.errors = [];
                        location.href = `/WorkTasks/${response.body.id}`;
                    })
                    .catch(x => {
                        component.errors = x.body.errors
                    });
            },
            addNote() {
                if (!this.newNoteText) {
                    toastr.error("You must specify note", "Error");
                    return;
                }

                this.$http.post("/worktasks/AddNote", { note: this.newNoteText, workTaskId: this.$route.params.id })
                    .then(x => { this.newNoteText = ""; this.task.workTaskNoteItems.push(x.body); });
            },
            deleteNote(id) {
                let component = this;
                this.$refs.confirmDeleteNoteModal.show(function () {
                    console.log("delete");
                    component.blockUI({
                        message: 'Deletion, please wait...'
                    });
                    component.$http.post("/worktasks/deletenote/" + id)
                        .then(x => {
                            component.unblockUI();
                            component.task.workTaskNoteItems = component.task.workTaskNoteItems.filter(x => x.id != id);
                        })
                });
            }
        }
    }
</script>