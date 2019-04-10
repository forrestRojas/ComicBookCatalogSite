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
    display: flex;
    align-items: space-between;
    background-color: var(--black-olive);
    color: var(--carmine-pink);
    justify-content: center;
    padding-left: 300px;
  }
   img {
    justify-content: left;
  }
  .login {
    align-self: flex-end;
  }
</style>
