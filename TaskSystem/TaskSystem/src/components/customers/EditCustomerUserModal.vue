<template>
    <div class="edit-customer-user-modal common-modal">
        <div v-show="visible" class="modal-overlay" ></div>
        <div v-show="visible" class="modal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Edit customer user <span class="badge badge-danger" >#{{ model.id }}</span></h5>
                        <button v-on:click="cancel()" type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
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
                        <a v-on:click="ok()" href="javascript:;" class="btn btn-primary">Save customer</a>
                        <a v-on:click="cancel()" href="javascript:;"  class="btn btn-secondary" data-dismiss="modal">Cancel</a>
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
            model: { type: Object }
        },
        data() {
            return {

            }
        },
        mounted() {

        },
        methods: {
            ok() {
                if (this.okFunc)
                    this.okFunc();
                this.hide();
            },
            cancel() {
                if (this.cancelFunc)
                    this.cancelFunc();
                this.hide();
            }
        }
    }
</script>