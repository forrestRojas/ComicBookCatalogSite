<template>
    <article class="comic-summary" v-on:click="GotoComic()">
        <img :src="comic.image"/>
        <h1>{{comic.name}}</h1>
        <h3>Publisher: {{comic.publisher}}</h3>
        <p>{{comic.issueNumber}}</p>
        <p>{{comic.deck}}</p>
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
}
</script>

<style>
    .comic-summary {
        display: flex;
        background-color: var(--isabelline);
        margin: 10px;
    }

    img {
      height: 200px;
    }
</style>
