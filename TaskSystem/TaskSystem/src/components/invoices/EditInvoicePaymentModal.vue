<template>
    <div class="edit-invoice-payment-modal common-modal">
        <div v-show="visible" class="modal-overlay"></div>
        <div v-show="visible" class="modal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">
                            <span v-show="model.id > 0">Edit</span>
                            <span v-show="!model.id">Create</span>
                            invoice payment <span v-show="!!model.id" class="badge badge-danger">#{{ model.id }}</span>
                        </h5>
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
                                <label>Payment date</label>
                                <date-picker v-bind:value.sync="model.paymentDate"></date-picker>
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-12">
                                <label>Payment type (required)</label>
                                <select v-model="model.paymentType" class="form-control">
                                    <template v-for="type in paymentTypes">
                                        <option v-bind:value="type.key">{{ type.value }}</option>
                                    </template>
                                </select>
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-12">
                                <label>Amount</label>
                                <input type="number" class="form-control" v-model="model.amount" placeholder="Amount (required)" value="">
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a v-on:click="ok()" href="javascript:;" class="btn btn-primary">Save</a>
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
            data: { type: Object },
            paymentTypes: { type: Array }
        },
        watch: {
            visible(newVal) {
                if (newVal == false)
                    this.model = {};
                if (newVal == true) {
                    this.model = { ...this.data };
                }
            }
        },
        data: () => ({
            model: {},
        }),
        methods: {
            ok() {
                let component = this;
                component.blockUI({
                    message: 'Saving, please wait...'
                });

                this.model.invoiceId = this.$route.params.id;

                this.$http.post(`/invoices/savepayment`,
                    this.model)
                    .then((x) => {
                        component.unblockUI();
                        toastr.info("saved", "Success");
                        component.okFunc(x.body);
                        component.hide();
                    }).catch(x => {
                        component.unblockUI();
                        component.errors = x.body.errors;
                    });
            },
            cancel() {
                this.model = {};
                if (this.cancelFunc)
                    this.cancelFunc();
                this.hide();
            }
        }
    }
</script>