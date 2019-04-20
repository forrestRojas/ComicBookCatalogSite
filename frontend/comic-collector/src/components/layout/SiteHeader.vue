<template>
    <header class="header">
      <h1>Comic Collection Catalog!</h1>
      <the-login v-if="showHeader" class="login"></the-login>
    </header>
</template>

<script>
import TheLogin from '@/components/login/TheLogin.vue';
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
  .header {
    display: grid;
    grid-auto-flow: column;
    grid-template-columns: 1fr;
    align-items: center;
    height: min-content;
    min-width: 282.33px;
    background-color: var(--emmit-yellow);
    color: var(--carmine-pink);
  }

  .header h1 {
    font-size: 5em;
    /* font-kerning: normal;
    letter-spacing: 0.2rem; */
    margin: 0;
  }

  .login {
    justify-self: end;
    margin-right: 8px;
  }
</style>
