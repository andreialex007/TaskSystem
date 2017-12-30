<template>
    <div class="confirm-modal">
        <div v-show="visible" class="modal-overlay" ></div>
        <div v-show="visible" class="modal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <template v-if="!!title">
                            <h5 class="modal-title">{{ title }}</h5>
                        </template>
                        <button v-on:click="hide()" type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <slot></slot>
                    </div>
                    <div class="modal-footer">
                        <a v-on:click="ok()" href="javascript:;" class="btn btn-primary">{{ saveText }}</a>
                        <a v-on:click="cancel()" href="javascript:;"  class="btn btn-secondary" data-dismiss="modal">{{ cancelText }}</a>
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
            title: { type: String },
            saveText: { type: String, default: "Ok" },
            cancelText: { type: String, default: "Cancel" }
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