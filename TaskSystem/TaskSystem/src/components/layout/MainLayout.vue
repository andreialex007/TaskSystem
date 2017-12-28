<template>
    <div class="fill-remaining-height" id="app">
        <app-header></app-header>
        <!-- Page Content -->
        <div class="container-fluid fill-remaining-height">
            <slot></slot>
        </div>

        <app-footer></app-footer>
    </div>
</template>


<script>

    import appHeader from './Header.vue'
    import appFooter from './Footer.vue'


    export default {
        components: {
            appHeader,
            appFooter
        }
    }

</script>