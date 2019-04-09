<template>
  <div id="app">
    <site-header v-if="showHeader"></site-header>
    <!-- <site-nav></site-nav> -->
    <router-view />
    <!-- <site-footer></site-footer> -->
  </div>
</template>

<script>
import SiteHeader from './components/layout/SiteHeader.vue';
// import SiteNav from './components/layout/SiteNav.vue';
// import SiteFooter from './components/layout/SiteFooter.vue';

export default {
  name: 'app',
  components: {
    SiteHeader,
    // SiteNav,
    // SiteFooter
  },
    computed: {
    /**
     * Indicates if the header should be visible.
     */
    showHeader() {
      const noHeaderPages = ["login"];
      return noHeaderPages.indexOf(this.$route.name) === -1;
    }
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
