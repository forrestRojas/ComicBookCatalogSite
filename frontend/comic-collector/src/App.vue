<template>
  <div id="app">
    <site-header id="site-header"></site-header>
    <site-nav id="site-nav"></site-nav>
    <router-view />
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
:root {
  --isabelline: #F6F7EB;
  --carmine-pink: #E94F37;
  --black-olive: #393E41;
  --tufts-blue: #3F88C5;
  --verdigris: #44BBA4;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  background: var(--isabelline);
  color: #2c3e50;
  display: grid;
  min-height: inherit;
  /* min-height: -webkit-fill-available; */
  grid-template-columns: 1fr 7fr;
  grid-template-rows: 0fr 2fr 1fr; 
  grid-template-areas: 
    "header header"
    "nav main"
    "footer footer";
}


#site-header {
  grid-area: header;
}
#site-nav {
  min-width: 282.33px;
  grid-area: nav;
  background: inherit;
}
main {
  grid-area: main;
  background: inherit;
}
</style>
