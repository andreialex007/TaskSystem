<template>
    <confirm-modal ref="confirmModal" title="Are you sure?">
        <span>This is a test content</span>
    </confirm-modal>

</template>

<script>
    import confirmModal from "./../common/ConfirmModal.vue" 

    export default {
        components: {
            confirmModal
        },
        data() {
            return {
                modal: { visible: true }
            }
        }
    }
</script>