<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">Users page</h1>
            <hr />
            <table class="test-table table">
                <thead>
                    <tr>
                        <th>Subscriber ID</th>
                        <th>Install Location</th>
                        <th>Subscriber Name</th>
                        <th>some data</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>


        </div>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue"

    export default {
        components: {
            mainLayout
        },
        mounted() {
            $(".test-table").dataTable();
        }
    }
</script>