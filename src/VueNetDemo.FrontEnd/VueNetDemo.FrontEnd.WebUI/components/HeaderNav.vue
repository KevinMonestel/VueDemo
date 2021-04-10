<template>
    <header class="shadow-md flex flex-col py-3 px-5 bg-white md:fixed md:w-full md:px-20 md:flex-row">
        <div class="flex justify-between items-center">
            <NuxtLink to="/">
                <img src="https://www.ns-logo.com/wp-content/uploads/2020/07/logo-icon-png-8.png" alt="logo" class="w-10">
            </NuxtLink>
            <button class="block md:hidden" id="toggleMenuButton">Menú</button>
        </div>
        <nav class="hidden transition delay-75 md:block md:flex-grow pt-5 md:pt-0" id="navMenu">
            <ul class="flex flex-col md:flex-row md:justify-end md:items-center md:h-full">
                <li class="d-block hover:bg-blue-100 px-2 py-1 transition delay-75 md:rounded md:mr-2">
                    <NuxtLink to="/">Home</NuxtLink>
                </li>
                
                <li class="hover:bg-green-100 px-2 py-1 transition delay-75 md:rounded md:mr-2">
                    <NuxtLink to="/account/requiredLogin">Required LogIn Test</NuxtLink>
                </li>

                <li v-if="!this.$auth.loggedIn" class="md:mr-2 text-center mb-2 md:mb-0">
                    <NuxtLink class="rounded-xl px-3 py-1 text-white bg-green-500 border-2 border-green-500" to="account/login">Log In</NuxtLink>
                </li>

                <li  v-if="!this.$auth.loggedIn" class="md:mr-2 text-center">
                    <button class="rounded-xl px-3 py-1 text-green-500 border-2 border-green-500">Sign Up</button>
                </li>

                <li  v-if="this.$auth.loggedIn" class="hover:bg-red-100 px-2 py-1 mb-2 transition delay-75 md:rounded md:mr-2 md:mb-0 text-gray-500">
                    <NuxtLink to="/account">Hello {{this.$auth.user.email}}</NuxtLink>
                </li>
                
                <li  v-if="this.$auth.loggedIn" class="hover:bg-green-100 px-2 py-1 mb-2 transition delay-75 md:rounded md:mr-2 md:mb-0 text-gray-500">
                    <button v-on:click="LogOutAction()">Log out</button>
                </li>
            </ul>
        </nav>
    </header>
</template>

<script>
    export default {
        name: 'HeaderNav',

        methods: {
            async LogOutAction(){
                await this.$auth.logout();
            }
        }
    }
</script>

<style scoped>

</style>