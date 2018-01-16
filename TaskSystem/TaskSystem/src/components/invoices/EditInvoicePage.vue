<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">Edit invoice</h1>
        </div>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue"

    export default {
        components: {
            mainLayout
        },
        data() {
            return {
                invoice: {

                }
            };
        },
        mounted() {
            this.invoice.taskId = this.$route.params.taskId;
        }
    }
</script>