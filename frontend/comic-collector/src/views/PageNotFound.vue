<template>
  <main id="not-found" onload="notFound()">
    <h2>The Page you are looking for does not exists.</h2>
  </main>
</template>

<script>
function notFound() {
  document.querySelector('body').style.overflow = 'hidden';
}
export default {
  name: "not-found"
}
</script>

<style>


#not-found {
  position: fixed;
  margin-top: -5rem;
  overflow: hidden;
  width: 100vw;
  height: 100%;
  background-image: url('~@/assets/thanos.gif');
  background-repeat: no-repeat;
  background-origin: content-box;
  background-size: cover;
}

</style>
