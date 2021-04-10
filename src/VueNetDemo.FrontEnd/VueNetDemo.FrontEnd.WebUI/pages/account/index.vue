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