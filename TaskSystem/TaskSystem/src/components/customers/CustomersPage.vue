<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">Customers</h1>
        </div>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue"
    import dataTable from "./../common/DataTable.vue"
    import confirmModal from "./../common/ConfirmModal.vue"
    import pageBase from "./../common/PageBase.vue"

    export default {
        extends: pageBase,
        components: {
            mainLayout,
            dataTable,
            confirmModal
        }
    }
</script>