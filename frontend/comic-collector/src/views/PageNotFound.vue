<template>
  <main id="not-found" onload="notFound()">
    <h2>The Page you are looking <span>for does not exist.</span></h2>
  </main>
</template>

<script>
export default {
  name: "not-found",
  beforeCreate() {
    document.querySelector('body').classList.add('not-found');
    const rootStyles = document.styleSheets[10].cssRules[0];
    rootStyles.style.height = '100%';
  },
}
</script>

<style>
@keyframes textFade {
  0% {opacity: 1;}
  50% {opacity: 1;}
  100% {opacity: 0;}
}

.not-found {
  /* position: fixed;
  margin-top: -5rem; */
  /* overflow: hidden; */
  /* width: 100vw; */
  margin: 0;
  height: inherit;

  background-image: url('~@/assets/thanos.gif');
  background-repeat: no-repeat;
  background-origin: content-box;
  background-size: cover;
}

.not-found #site-header, .not-found #site-logo, .not-found #site-footer, .not-found nav {
  display: none;
}

.not-found #app {
  max-height: 100vmax;
  width: 100vw;
  height: 100%;
  background: none;
  display: block;
}

.not-found main {
  display: flex;
  background: none;
  height: inherit;
  justify-content: center;
  align-items: center;
}

.not-found main h2 span {
  opacity: 1;
  animation-name: textFade;
  animation-duration: 1640ms;
  animation-iteration-count: infinite;
}

</style>
