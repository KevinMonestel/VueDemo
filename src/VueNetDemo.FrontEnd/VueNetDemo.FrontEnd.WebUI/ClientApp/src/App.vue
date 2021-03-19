<template>
  <NavMenu></NavMenu>
  <div class="container">
      <router-view />
  </div>
</template>

<script>
    import NavMenu from './components/layout/NavMenu.vue'

    export default {
      name: 'App',
      components: {
          NavMenu
      }
    }
</script>

<style>

</style>