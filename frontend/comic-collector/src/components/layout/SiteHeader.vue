<template>
    <header>
        <h1>Comic Collection Catalog</h1>
        <the-login v-if="showHeader" class="login"></the-login>
    </header>
</template>

<script>
import TheLogin from '@/components/login/TheLogin.vue'
export default {
  name: 'site-header',
  components: {
      TheLogin
  },
  computed: {
    showHeader() {
      const noHeaderPages = ["login"];
      return noHeaderPages.indexOf(this.$route.name) === -1;
    }
  }
}

</script>

<style>

</style>
