<template>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container">
                <a class="navbar-brand">VueNetDemo</a>
                <button class="navbar-toggler"
                        type="button"
                        data-toggle="collapse"
                        data-target=".navbar-collapse"
                        aria-label="Toggle navigation"
                        @click="toggle">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"
                     v-bind:class="{show: isExpanded}">
                    <ul class="navbar-nav flex-grow">
                        <li class="nav-item">
                            <router-link :to="{ name: 'Home' }" class="nav-link text-dark">Home</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Counter' }" class="nav-link text-dark">Counter</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'FetchData' }" class="nav-link text-dark">Fetch Data (Auth required)</router-link>
                        </li>

                        <div v-if="!currentUser" class="navbar-nav ml-auto">
                            <li class="nav-item">
                                <router-link :to="{ name: 'Register' }" class="nav-link text-dark">Register</router-link>
                            </li>
                            <li class="nav-item">
                                <router-link :to="{ name: 'Login' }" class="nav-link">Login</router-link>
                            </li>
                        </div>

                        <div v-if="currentUser" class="navbar-nav ml-auto" style="border-left: solid 1px #eee">
                            <li class="nav-item">
                                <a class="nav-link text-black-50">Hello {{currentUser.unique_name}}</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link text-dark" href="#" @click.prevent="logOut">
                                    LogOut
                                </a>
                            </li>
                        </div>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
</template>


<style scoped>

</style>

<script>
    import VueJwtDecode from "vue-jwt-decode";

    export default {
        name: "NavMenu",
        computed: {
            currentUser() {
               if(this.$store.state.auth.user){
                let decoded = VueJwtDecode.decode(this.$store.state.auth.user.token)
                return decoded;
            }
            return null;
            }
        },
        data() {
            return {
                isExpanded: false
            }
        },
        methods: {
            collapse() {
                this.isExpanded = false;
            },

            toggle() {
                this.isExpanded = !this.isExpanded;
            },
            logOut() {
                this.$store.dispatch('auth/logout');
                this.$router.push('/Account/Login');
            }
        }
    }
</script>