<template>
    <header class="header">
      <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQill6dEC0mHGVaob1VliASRtz2S01DLBXTzmyOIzKXMelugikYDg">
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
  .header {
    display: grid;
    grid-auto-flow: column;
    align-items: center;
    padding-right: 1em;
    background-color: var(--black-olive);
    color: var(--carmine-pink);
  }
   img {
    justify-content: left;
  }
  .login {
    justify-self: end;
  }
</style>
