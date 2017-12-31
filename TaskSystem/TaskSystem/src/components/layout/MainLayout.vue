<template>
    <div class="root" >
        <main role="main" class="container-fluid">
            <app-header></app-header>
            <slot></slot>
        </main>
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