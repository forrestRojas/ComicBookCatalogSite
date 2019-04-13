<template>
  <article class="comic-summary" v-on:click="GotoComic()">
    <header>
      <h2>{{comic.name}}</h2>
      <h3>Publisher: {{comic.publisher}}</h3>
    </header>

    <p>{{comic.issueNumber}}</p>
    <p>{{comic.deck}}</p>
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
  display: flex;
  background-color: var(--isabelline);
  margin: 10px;
}
img {
  height: 250px;
}
</style>
