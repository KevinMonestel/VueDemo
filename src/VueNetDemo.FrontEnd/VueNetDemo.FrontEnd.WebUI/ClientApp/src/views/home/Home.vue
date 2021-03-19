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
            <p>Token (Expires in):  {{JSON.stringify(this.$store.state.auth.user.expiresIn)}}</p>
            <p>Email:  {{JSON.stringify(this.$store.state.auth.user.claims.find(x => x.type == 'email').value)}}</p>
            <p>UserName:  {{JSON.stringify(this.$store.state.auth.user.claims.find(x => x.type == 'unique_name').value)}}</p>
            <p>Id:  {{JSON.stringify(this.$store.state.auth.user.claims.find(x => x.type == 'nameid').value)}}</p>
            <p>Roles:  {{JSON.stringify(this.$store.state.auth.user.claims.filter(x => x.type == 'role').map(function(a) {return a.value;}))}}</p>

        </code>
    </div>
</template>

<script>
    export default {
        name: 'Home'
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
