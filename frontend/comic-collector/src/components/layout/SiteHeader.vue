<template>
    <header>
        <h1>Comic Collection Catalog</h1>
        <the-login></the-login>
    </header>
</template>

<script>
import TheLogin from '@/components/login/TheLogin.vue'
export default {
  name: 'site-header',
  components: {
      TheLogin
  }

}
</script>

<style>

</style>
