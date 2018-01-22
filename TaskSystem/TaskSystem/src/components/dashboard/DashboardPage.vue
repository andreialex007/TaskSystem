<template>
    <main-layout>
        <div class="col-lg-12">
            <h1 class="mt-5">Please select section</h1>
            <ul>
                <template v-for="item in allRoutes">
                    <li v-bind:class="{ active: item.active }" class="nav-item ">
                        <a class="nav-link" v-on:click="goToLink" v-bind:href="item.path">
                            {{ item.name }}
                        </a>
                    </li>
                </template>
            </ul>
        </div>
    </main-layout>
</template>


<script>
    import mainLayout from "./../layout/MainLayout.vue"

    export default {
        components: {
            mainLayout
        },
        computed: {
            allRoutes() {
                let allRoutes = window.mainRoutes;
                let routesToDraw = [];
                for (let route of allRoutes) {
                    let clone = { ...route }
                    if (route.exact) {
                        clone.active = route.path === location.pathname;
                    } else {
                        clone.active = location.pathname.toLowerCase().startsWith(route.path.toLowerCase());
                    }
                    routesToDraw.push(clone);
                }
                return routesToDraw;
            }
        },
        methods: {
            testAccess() {

                this.$http.get("/values")
                    .then(x => { debugger; });
            },
            goToLink(event) {
                //
                // setTimeout(() => { this.$router.go() }, 10);
                this.$router.push({ path: $(event.target).attr("href") })
                event.preventDefault();
                return false;
            }
        }
    }
</script>