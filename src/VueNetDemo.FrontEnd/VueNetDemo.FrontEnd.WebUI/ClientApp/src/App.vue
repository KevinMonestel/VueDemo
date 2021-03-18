<template>
  <NavMenu></NavMenu>
  <router-view />
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
    #app {
      font-family: Avenir, Helvetica, Arial, sans-serif;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      text-align: center;
      color: #2c3e50;
    }
</style>