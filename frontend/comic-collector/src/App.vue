<template>
  <div id="app">
    <site-header></site-header>
    <site-nav></site-nav>
    <router-view />
    <site-footer></site-footer>
  </div>
</template>

<script>
import SiteHeader from './components/layout/SiteHeader.vue';
import SiteNav from './components/layout/SiteNav.vue';
import SiteFooter from './components/layout/SiteFooter.vue';

export default {
  name: 'app',
  components: {
    SiteHeader,
    SiteNav,
    SiteFooter
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
