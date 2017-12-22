<template>
    <div class="fill-remaining-height" id="app">
        <!-- Navigation -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
            <div class="container nav-bar-container">
 
                <div class="navbar-brand" href="#">
                    Tasks System
                </div>

            </div>
        </nav>
        <!-- Page Content -->
        <div class="container-fluid fill-remaining-height">
            <slot></slot>
        </div>
        <app-footer></app-footer>
    </div>
</template>

<script>
    import appFooter from "./Footer.vue"

    export default {

        components: {
            appFooter
        }

    }

</script>
