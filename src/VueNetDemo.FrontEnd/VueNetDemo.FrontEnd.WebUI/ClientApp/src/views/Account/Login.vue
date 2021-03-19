<template>
    <p>Login form</p>
    <form name="form" @submit.prevent="handleLogin">
        <div class="form-group">
            <label for="username">Username</label>
            <input v-model="Login.username"
                   type="text"
                   class="form-control"
                   name="username" />
            <!--<div v-if="errors.has('username')"
                 class="alert alert-danger"
                 role="alert">Username is required!</div>-->
        </div>
        <div class="form-group">
            <label for="password">Password</label>
            <input v-model="Login.password"
                   
                   type="password"
                   class="form-control"
                   name="password" />
            <!--<div v-if="errors.has('password')"
                 class="alert alert-danger"
                 role="alert">Password is required!</div>-->
        </div>
        <div class="form-group">
            <button class="btn btn-primary btn-block">
                <span v-show="loading" class="spinner-border spinner-border-sm"></span>

                <span>Login</span>
            </button>
        </div>
        <div class="form-group">
            <div v-if="message" class="alert alert-danger" role="alert">{{message}}</div>
        </div>
    </form>
</template>


<script>
    import Login from '@/models/account/login'

    export default {
        name: "Login",
        data() {
            return {
                Login: new Login('', ''),
                loading: false,
                message: ''
            };
        },
        methods: {
            handleLogin() {
                this.loading = true;
                //this.$validator.validateAll().then(isValid => {
                //    if (!isValid) {
                //        this.loading = false;
                //        return;
                //    }

                    if (this.Login.username && this.Login.password) {
                        this.$store.dispatch('auth/login', this.Login).then(
                            (result) => {
                                if (result.successfull) {
                                    this.$router.push('/');
                                } else {
                                    this.message = result.message;
                                    this.loading = false;
                                }
                            },
                            error => {
                                this.loading = false;
                                this.message =
                                    (error.response && error.response.data && error.response.data.message) ||
                                    error.message ||
                                    error.toString();
                            }
                        );
                    }
 /*               });*/
            }
        },
        computed: {
            loggedIn() {
                return this.$store.state.auth.status.loggedIn;
            }
        },
        created() {
            if (this.loggedIn) {
                this.$router.push('/');
            }
        }
    }
</script>