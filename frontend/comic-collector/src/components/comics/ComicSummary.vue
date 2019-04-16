<template>
  <article class="comic-summary" v-on:click="GotoComic()">
    <header>
      <h2>{{comic.name}}</h2>
      <h3>Publisher: {{comic.publisher}}</h3>
          <p>{{comic.deck}}</p>

    </header>

    <p>Issue: {{comic.issueNumber}}</p>
    <picture>
      <source :srcset="comic.image">
      <img :src="comic.image" alt>
    </picture>
  </article>
</template>

<script>
export default {
  name: "comic-summary",
  props: {
    comic: Object
  },
  methods: {
    GotoComic() {
      this.$router.push({ path: `/comic/${this.comic.id}` });
    }
  }
};
</script>

<style scoped>
.comic-summary {
  display: grid;
  grid-auto-flow: column;
  align-items: center;
  grid-template-columns: 3fr 1fr 1fr;;
  background-color: var(--isabelline);
  margin: 25px;
}
img {
    object-fit: scale-down;
    width: 125px;
    padding: 5px;
    border: 2pt solid;
    border-color: var(--carmine-pink);
    background-color: var(--black-olive);
    box-shadow: 5px 5px var(--black-olive);
    transform: rotate(2deg);
}
h2 {
  color: var(--tufts-blue);
}
</style>
