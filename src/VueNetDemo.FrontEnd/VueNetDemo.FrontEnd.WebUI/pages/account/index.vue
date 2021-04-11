<template>
    <div class="pt-20">
         <p>
          <strong>Username:</strong>
          {{ loggedInUser.userName }}
        </p>
        <p>
          <strong>Email:</strong>
          {{ loggedInUser.email }}
        </p>
        <p>
          <strong>Admin:</strong>
          {{ this.$auth.hasScope('Admin') }}
        </p>
        <p>
          <strong>Customer:</strong>
           {{ this.$auth.hasScope('Customer') }}
        </p>
        <p>
          <strong>Other:</strong>
           {{ this.$auth.hasScope('Other') }}
        </p>
        {{loggedInUser}}
    </div>
</template>

<script>
    import { mapGetters } from 'vuex'

    export default {
        name: 'account',

        computed: {
            ...mapGetters(['loggedInUser'])
        }
    }
</script>

<style lang="scss" scoped>

</style>