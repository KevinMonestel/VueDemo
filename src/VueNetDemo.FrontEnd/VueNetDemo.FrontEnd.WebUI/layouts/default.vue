<template>
  <div>
    <HeaderNav />
    <MainContent />
  </div>
</template>

<script lang="ts">
  import HeaderNav from '../components/HeaderNav.vue'
  import MainContent from '../components/MainContent.vue'

  export default{
    name: "layout",
    components: {
      HeaderNav,
      MainContent
    }
  }
</script>

<style>

</style>
