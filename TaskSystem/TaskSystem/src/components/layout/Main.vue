<template>
    <div class="fill-remaining-height" id="app">
        <app-header></app-header>
        <!-- Page Content -->
        <div class="container-fluid fill-remaining-height">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h1 class="mt-5">A Bootstrap 4 Starter Template</h1>
                    <p class="lead">Complete with pre-defined file paths and responsive navigation!</p>
                    <ul class="list-unstyled">
                        <li>Bootstrap 4.0.0-beta</li>
                        <li>jQuery 3.2.1</li>
                    </ul>
                </div>
            </div>
        </div>
        <app-footer></app-footer>
    </div>
</template>


<script>
    import appServerStatus from '../server/ServerStatus.vue'
    import appHeader from '../layout/Header.vue'
    import appFooter from '../layout/Footer.vue'
    import { eventBus } from "../../main"
    import first from "../layout/First.vue"
    import second from "../layout/Second.vue"

    export default {
        components: {
            appHeader,
            appFooter,
            appServerStatus,
            first,
            second
        },
        data() {
            return {
                selectedComponent: "first",
                testString: "myteststring"
            };
        },
        methods: {
            notifyEventBus() {
                eventBus.$emit("notify");
            },
            switchComponent() {
                this.selectedComponent = this.selectedComponent == "first" ? "second" : "first";
            }
        },
        filters: {
            toUppercase: (x) => x.toUpperCase()
        }
    };
</script>
<style lang="scss">
    .inner-content {
        border: 1px solid black;
        margin: 10px !important;
    }
</style>
