<template>
    <div class="edit-customer-user-modal common-modal">
        <div v-show="visible" class="modal-overlay"></div>
        <div v-show="visible" class="modal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">
                        <span v-show="entityId > 0" >Edit</span>
                        <span v-show="!entityId" >Create</span>
                        customer user <span  v-show="!!entityId" class="badge badge-danger">#{{ entityId }}</span></h5>
                        <button v-on:click="cancel()" type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
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
                                <label>Title</label>
                                <input type="text" class="form-control" v-model="model.title" placeholder="Title" value="">
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-12">
                                <label>Name</label>
                                <input type="text" class="form-control" v-model="model.name" placeholder="Name" value="">
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-12">
                                <label>Email</label>
                                <input type="text" class="form-control" v-model="model.email" placeholder="Email" value="">
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-12">
                                <label>Phone</label>
                                <input type="text" class="form-control" v-model="model.phone" placeholder="Phone" value="">
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a v-on:click="ok()" href="javascript:;" class="btn btn-primary">Save customer user</a>
                        <a v-on:click="cancel()" href="javascript:;" class="btn btn-secondary" data-dismiss="modal">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
    import modalBase from "./../common/ModalBase.vue"
    
    export default {
        extends: modalBase,
        props: {
            entityId: { type: Number },
            customerId: {  },
        },
        watch: {
            visible(newVal) {
                if (newVal == false)
                    this.model = {};
                if (newVal == true)
                    this.load();
            }
        },
        data: () => ({
            model: {}
        }),
        methods: {
            load(id) {
                this.blockUI({
                    message: 'Please wait...'
                });
                // debugger;
                this.$http.post(`/customers/editcustomeruser/${this.entityId}`)
                    .then(this.loadCompleted);
            },
            loadCompleted(result) {
                this.model = result.body;
                this.unblockUI();
            },
            ok() {
                let component = this;
                this.model.customerId = this.customerId;
                this.$http.post(`/customers/savecustomeruser`,
                    this.model)
                    .then((x) => {
                        toastr.info("Customer user saved", "Success");
                        component.okFunc(x.body);
                        component.hide();
                    }).catch(x => {
                        debugger;
                        component.errors = x.body.errors;
                    });
            },
            cancel() {
                if (this.cancelFunc)
                    this.cancelFunc();
                this.hide();
            }
        }
    }
</script>