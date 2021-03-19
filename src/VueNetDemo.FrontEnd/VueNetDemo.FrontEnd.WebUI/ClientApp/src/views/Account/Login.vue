<template>
    <div class="col-md-12">
        <div class="card card-container">
            <div class="form-group">
                <div v-if="message" class="alert alert-danger" role="alert">{{message}}</div>
            </div>

            <h1 class="text-center">Login form</h1>

            <Form name="form" @submit="handleLogin" :validation-schema="schema">
                <div class="form-group">
                    <label for="username">Username</label>
                    <Field v-model="Login.username"
                           type="text"
                           class="form-control"
                           name="username" />
                    <ErrorMessage name="username" />
                </div>

                <div class="form-group">
                    <label for="password">Password</label>
                    <Field v-model="Login.password"
                           type="password"
                           class="form-control"
                           name="password" />
                    <ErrorMessage name="password" />
                </div>

                <div class="form-group">
                    <button class="btn btn-primary btn-block">
                        <span v-show="loading" class="spinner-border spinner-border-sm"></span>
                        <span>Login</span>
                    </button>
                </div>
            </Form>
        </div>
    </div>
</template>


<script>
    import Login from '@/models/account/login'
    import { Form, Field, ErrorMessage } from 'vee-validate';
    import * as yup from 'yup';

    export default {
        name: "Login",
        components: {
            Form,
            Field,
            ErrorMessage
        },
        data() {
            const schema = yup.object({
                username: yup.string().required(),
                password: yup.string().required().min(8),
            });

            return {
                Login: new Login('', ''),
                loading: false,
                message: '',
                schema
            };
        },
        methods: {
            handleLogin() {
                this.loading = true;
                this.message = null;

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


<style scoped>
    span[role="alert"]{
        color: red;
    }

    label {
        display: block;
        margin-top: 10px;
    }

    .card-container.card {
        max-width: 350px !important;
        padding: 40px 40px;
    }

    .card {
        background-color: #f7f7f7;
        padding: 20px 25px 30px;
        margin: 0 auto 25px;
        margin-top: 50px;
        -moz-border-radius: 2px;
        -webkit-border-radius: 2px;
        border-radius: 2px;
        -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
    }

    .profile-img-card {
        width: 96px;
        height: 96px;
        margin: 0 auto 10px;
        display: block;
        -moz-border-radius: 50%;
        -webkit-border-radius: 50%;
        border-radius: 50%;
    }
</style>