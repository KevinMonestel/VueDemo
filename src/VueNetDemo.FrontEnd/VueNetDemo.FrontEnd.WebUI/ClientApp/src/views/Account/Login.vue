<template>
    <p>Login form</p>
    <form>
        <label>UserName</label>
        <input v-model="Login.username" />
        <label>Password</label>
        <input v-model="Login.password" />
        <input v-on:click="LoginUser" type="button" value="Login"/>
        {{result}}
    </form>
</template>


<script>
    import Login from '@/models/account/login'
    import AccountService from '@/services/account/accountService'

    export default {
        name: "Login",
        data() {
            return {
                Login: new Login('', ''),
                result: null
            }
        },
        methods: {
            async LoginUser() {
                this.result = await AccountService.LoginUser(this.Login);
            }
        }
    }
</script>