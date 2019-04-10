<template>
  <div id="app">
    <site-header  class="header"></site-header>
    <site-nav class="nav"></site-nav>
    <router-view class="main"/>
    <!-- <site-footer></site-footer> -->
  </div>
</template>

<script>
import SiteHeader from './components/layout/SiteHeader.vue';
import SiteNav from './components/layout/SiteNav.vue';
// import SiteFooter from './components/layout/SiteFooter.vue';

export default {
  name: 'app',
  components: {
    SiteHeader,
    SiteNav,
    // SiteFooter
  },
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
  display: grid;
  grid-template-columns: 1fr 4fr;
  grid-template-areas: 
    "header header"
    "nav main"
    /* footer footer */
}
.header {
  grid-area: header;
}
.nav {
  grid-area: nav;
}
.main {
  grid-area: main;
}
</style>
