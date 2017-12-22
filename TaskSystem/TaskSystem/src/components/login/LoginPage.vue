<template>
    <login-layout>
        <div class="row">
            <form class="form-signin">
                <h2 class="form-signin-heading">
                    <i class="fa fa-id-card-o" aria-hidden="true"></i>
                    Please sign in
                </h2>

                <div v-show="hasLoginErrors" class="alert alert-danger" role="alert">
                    <strong>Errors!</strong>
                    <span>{{ loginErrorsText }}</span>
                </div>

                <input type="text" class="form-control" placeholder="Email address" autofocus>

                <input type="password" class="form-control user-password-input" placeholder="Password">

                <div class="checkbox">
                    <label>
                        <input type="checkbox" value="remember-me"> Remember me
                    </label>
                </div>
                <span v-on:click="tryLogin" class="btn btn-lg btn-primary btn-block">
                    <i class="fa fa-sign-in" aria-hidden="true"></i>
                    Sign in
                </span>
            </form>

        </div>
    </login-layout>
</template>

<script>
    import loginLayout from "./../layout/LoginLayout.vue"

    export default {
        components: {
            loginLayout
        },
        data() {
            return {
                loginErrorsText: "",
                email: "",
                password: "",
            }
        },
        computed: {
            hasLoginErrors() {
                return !!this.loginErrorsText
            }
        },
        methods: {
            tryLogin() {
                let component = this;

                this.$http.post(window.appRoot + "/account/requesttoken",
                    JSON.stringify({ Username: this.email, Password: this.password }),
                    {
                        headers: { 'Content-Type': "application/json" },
                        // responseType: "json"
                    })
                    .then(x => {

                    })
                    .catch(x => {
                        component.loginErrorsText = x.body;
                    });
            }
        },
        mounted() {
            // debugger;
        }
    }
</script>
