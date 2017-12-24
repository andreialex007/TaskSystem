<template>
    <main-layout>
        <div class="col-lg-12 text-center">
            <h1 class="mt-5">A Bootstrap 4 Starter Template</h1>
            <p class="lead">Complete with pre-defined file paths and responsive navigation!</p>
            <ul class="list-unstyled">
                <li>Bootstrap 4.0.0-beta</li>
                <li>jQuery 3.2.1</li>
            </ul>
            <span v-on:click="testAccess" class="btn btn-primary">test access</span>
        </div>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue"

    export default {
        components: {
            mainLayout
        },
        methods: {
            testAccess() {

                this.$http.get("/values")
                    .then(x => {
                        debugger;
                    })
                    .catch(x => {
                        component.loginErrorsText = x.body.allErrors;
                    });
            }
        }
    }
</script>