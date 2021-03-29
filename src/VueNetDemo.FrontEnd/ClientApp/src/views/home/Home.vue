<template>
    <div class="hello">
        <p>VueNetDemo</p>
    </div>

    <div v-if="!this.$store.state.auth.user">
        <div class="form-group">
            <div class="alert alert-danger" role="alert">You are not logged!</div>
        </div>
    </div>

    <div v-if="this.$store.state.auth.user">
        <hr />
        User info (state):
        <code>
            <p>Token:  {{JSON.stringify(this.$store.state.auth.user.token)}}</p>
        </code>
    </div>
</template>

<script>
    export default {
        name: 'Home',
        data(){
            return{
                
            }
        }
    }
</script>

<style scoped>
    .hello {
        text-align: center;
    }

    code{
        color: #333;
    }
</style>
