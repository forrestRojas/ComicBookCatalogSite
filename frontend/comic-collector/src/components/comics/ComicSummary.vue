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
  padding: 25px;
}


.comic-summary:hover {
	background: var(--carmine-pink); /* rgba(233, 79, 55) */
	animation: gradient 300ms ease;
	color: var(--isabelline);
}

.comic-summary:hover h2 {
	color: var(--isabelline);
}

.comic-summary:hover img {
	border-color: var(--tufts-blue);
	box-shadow: 5px 10px rgba(44, 14, 9, 0.671);
}

.comic-summary picture {
  transition: all .5s;
  position: relative;
  bottom: 0;
} 

.comic-summary:hover picture {
    bottom: 4px;
}

.comic-summary:active {
	background: #f88;
}

.comic-summary img {
    transition: all .5s;
    object-fit: scale-down;
    width: 125px;
    padding: 5px;
    border: 2pt solid;
    bottom: 0;
    border-color: var(--carmine-pink);
    background-color: var(--black-olive);
    box-shadow: 5px 5px var(--black-olive);
    /* transform: rotate(2deg); */
}
h2 {
  color: var(--tufts-blue);
}
</style>
