<template>
 <div class="h-screen min-h-screen max-h-screen bg-gray-200 flex justify-center items-center p-4">
    <div class="bg-white shadow w-full p-4 rounded shadow-2xl text-gray-700 sm:w-96">
        <div class="flex justify-between">
            <NuxtLink to="/" class="text-sm text-blue-400">Back to the home</NuxtLink>
            <img src="https://www.ns-logo.com/wp-content/uploads/2020/07/logo-icon-png-8.png" alt="" class="w-8">
        </div>
        
        <p class="text-center pb-2 text-3xl">Welcome</p>
        
        <form class="my-5" @submit.prevent="LoginAction">
            <div class="pb-5 text-sm text-center">
                <p>You don´t have an account? <a href="#" class="text-blue-500">Register now!</a></p>
            </div>

            <div v-if="loginMessage" class="pb-5 text-sm text-center">
                <p class="bg-red-200 text-red-900 py-2 shadow">{{loginMessage}}</p>
            </div>
            
            <div class="pb-5">
                <input v-model="loginModel.username" type="text" class="block w-full p-2 rounded shadow bg-gray-100 focus:ring-2 focus:ring-blue-500 focus:border-transparent focus:outline-none" placeholder="Username or email">
            </div>

            <div class="pb-5">
                <input v-model="loginModel.password" type="password" class="block w-full p-2 rounded shadow bg-gray-100 focus:ring-2 focus:ring-blue-500 focus:border-transparent focus:outline-none" placeholder="Password">
            </div>
            
            <div class="pb-5">
                <input type="checkbox">
                <label for="">Remember password</label>
            </div>

            <div class="pb-5 text-right text-sm">
                <a href="#" class="text-blue-500">Forgot your password?</a>
            </div>

            <button type="submit" class="bg-blue-500 p-2 w-full text-white rounded">Sign In</button>
        </form>
    </div>
</div>
</template>

<script>
    import LoginModel from '../../models/account/login.model';

    export default {
        layout: 'login',

        data(){
            return{
                loginModel: new LoginModel('',''),
                loginMessage: null
            }
        },

        middleware: 'guest',

        methods: {
            async LoginAction(){
                try {
                    let handleSuccess = response => {
                        this.$router.push('/');
                    }

                    let handleFailure = error => {
                        if(error.response){
                            this.loginMessage = error.response.data.error;
                        }else{
                            this.loginMessage = error;
                        }
                    }

                    this.$auth.loginWith('local', { data: this.loginModel }).then(handleSuccess).catch(handleFailure);

                } catch (err) {
                    console.log(err)
                }
            }
        }
    }
</script>

<style scoped>
    
</style>