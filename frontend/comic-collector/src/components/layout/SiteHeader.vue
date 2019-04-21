<template>
    <header class="header">
      <h1 class="speach-bubble">Comic Collection Catalog!</h1>
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

  h1 {
    font-size: 5em;
    /* font-kerning: normal;
    letter-spacing: 0.2rem; */
    margin: 0;
  }

  .speach-bubble {
    position: relative;
    z-index: 1;
    background-color: var(--isabelline);
    margin: auto;
    margin-bottom: 0.6em;
    padding: .2em 1ch;
    /* border-radius: 25%; */
  }

  .speach-bubble::before {
    content: '';
    position: absolute;
    z-index: -1;
    background-color: none;
    color: none;
    width: 0;
    height: 0;
    border-left: 60px solid transparent;
    border-top: 51px solid var(--isabelline);
    transform: rotate(-65deg);
    left: 23px;
    bottom: -40px;
  }

  .login {
    justify-self: end;
    margin-right: 8px;
  }
</style>
