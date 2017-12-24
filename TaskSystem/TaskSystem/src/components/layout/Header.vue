<template>
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
        <div class="container nav-bar-container">
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">
                    <template v-for="item in allRoutes">
                        <li v-bind:class="{ active: item.active }" class="nav-item ">
                            <a class="nav-link" v-on:click="goToLink" v-bind:href="item.path">
                                {{ item.name }}
                            </a>
                        </li>
                    </template>
                </ul>
            </div>
            <div class="navbar-brand" href="#">
                <div class="dropdown">
                    <button class="btn btn-secondary dropdown-toggle"
                            type="button"
                            id="dropdownMenuButton"
                            data-toggle="dropdown"
                            aria-haspopup="true"
                            aria-expanded="false">
                        <i class="fa fa-user"></i>
                        <span>Admin</span>
                    </button>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton">
                        <a class="dropdown-item" href="#">
                            <i class="fa fa-id-card" aria-hidden="true"></i>
                            Profile
                        </a>
                        <a class="dropdown-item" v-on:click="logout" href="javascript:;">
                            <i class="fa fa-sign-out" aria-hidden="true"></i>
                            Logout
                        </a>
                    </div>
                </div>
            </div>
            <button class="navbar-toggler" type="button"
                    data-toggle="collapse"
                    data-target="#navbarResponsive"
                    aria-controls="navbarResponsive"
                    aria-expanded="false"
                    aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

        </div>
    </nav>
</template>

<script>
    export default {
        methods: {
            logout() {
                localStorage.authToken = "";
                this.$router.push({ path: '/login' })
            },
            goToLink(event) {
                //
               // setTimeout(() => { this.$router.go() }, 10);
                this.$router.push({ path: $(event.target).attr("href") })
                event.preventDefault();
                return false;
            }
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
        mounted() {
        }
    }
</script>
